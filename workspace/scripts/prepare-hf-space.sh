#!/usr/bin/env bash
set -euo pipefail

ROOT="$(cd "$(dirname "$0")/../.." && pwd)"
OUT_DIR="$ROOT/workspace/build/hf-space"
RELEASE_TAG="${RELEASE_TAG:-}"
RELEASE_BUNDLE_URL="${RELEASE_BUNDLE_URL:-}"

if [[ -z "$RELEASE_TAG" ]]; then
  RELEASE_TAG="v$(sed -n 's:.*<Version>\(.*\)</Version>.*:\1:p' "$ROOT/workspace/research/E5Renewer.Net/Directory.Build.props" | head -n 1)"
fi

if [[ -z "$RELEASE_BUNDLE_URL" ]]; then
  GITHUB_REPOSITORY="${GITHUB_REPOSITORY:-pixian5/Microsoft365_E5_Renew_X}"
  RELEASE_BUNDLE_URL="https://github.com/${GITHUB_REPOSITORY}/releases/download/${RELEASE_TAG}/Microsoft365_E5_Renew_X-${RELEASE_TAG}.tar.gz"
fi

rm -rf "$OUT_DIR"
mkdir -p "$OUT_DIR"

cp "$ROOT/README.md" "$OUT_DIR/"
mkdir -p "$OUT_DIR/docker"
cp -R "$ROOT/docker/." "$OUT_DIR/docker/"

sed "s|__RELEASE_BUNDLE_URL__|$RELEASE_BUNDLE_URL|g" "$ROOT/Dockerfile" > "$OUT_DIR/Dockerfile"

find "$OUT_DIR" -name .DS_Store -delete

printf 'HF Space bundle created at: %s\n' "$OUT_DIR"
printf 'HF Space will download release bundle from: %s\n' "$RELEASE_BUNDLE_URL"
