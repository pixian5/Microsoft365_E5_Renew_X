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
ADD ${RELEASE_BUNDLE_URL} /tmp/release.tar.gz

RUN test -n "$RELEASE_BUNDLE_URL" \
    && test -n "$RELEASE_VERSION" \
    && printf '%s' "$RELEASE_BUNDLE_URL" | grep -Eq '^https://.+' \
    && printf '%s' "$RELEASE_VERSION" | grep -Eq '^[0-9]+\.[0-9]+\.[0-9]+\.[0-9]+$' \
    && chmod +x /entrypoint.sh \
    && mkdir -p /app/Deploy /app/runtime/history /app/current /data \
    && tar -xzf /tmp/release.tar.gz -C /app/current \
    && test -x /app/current/Microsoft365_E5_Renew_X \
    && test -f /app/current/release-version.txt \
    && [ "$(tr -d '\r\n' < /app/current/release-version.txt)" = "$RELEASE_VERSION" ] \
    && rm -f /tmp/release.tar.gz

EXPOSE 7860

ENTRYPOINT ["/entrypoint.sh"]
