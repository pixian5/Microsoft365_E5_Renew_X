#!/bin/zsh
set -euo pipefail

ROOT="$(cd "$(dirname "$0")/../.." && pwd)"
DOTNET_ROOT="${DOTNET_ROOT:-/Users/x/Tools/dotnet}"
export DOTNET_ROOT
export PATH="$DOTNET_ROOT:$PATH"

APP_DIR="$ROOT/bin/Release/net10.0"

if [[ -x "$APP_DIR/Microsoft365_E5_Renew_X" ]]; then
  exec "$APP_DIR/Microsoft365_E5_Renew_X"
fi

if [[ -x "$APP_DIR/E5Renewer" ]]; then
  exec "$APP_DIR/E5Renewer"
fi

if [[ -f "$APP_DIR/Microsoft365_E5_Renew_X.dll" ]]; then
  exec dotnet "$APP_DIR/Microsoft365_E5_Renew_X.dll"
fi

if [[ -f "$APP_DIR/E5Renewer.dll" ]]; then
  exec dotnet "$APP_DIR/E5Renewer.dll"
fi

printf '未找到可运行产物，请先执行构建：%s\n' "$APP_DIR" >&2
exit 1
