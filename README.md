---
title: Microsoft365 E5 Renew X Next
sdk: docker
app_port: 7860
---

# Microsoft365 E5 Renew X Next

Docker Space for the multi-account Microsoft 365 E5 renew dashboard.

This Space ships a prebuilt publish bundle so Hugging Face only needs to start the container instead of compiling the full .NET solution during build.

## Required Space Secrets

- `USER_SECRET_JSON`
- `TOKEN_TXT` (optional)

The container writes these secrets into `Deploy/user-secret.json` and `Deploy/token.txt` at startup.

## GitHub Actions Secrets

- `HF_TOKEN`: Hugging Face write token used by GitHub Actions
- `HF_SPACE_ID`: target Space id such as `xbzsb/microsoft365-e5-renew-x-next`

The workflow in `.github/workflows/release-and-deploy.yml` builds the publish bundle, attaches it to a GitHub Release, and then syncs the same prebuilt bundle to the Hugging Face Space.
