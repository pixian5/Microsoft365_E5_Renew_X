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
  printf '状态：未运行\n'
  exit 0
fi

PID="$(cat "$PID_FILE" 2>/dev/null || true)"
if [[ -n "${PID:-}" ]] && kill -0 "$PID" >/dev/null 2>&1; then
  printf '状态：运行中，PID=%s\n' "$PID"
  exit 0
fi

printf '状态：未运行（PID 文件已过期）\n'
exit 0
