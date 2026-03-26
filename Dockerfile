FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

ARG GITHUB_REPOSITORY="__GITHUB_REPOSITORY__"
ARG RELEASE_BUNDLE_URL="__RELEASE_BUNDLE_URL__"
ARG RELEASE_VERSION=""
ARG RELEASE_VERSION_URL="__RELEASE_VERSION_URL__"

ENV DOTNET_EnableDiagnostics=0 \
    PORT=7860 \
    HF_HOME=/data/.huggingface \
    GITHUB_REPOSITORY="${GITHUB_REPOSITORY}" \
    RELEASE_BUNDLE_URL="${RELEASE_BUNDLE_URL}" \
    RELEASE_VERSION="${RELEASE_VERSION}" \
    RELEASE_VERSION_URL="${RELEASE_VERSION_URL}"

COPY docker/entrypoint.sh /entrypoint.sh

RUN apt-get update \
    && apt-get install -y --no-install-recommends ca-certificates curl tar \
    && rm -rf /var/lib/apt/lists/* \
    && test -n "$RELEASE_BUNDLE_URL" \
    && test -n "$RELEASE_VERSION_URL" \
    && printf '%s' "$RELEASE_BUNDLE_URL" | grep -Eq '^https://.+' \
    && printf '%s' "$RELEASE_VERSION_URL" | grep -Eq '^https://.+' \
    && chmod +x /entrypoint.sh \
    && mkdir -p /app/Deploy /app/runtime/history /app/current /data

EXPOSE 7860

ENTRYPOINT ["/entrypoint.sh"]
