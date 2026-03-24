#!/bin/zsh
set -euo pipefail

ROOT="$(cd "$(dirname "$0")/../.." && pwd)"
DOTNET_ROOT="${DOTNET_ROOT:-/Users/x/Tools/dotnet}"
export DOTNET_ROOT
export PATH="$DOTNET_ROOT:$PATH"

dotnet clean "$ROOT/Microsoft365_E5_Renew_X.csproj" -c Release
dotnet build "$ROOT/Microsoft365_E5_Renew_X.csproj" -c Release

# Prune stale build-host folders that can linger as empty directories after dependency removal.
rm -rf "$ROOT/bin/Release/net10.0/BuildHost-net472" "$ROOT/bin/Release/net10.0/BuildHost-netcore"

# Prune historical folders and Finder metadata that should not stay in the app output.
rm -rf \
  "$ROOT/bin/Release/net10.0/archive" \
  "$ROOT/bin/Release/net10.0/recovered-src" \
  "$ROOT/bin/Release/net10.0/research" \
  "$ROOT/bin/Release/net10.0/workspace" || true
find "$ROOT/bin/Release/net10.0" -name .DS_Store -delete

# Strip debug symbols and XML docs from the runnable output to keep local builds lean.
find "$ROOT/bin/Release/net10.0" -maxdepth 1 \( -name '*.pdb' -o -name '*.xml' \) -delete
