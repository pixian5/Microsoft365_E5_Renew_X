#!/bin/zsh
set -euo pipefail

ROOT="$(cd "$(dirname "$0")/../.." && pwd)"
DOTNET_ROOT="${DOTNET_ROOT:-/Users/x/Tools/dotnet}"
export DOTNET_ROOT
export PATH="$DOTNET_ROOT:$PATH"

dotnet run --project "$ROOT/Microsoft365_E5_Renew_X.csproj" -c Release --no-build --no-launch-profile
