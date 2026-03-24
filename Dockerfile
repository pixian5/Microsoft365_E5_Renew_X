FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS final
WORKDIR /app

ENV DOTNET_EnableDiagnostics=0 \
    PORT=7860 \
    HF_HOME=/data/.huggingface

COPY app/ /app/app/
COPY appsettings.json /app/appsettings.json
COPY appsettings.Development.json /app/appsettings.Development.json
COPY Microsoft365_E5_Renew_X /app/Microsoft365_E5_Renew_X
COPY wwwroot/ /app/wwwroot/
COPY docker/entrypoint.sh /entrypoint.sh

RUN chmod +x /entrypoint.sh \
    && chmod +x /app/Microsoft365_E5_Renew_X \
    && mkdir -p /app/Deploy /app/runtime/history /data

EXPOSE 7860

ENTRYPOINT ["/entrypoint.sh"]
