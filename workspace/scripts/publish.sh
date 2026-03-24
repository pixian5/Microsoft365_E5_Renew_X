#!/usr/bin/env bash
set -euo pipefail

ROOT="$(cd "$(dirname "$0")/../.." && pwd)"
OUT_DIR="$ROOT/workspace/build/publish"
APP_DIR="$OUT_DIR/app"

if [[ -n "${DOTNET_ROOT:-}" ]]; then
  export PATH="$DOTNET_ROOT:$PATH"
elif [[ -d /Users/x/Tools/dotnet ]]; then
  export DOTNET_ROOT=/Users/x/Tools/dotnet
  export PATH="$DOTNET_ROOT:$PATH"
fi

rm -rf "$OUT_DIR"
mkdir -p "$APP_DIR" "$OUT_DIR/Deploy" "$OUT_DIR/runtime/history" "$OUT_DIR/wwwroot"

dotnet publish "$ROOT/Microsoft365_E5_Renew_X.csproj" -c Release -o "$APP_DIR"

find "$APP_DIR" -type f \( -name '*.pdb' -o -name '*.xml' -o -name 'web.config' \) -delete

cp "$ROOT/appsettings.json" "$OUT_DIR/appsettings.json"

if [[ -f "$ROOT/appsettings.Development.json" ]]; then
  cp "$ROOT/appsettings.Development.json" "$OUT_DIR/appsettings.Development.json"
fi

if [[ -f "$ROOT/Deploy/user-secret.json" ]]; then
  cp "$ROOT/Deploy/user-secret.json" "$OUT_DIR/Deploy/user-secret.json"
fi

if [[ -f "$ROOT/Deploy/token.txt" ]]; then
  cp "$ROOT/Deploy/token.txt" "$OUT_DIR/Deploy/token.txt"
fi

if [[ -f "$ROOT/wwwroot/favicon.svg" ]]; then
  cp "$ROOT/wwwroot/favicon.svg" "$OUT_DIR/wwwroot/favicon.svg"
fi

cp "$ROOT/workspace/scripts/start-background.sh" "$OUT_DIR/start-background.sh"
cp "$ROOT/workspace/scripts/stop-background.sh" "$OUT_DIR/stop-background.sh"
cp "$ROOT/workspace/scripts/status.sh" "$OUT_DIR/status.sh"
cp "$ROOT/workspace/scripts/start-background.ps1" "$OUT_DIR/start-background.ps1"
cp "$ROOT/workspace/scripts/stop-background.ps1" "$OUT_DIR/stop-background.ps1"
cp "$ROOT/workspace/scripts/status.ps1" "$OUT_DIR/status.ps1"

cat > "$OUT_DIR/Microsoft365_E5_Renew_X" <<'EOF'
#!/usr/bin/env bash
set -euo pipefail

ROOT="$(cd "$(dirname "$0")" && pwd)"
APP="$ROOT/app/Microsoft365_E5_Renew_X"

cd "$ROOT"
exec "$APP" "$@"
EOF

chmod +x "$OUT_DIR/Microsoft365_E5_Renew_X"
chmod +x "$OUT_DIR/start-background.sh" "$OUT_DIR/stop-background.sh" "$OUT_DIR/status.sh"

find "$OUT_DIR" -name .DS_Store -delete

printf 'Publish directory created at: %s\n' "$OUT_DIR"
