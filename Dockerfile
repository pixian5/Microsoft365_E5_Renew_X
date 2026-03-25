FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

ARG RELEASE_BUNDLE_URL="__RELEASE_BUNDLE_URL__"

ENV DOTNET_EnableDiagnostics=0 \
    PORT=7860 \
    HF_HOME=/data/.huggingface \
    RELEASE_BUNDLE_URL="${RELEASE_BUNDLE_URL}"

COPY docker/entrypoint.sh /entrypoint.sh

RUN apt-get update \
    && apt-get install -y --no-install-recommends ca-certificates curl tar \
    && rm -rf /var/lib/apt/lists/* \
    && test -n "$RELEASE_BUNDLE_URL" \
    && printf '%s' "$RELEASE_BUNDLE_URL" | grep -Eq '^https://.+' \
    && chmod +x /entrypoint.sh \
    && mkdir -p /app/Deploy /app/runtime/history /app/current /data

EXPOSE 7860

ENTRYPOINT ["/entrypoint.sh"]
