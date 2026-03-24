#!/usr/bin/env bash
set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "$0")" && pwd)"

if [[ -d "$SCRIPT_DIR/app" ]] || [[ -x "$SCRIPT_DIR/Microsoft365_E5_Renew_X" ]]; then
  ROOT="$SCRIPT_DIR"
  DEFAULT_APP_DIR="$ROOT/app"
else
  ROOT="$(cd "$SCRIPT_DIR/../.." && pwd)"
  DEFAULT_APP_DIR="$ROOT/bin/Release/net10.0"
fi

APP_DIR="${APP_DIR:-$DEFAULT_APP_DIR}"
RUNTIME_DIR="${RUNTIME_DIR:-$ROOT/runtime}"
LOG_DIR="$RUNTIME_DIR/history"
PID_FILE="$RUNTIME_DIR/app.pid"
TIMESTAMP="$(date '+%Y%m%d-%H%M%S')"
LOG_FILE="$LOG_DIR/console-$TIMESTAMP.log"

mkdir -p "$LOG_DIR"

if [[ -f "$PID_FILE" ]]; then
  old_pid="$(cat "$PID_FILE" 2>/dev/null || true)"
  if [[ -n "${old_pid:-}" ]] && kill -0 "$old_pid" >/dev/null 2>&1; then
    printf '程序已在后台运行，PID=%s\n' "$old_pid"
    exit 0
  fi
  rm -f "$PID_FILE"
fi

if [[ -n "${DOTNET_ROOT:-}" ]]; then
  export PATH="$DOTNET_ROOT:$PATH"
elif [[ -d /Users/x/Tools/dotnet ]]; then
  export DOTNET_ROOT=/Users/x/Tools/dotnet
  export PATH="$DOTNET_ROOT:$PATH"
fi

resolve_command() {
  if [[ -x "$APP_DIR/Microsoft365_E5_Renew_X" ]]; then
    printf '%q ' "$APP_DIR/Microsoft365_E5_Renew_X"
    return 0
  fi

  if [[ -f "$APP_DIR/Microsoft365_E5_Renew_X.dll" ]]; then
    printf '%q %q ' "dotnet" "$APP_DIR/Microsoft365_E5_Renew_X.dll"
    return 0
  fi

  return 1
}

COMMAND="$(resolve_command || true)"
if [[ -z "$COMMAND" ]]; then
  printf '未找到可运行产物，请先执行构建：%s\n' "$APP_DIR" >&2
  exit 1
fi

(
  cd "$ROOT"
  nohup bash -lc "$COMMAND" >>"$LOG_FILE" 2>&1 </dev/null &
  echo $! > "$PID_FILE"
)

printf '后台启动成功，PID=%s\n' "$(cat "$PID_FILE")"
printf '日志文件：%s\n' "$LOG_FILE"
