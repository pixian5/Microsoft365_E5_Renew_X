#!/bin/sh
set -eu

APP_ROOT=/app
CURRENT_ROOT="$APP_ROOT/current"
DEPLOY_DIR="$APP_ROOT/Deploy"
RELEASE_VERSION="${RELEASE_VERSION:-}"
STARTUP_LOG="$APP_ROOT/runtime/history/startup.log"
RESTART_FLAG="$APP_ROOT/runtime/restart.requested"
APP_PID=""

mkdir -p "$DEPLOY_DIR" "$APP_ROOT/runtime/history" "$APP_ROOT/wwwroot" "$CURRENT_ROOT"

log() {
  message="$1"
  timestamp="$(date '+%Y-%m-%d %H:%M:%S')"
  printf '[%s] %s\n' "$timestamp" "$message" | tee -a "$STARTUP_LOG"
}

current_bundle_version() {
  if [ -f "$CURRENT_ROOT/release-version.txt" ]; then
    tr -d '\r\n' < "$CURRENT_ROOT/release-version.txt"
  fi
}

ensure_runtime_layout() {
  if [ ! -x "$CURRENT_ROOT/Microsoft365_E5_Renew_X" ]; then
    log "发布包入口不存在：$CURRENT_ROOT/Microsoft365_E5_Renew_X"
    exit 1
  fi

  current_version="$(current_bundle_version)"
  if [ -z "$current_version" ]; then
    log "当前发布包缺少 release-version.txt。"
    exit 1
  fi

  if [ -n "$RELEASE_VERSION" ] && [ "$current_version" != "$RELEASE_VERSION" ]; then
    log "镜像内发布包版本不匹配。expected=$RELEASE_VERSION actual=$current_version"
    exit 1
  fi

  rm -rf "$CURRENT_ROOT/Deploy" "$CURRENT_ROOT/runtime"
  ln -s "$DEPLOY_DIR" "$CURRENT_ROOT/Deploy"
  ln -s "$APP_ROOT/runtime" "$CURRENT_ROOT/runtime"
  log "容器将使用内置发布包版本 $current_version。"
}

if [ -n "${USER_SECRET_JSON_B64:-}" ]; then
  printf '%s' "$USER_SECRET_JSON_B64" | base64 -d > "$DEPLOY_DIR/user-secret.json"
elif [ -n "${USER_SECRET_JSON:-}" ]; then
  printf '%s' "$USER_SECRET_JSON" > "$DEPLOY_DIR/user-secret.json"
elif [ ! -f "$DEPLOY_DIR/user-secret.json" ]; then
  cat > "$DEPLOY_DIR/user-secret.json" <<'EOF'
{"users":[],"settings":{"from_time":"08:00:00","to_time":"23:59:59","days":[0,1,2,3,4,5,6],"api_call_interval_min_seconds":10,"api_call_interval_max_seconds":30,"frontend_refresh_seconds":5}}
EOF
fi

if [ -n "${TOKEN_TXT_B64:-}" ]; then
  printf '%s' "$TOKEN_TXT_B64" | base64 -d > "$DEPLOY_DIR/token.txt"
elif [ -n "${TOKEN_TXT:-}" ]; then
  printf '%s' "$TOKEN_TXT" > "$DEPLOY_DIR/token.txt"
fi

export PORT="${PORT:-7860}"
export HOST="${HOST:-0.0.0.0}"
export ASPNETCORE_URLS="${ASPNETCORE_URLS:-http://${HOST}:${PORT}}"
export DOTNET_RUNNING_IN_CONTAINER="${DOTNET_RUNNING_IN_CONTAINER:-true}"

start_app() {
  log "启动应用进程，版本 $(current_bundle_version)。"
  "$CURRENT_ROOT/Microsoft365_E5_Renew_X" &
  APP_PID=$!
  log "应用进程已启动，pid=$APP_PID。"
}

stop_app() {
  reason="$1"
  if [ -z "${APP_PID:-}" ]; then
    return
  fi

  if ! kill -0 "$APP_PID" 2>/dev/null; then
    wait "$APP_PID" 2>/dev/null || true
    APP_PID=""
    return
  fi

  log "准备停止应用进程，原因=$reason，pid=$APP_PID。"
  kill "$APP_PID" 2>/dev/null || true

  waited=0
  while kill -0 "$APP_PID" 2>/dev/null; do
    waited=$((waited + 1))
    if [ "$waited" -ge 30 ]; then
      log "应用进程在 30 秒内未退出，执行强制终止。pid=$APP_PID。"
      kill -9 "$APP_PID" 2>/dev/null || true
      break
    fi

    sleep 1
  done

  wait "$APP_PID" 2>/dev/null || true
  APP_PID=""
}

child_exit_code() {
  if [ -z "${APP_PID:-}" ]; then
    printf '0'
    return
  fi

  if wait "$APP_PID"; then
    printf '0'
  else
    printf '%s' "$?"
  fi
}

ensure_runtime_layout
start_app

while true; do
  if [ -f "$RESTART_FLAG" ]; then
    rm -f "$RESTART_FLAG"
    log "检测到手动重启标记，准备重启应用进程。"
    stop_app "manual-restart"
    ensure_runtime_layout
    start_app
    sleep 1
    continue
  fi

  if ! kill -0 "$APP_PID" 2>/dev/null; then
    exit_code="$(child_exit_code)"
    log "应用进程退出，exit_code=$exit_code。"
    exit "$exit_code"
  fi

  sleep 1
done
