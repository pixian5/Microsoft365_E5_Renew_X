FROM python:3.12-slim AS bundle
WORKDIR /bundle

ARG RELEASE_BUNDLE_URL="__RELEASE_BUNDLE_URL__"
ARG RELEASE_VERSION="__RELEASE_VERSION__"

RUN test -n "$RELEASE_BUNDLE_URL" \
    && test -n "$RELEASE_VERSION" \
    && printf '%s' "$RELEASE_BUNDLE_URL" | grep -Eq '^https://.+' \
    && printf '%s' "$RELEASE_VERSION" | grep -Eq '^[0-9]+\.[0-9]+\.[0-9]+\.[0-9]+$' \
    && RELEASE_BUNDLE_URL="$RELEASE_BUNDLE_URL" RELEASE_VERSION="$RELEASE_VERSION" python - <<'PY'
import os
import pathlib
import shutil
import stat
import tarfile
import urllib.request

bundle_url = os.environ["RELEASE_BUNDLE_URL"].strip()
release_version = os.environ["RELEASE_VERSION"].strip()
archive_path = pathlib.Path("/tmp/release.tar.gz")
current_root = pathlib.Path("/bundle/current")

print(f"Downloading release bundle: {bundle_url}", flush=True)
with urllib.request.urlopen(bundle_url) as response, archive_path.open("wb") as target:
    shutil.copyfileobj(response, target)

print(f"Extracting release bundle for version: {release_version}", flush=True)
current_root.mkdir(parents=True, exist_ok=True)
with tarfile.open(archive_path, "r:gz") as tar:
    tar.extractall(current_root, filter="data")

version_file = current_root / "release-version.txt"
if not version_file.is_file():
    raise SystemExit("release-version.txt is missing in the publish bundle.")

actual_version = version_file.read_text(encoding="utf-8").strip()
if actual_version != release_version:
    raise SystemExit(f"Release bundle version mismatch: expected {release_version}, got {actual_version}")

entrypoint = current_root / "Microsoft365_E5_Renew_X"
if not entrypoint.is_file():
    raise SystemExit("Publish bundle entrypoint Microsoft365_E5_Renew_X is missing.")

entrypoint.chmod(entrypoint.stat().st_mode | stat.S_IXUSR | stat.S_IXGRP | stat.S_IXOTH)
print(f"Prepared release bundle version: {actual_version}", flush=True)
PY

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

ARG GITHUB_REPOSITORY="__GITHUB_REPOSITORY__"
ARG RELEASE_BUNDLE_URL="__RELEASE_BUNDLE_URL__"
ARG RELEASE_VERSION="__RELEASE_VERSION__"

ENV DOTNET_EnableDiagnostics=0 \
    PORT=7860 \
    HF_HOME=/data/.huggingface \
    GITHUB_REPOSITORY="${GITHUB_REPOSITORY}" \
    RELEASE_BUNDLE_URL="${RELEASE_BUNDLE_URL}" \
    RELEASE_VERSION="${RELEASE_VERSION}"

COPY docker/entrypoint.sh /entrypoint.sh
COPY --from=bundle /bundle/current /app/current

RUN test -n "$RELEASE_BUNDLE_URL" \
    && test -n "$RELEASE_VERSION" \
    && printf '%s' "$RELEASE_BUNDLE_URL" | grep -Eq '^https://.+' \
    && printf '%s' "$RELEASE_VERSION" | grep -Eq '^[0-9]+\.[0-9]+\.[0-9]+\.[0-9]+$' \
    && chmod +x /entrypoint.sh \
    && mkdir -p /app/Deploy /app/runtime/history /app/current /data \
    && test -x /app/current/Microsoft365_E5_Renew_X \
    && test -f /app/current/release-version.txt \
    && [ "$(tr -d '\r\n' < /app/current/release-version.txt)" = "$RELEASE_VERSION" ]

EXPOSE 7860

ENTRYPOINT ["/entrypoint.sh"]
