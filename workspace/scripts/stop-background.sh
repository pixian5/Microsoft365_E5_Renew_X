#!/usr/bin/env bash
set -euo pipefail

SCRIPT_DIR="$(cd "$(dirname "$0")" && pwd)"

if [[ -d "$SCRIPT_DIR/app" ]] || [[ -x "$SCRIPT_DIR/Microsoft365_E5_Renew_X" ]]; then
  ROOT="$SCRIPT_DIR"
else
  ROOT="$(cd "$SCRIPT_DIR/../.." && pwd)"
fi

RUNTIME_DIR="${RUNTIME_DIR:-$ROOT/runtime}"
PID_FILE="$RUNTIME_DIR/app.pid"

if [[ ! -f "$PID_FILE" ]]; then
  printf '未找到 PID 文件，程序可能没有在后台运行。\n'
  exit 0
fi

PID="$(cat "$PID_FILE" 2>/dev/null || true)"
if [[ -z "${PID:-}" ]]; then
  rm -f "$PID_FILE"
  printf 'PID 文件为空，已清理。\n'
  exit 0
fi

if kill -0 "$PID" >/dev/null 2>&1; then
  kill "$PID" >/dev/null 2>&1 || true
  for _ in {1..30}; do
    if ! kill -0 "$PID" >/dev/null 2>&1; then
      rm -f "$PID_FILE"
      printf '后台进程已停止，PID=%s\n' "$PID"
      exit 0
    fi
    sleep 1
  done

  kill -9 "$PID" >/dev/null 2>&1 || true
  rm -f "$PID_FILE"
  printf '后台进程已强制停止，PID=%s\n' "$PID"
  exit 0
fi

rm -f "$PID_FILE"
printf 'PID=%s 对应进程不存在，已清理 PID 文件。\n' "$PID"
