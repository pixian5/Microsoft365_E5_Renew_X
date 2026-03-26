#!/usr/bin/env bash
set -euo pipefail

ROOT="$(cd "$(dirname "$0")/../.." && pwd)"
OUT_DIR="$ROOT/workspace/build/hf-space"
RELEASE_TAG="${RELEASE_TAG:-}"
RELEASE_BUNDLE_URL="${RELEASE_BUNDLE_URL:-}"
RELEASE_VERSION_URL="${RELEASE_VERSION_URL:-}"
RELEASE_VERSION="${RELEASE_VERSION:-}"
GITHUB_REPOSITORY="${GITHUB_REPOSITORY:-pixian5/Microsoft365_E5_Renew_X}"
SOURCE_COMMIT="${SOURCE_COMMIT:-}"

if [[ -z "$RELEASE_BUNDLE_URL" ]]; then
  RELEASE_BUNDLE_URL="https://github.com/${GITHUB_REPOSITORY}/releases/latest/download/Microsoft365_E5_Renew_X-latest.tar.gz"
fi

if [[ -z "$RELEASE_VERSION_URL" ]]; then
  RELEASE_VERSION_URL="https://github.com/${GITHUB_REPOSITORY}/releases/latest/download/release-version.txt"
fi

if [[ -z "$RELEASE_VERSION" ]]; then
  if [[ -n "$RELEASE_TAG" ]]; then
    RELEASE_VERSION="${RELEASE_TAG#v}"
  fi
fi

if [[ -z "$SOURCE_COMMIT" ]]; then
  SOURCE_COMMIT="$(git -C "$ROOT" rev-parse HEAD 2>/dev/null || true)"
fi

rm -rf "$OUT_DIR"
mkdir -p "$OUT_DIR"

cp "$ROOT/README.md" "$OUT_DIR/"
mkdir -p "$OUT_DIR/docker"
cp -R "$ROOT/docker/." "$OUT_DIR/docker/"

sed \
  -e "s|__GITHUB_REPOSITORY__|$GITHUB_REPOSITORY|g" \
  -e "s|__RELEASE_BUNDLE_URL__|$RELEASE_BUNDLE_URL|g" \
  -e "s|__RELEASE_VERSION_URL__|$RELEASE_VERSION_URL|g" \
  "$ROOT/Dockerfile" > "$OUT_DIR/Dockerfile"

cat > "$OUT_DIR/release-manifest.json" <<EOF
{
  "releaseTag": "${RELEASE_TAG}",
  "releaseVersion": "${RELEASE_VERSION}",
  "releaseBundleUrl": "${RELEASE_BUNDLE_URL}",
  "releaseVersionUrl": "${RELEASE_VERSION_URL}",
  "sourceRepository": "${GITHUB_REPOSITORY}",
  "sourceCommit": "${SOURCE_COMMIT}"
}
EOF

find "$OUT_DIR" -name .DS_Store -delete

printf 'HF Space bundle created at: %s\n' "$OUT_DIR"
printf 'HF Space will download release bundle from: %s\n' "$RELEASE_BUNDLE_URL"
printf 'HF Space will resolve target version from: %s\n' "$RELEASE_VERSION_URL"
printf 'HF Space release marker version: %s\n' "${RELEASE_VERSION:-unknown}"
