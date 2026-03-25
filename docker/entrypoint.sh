#!/bin/sh
set -eu

APP_ROOT=/app
CURRENT_ROOT="$APP_ROOT/current"
DEPLOY_DIR="$APP_ROOT/Deploy"
BUNDLE_URL="${RELEASE_BUNDLE_URL:-}"
RELEASE_VERSION="${RELEASE_VERSION:-}"
BUNDLE_MARKER="$APP_ROOT/runtime/release-bundle-url.txt"
VERSION_MARKER="$APP_ROOT/runtime/release-version.txt"
STARTUP_LOG="$APP_ROOT/runtime/history/startup.log"

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

ensure_release_bundle() {
  if [ -z "$BUNDLE_URL" ]; then
    echo "RELEASE_BUNDLE_URL is not set." >&2
    exit 1
  fi

  if [ -z "$RELEASE_VERSION" ]; then
    echo "RELEASE_VERSION is not set." >&2
    exit 1
  fi

  current_marker=""
  current_version_marker=""
  current_bundle_version_value="$(current_bundle_version)"
  if [ -f "$BUNDLE_MARKER" ]; then
    current_marker="$(cat "$BUNDLE_MARKER")"
  fi
  if [ -f "$VERSION_MARKER" ]; then
    current_version_marker="$(cat "$VERSION_MARKER")"
  fi

  log "检查发布包。target_version=$RELEASE_VERSION target_url=$BUNDLE_URL current_version=${current_bundle_version_value:-missing} current_version_marker=${current_version_marker:-missing}"

  if [ "$current_marker" = "$BUNDLE_URL" ] \
    && [ "$current_version_marker" = "$RELEASE_VERSION" ] \
    && [ "$current_bundle_version_value" = "$RELEASE_VERSION" ] \
    && [ -x "$CURRENT_ROOT/Microsoft365_E5_Renew_X" ]; then
    log "命中当前发布包缓存，继续使用现有版本 $RELEASE_VERSION。"
    return
  fi

  log "当前发布包与目标版本不一致，开始重新下载并解压。"
  temp_dir="$(mktemp -d)"
  trap 'rm -rf "$temp_dir"' EXIT INT TERM

  curl -fsSL "$BUNDLE_URL" -o "$temp_dir/release.tar.gz"
  tar -xzf "$temp_dir/release.tar.gz" -C "$temp_dir"
  chmod +x "$temp_dir/Microsoft365_E5_Renew_X"

  extracted_version=""
  if [ -f "$temp_dir/release-version.txt" ]; then
    extracted_version="$(tr -d '\r\n' < "$temp_dir/release-version.txt")"
  fi

  if [ "$extracted_version" != "$RELEASE_VERSION" ]; then
    log "下载到的发布包版本不匹配。expected=$RELEASE_VERSION actual=${extracted_version:-missing}"
    exit 1
  fi

  rm -rf "$CURRENT_ROOT"
  mkdir -p "$CURRENT_ROOT"
  cp -R "$temp_dir"/. "$CURRENT_ROOT"/
  rm -rf "$CURRENT_ROOT/Deploy" "$CURRENT_ROOT/runtime"
  ln -s "$DEPLOY_DIR" "$CURRENT_ROOT/Deploy"
  ln -s "$APP_ROOT/runtime" "$CURRENT_ROOT/runtime"
  printf '%s' "$BUNDLE_URL" > "$BUNDLE_MARKER"
  printf '%s' "$RELEASE_VERSION" > "$VERSION_MARKER"
  log "发布包已切换到版本 $RELEASE_VERSION。"

  rm -rf "$temp_dir"
  trap - EXIT INT TERM
}

if [ -n "${USER_SECRET_JSON_B64:-}" ]; then
  printf '%s' "$USER_SECRET_JSON_B64" | base64 -d > "$DEPLOY_DIR/user-secret.json"
elif [ -n "${USER_SECRET_JSON:-}" ]; then
  printf '%s' "$USER_SECRET_JSON" > "$DEPLOY_DIR/user-secret.json"
elif [ ! -f "$DEPLOY_DIR/user-secret.json" ]; then
  cat > "$DEPLOY_DIR/user-secret.json" <<'EOF'
{"users":[],"settings":{"from_time":"08:00:00","to_time":"23:59:59","days":[0,1,2,3,4,5,6],"api_call_interval_min_seconds":1,"api_call_interval_max_seconds":1,"frontend_refresh_seconds":5}}
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
RESTART_FLAG="$APP_ROOT/runtime/restart.requested"

ensure_release_bundle

while true; do
  rm -f "$RESTART_FLAG"
  log "启动应用进程，版本 $(current_bundle_version)。"
  "$CURRENT_ROOT/Microsoft365_E5_Renew_X"
  exit_code=$?
  log "应用进程退出，exit_code=$exit_code。"

  if [ -f "$RESTART_FLAG" ]; then
    rm -f "$RESTART_FLAG"
    log "检测到重启请求，重新检查发布包。"
    ensure_release_bundle
    sleep 1
    continue
  fi

  exit "$exit_code"
done
