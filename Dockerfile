FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

ARG RELEASE_BUNDLE_URL="__RELEASE_BUNDLE_URL__"

ENV DOTNET_EnableDiagnostics=0 \
    PORT=7860 \
    HF_HOME=/data/.huggingface

COPY docker/entrypoint.sh /entrypoint.sh

RUN apt-get update \
    && apt-get install -y --no-install-recommends ca-certificates curl tar \
    && rm -rf /var/lib/apt/lists/* \
    && test -n "$RELEASE_BUNDLE_URL" \
    && test "$RELEASE_BUNDLE_URL" != "__RELEASE_BUNDLE_URL__" \
    && curl -fsSL "$RELEASE_BUNDLE_URL" -o /tmp/release.tar.gz \
    && tar -xzf /tmp/release.tar.gz -C /app \
    && rm -f /tmp/release.tar.gz \
    && chmod +x /entrypoint.sh \
    && chmod +x /app/Microsoft365_E5_Renew_X \
    && mkdir -p /app/Deploy /app/runtime/history /data

EXPOSE 7860

ENTRYPOINT ["/entrypoint.sh"]
