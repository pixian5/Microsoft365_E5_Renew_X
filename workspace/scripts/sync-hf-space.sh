#!/usr/bin/env bash
set -euo pipefail

ROOT="$(cd "$(dirname "$0")/../.." && pwd)"
SPACE_DIR="$ROOT/workspace/build/hf-space"
HF_SPACE_ID="${HF_SPACE_ID:?HF_SPACE_ID is required}"
HF_TOKEN="${HF_TOKEN:?HF_TOKEN is required}"
TMP_DIR="${TMPDIR:-/tmp}/hf-space-sync-$RANDOM"
REMOTE_URL="https://oauth2:${HF_TOKEN}@huggingface.co/spaces/${HF_SPACE_ID}"

cleanup() {
  rm -rf "$TMP_DIR"
}
trap cleanup EXIT

"$ROOT/workspace/scripts/prepare-hf-space.sh"

git clone "$REMOTE_URL" "$TMP_DIR"

find "$TMP_DIR" -mindepth 1 -maxdepth 1 ! -name .git -exec rm -rf {} +
cp -R "$SPACE_DIR"/. "$TMP_DIR"/

pushd "$TMP_DIR" >/dev/null
git config user.name "${GIT_AUTHOR_NAME:-github-actions[bot]}"
git config user.email "${GIT_AUTHOR_EMAIL:-41898282+github-actions[bot]@users.noreply.github.com}"

if [[ -n "$(git status --porcelain)" ]]; then
  git add .
  git commit -m "${HF_COMMIT_MESSAGE:-Deploy prebuilt publish bundle}"
  git push origin HEAD:main
else
  printf 'HF Space already up to date.\n'
fi
popd >/dev/null
