#!/usr/bin/env bash
set -euo pipefail

ROOT="$(cd "$(dirname "$0")/../.." && pwd)"
OUT_DIR="$ROOT/workspace/build/hf-space"
PUBLISH_DIR="$ROOT/workspace/build/publish"

"$ROOT/workspace/scripts/publish.sh"

rm -rf "$OUT_DIR"
mkdir -p "$OUT_DIR"

cp "$ROOT/Dockerfile" "$OUT_DIR/"
cp "$ROOT/README.md" "$OUT_DIR/"
mkdir -p "$OUT_DIR/docker"
cp -R "$ROOT/docker/." "$OUT_DIR/docker/"

cp -R "$PUBLISH_DIR/app" "$OUT_DIR/"
cp "$PUBLISH_DIR/Microsoft365_E5_Renew_X" "$OUT_DIR/"
cp "$PUBLISH_DIR/appsettings.json" "$OUT_DIR/"

if [[ -f "$PUBLISH_DIR/appsettings.Development.json" ]]; then
  cp "$PUBLISH_DIR/appsettings.Development.json" "$OUT_DIR/"
fi

if [[ -d "$PUBLISH_DIR/wwwroot" ]]; then
  cp -R "$PUBLISH_DIR/wwwroot" "$OUT_DIR/"
fi

mkdir -p "$OUT_DIR/Deploy"

find "$OUT_DIR" -name .DS_Store -delete

printf 'HF Space bundle created at: %s\n' "$OUT_DIR"
