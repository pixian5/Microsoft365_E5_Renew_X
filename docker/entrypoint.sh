#!/bin/sh
set -eu

APP_ROOT=/app
CURRENT_ROOT="$APP_ROOT/current"
DEPLOY_DIR="$APP_ROOT/Deploy"
BUNDLE_URL="${RELEASE_BUNDLE_URL:-}"
RELEASE_VERSION="${RELEASE_VERSION:-}"
RELEASE_VERSION_URL="${RELEASE_VERSION_URL:-}"
RELEASE_POLL_INTERVAL_SECONDS="${RELEASE_POLL_INTERVAL_SECONDS:-10}"
BUNDLE_MARKER="$APP_ROOT/runtime/release-bundle-url.txt"
VERSION_MARKER="$APP_ROOT/runtime/release-version.txt"
STARTUP_LOG="$APP_ROOT/runtime/history/startup.log"

mkdir -p "$DEPLOY_DIR" "$APP_ROOT/runtime/history" "$APP_ROOT/wwwroot" "$CURRENT_ROOT"

log() {
  message="$1"
  timestamp="$(date '+%Y-%m-%d %H:%M:%S')"
  printf '[%s] %s\n' "$timestamp" "$message" | tee -a "$STARTUP_LOG"
}

parse_url_host() {
  printf '%s' "$1" | perl -e 'my $u=<>; $u =~ s/[\r\n]+$//; $u =~ m{^https://([^/]+)(/.*)$} or exit 1; print $1;'
}

parse_url_path() {
  printf '%s' "$1" | perl -e 'my $u=<>; $u =~ s/[\r\n]+$//; $u =~ m{^https://([^/]+)(/.*)$} or exit 1; print $2;'
}

response_status_code() {
  perl -e 'my $path=shift; open my $fh, "<", $path or exit 1; binmode $fh; local $/; my $raw=<$fh>; my ($head)=split(/\r?\n\r?\n/, $raw, 2); my ($status)=$head =~ m{^HTTP/\S+\s+(\d+)}; print $status if defined $status;' "$1"
}

response_location() {
  perl -e 'my $path=shift; open my $fh, "<", $path or exit 1; binmode $fh; local $/; my $raw=<$fh>; my ($head)=split(/\r?\n\r?\n/, $raw, 2); my ($location)=$head =~ m{^Location:\s*(.+)$}mi; if (defined $location) { $location =~ s/\r$//; print $location; }' "$1"
}

response_body_to_file() {
  perl -e 'my ($path, $out)=@ARGV; open my $fh, "<", $path or die; binmode $fh; local $/; my $raw=<$fh>; my (undef, $body)=split(/\r?\n\r?\n/, $raw, 2); open my $target, ">", $out or die; binmode $target; print {$target} $body if defined $body;' "$1" "$2"
}

download_url_to_file() {
  current_url="$1"
  output_path="$2"
  redirect_count=0

  while [ "$redirect_count" -lt 5 ]; do
    host="$(parse_url_host "$current_url")" || return 1
    path="$(parse_url_path "$current_url")" || return 1
    request_file="$(mktemp)"
    response_file="$(mktemp)"

    printf 'GET %s HTTP/1.0\r\nHost: %s\r\nUser-Agent: Microsoft365_E5_Renew_X/1.0\r\nAccept: */*\r\nConnection: close\r\n\r\n' "$path" "$host" > "$request_file"

    if ! openssl s_client -quiet -connect "$host:443" < "$request_file" 2>/dev/null > "$response_file"; then
      rm -f "$request_file" "$response_file"
      return 1
    fi

    status_code="$(response_status_code "$response_file")"
    case "$status_code" in
      200)
        response_body_to_file "$response_file" "$output_path"
        rm -f "$request_file" "$response_file"
        return 0
        ;;
      301|302|303|307|308)
        next_url="$(response_location "$response_file")"
        rm -f "$request_file" "$response_file"
        if [ -z "$next_url" ]; then
          return 1
        fi

        case "$next_url" in
          /*)
            current_url="https://${host}${next_url}"
            ;;
          *)
            current_url="$next_url"
            ;;
        esac
        redirect_count=$((redirect_count + 1))
        ;;
      *)
        rm -f "$request_file" "$response_file"
        return 1
        ;;
    esac
  done

  return 1
}

current_bundle_version() {
  if [ -f "$CURRENT_ROOT/release-version.txt" ]; then
    tr -d '\r\n' < "$CURRENT_ROOT/release-version.txt"
  fi
}

resolve_target_version() {
  if [ -n "$RELEASE_VERSION" ]; then
    printf '%s' "$RELEASE_VERSION"
    return 0
  fi

  if [ -z "$RELEASE_VERSION_URL" ]; then
    return 1
  fi

  version_file="$(mktemp)"
  if ! download_url_to_file "$RELEASE_VERSION_URL" "$version_file"; then
    rm -f "$version_file"
    return 1
  fi

  target_version="$(tr -d '\r\n' < "$version_file")"
  rm -f "$version_file"
  if [ -z "$target_version" ]; then
    return 1
  fi

  printf '%s' "$target_version"
}

ensure_release_bundle() {
  if [ -z "$BUNDLE_URL" ]; then
    echo "RELEASE_BUNDLE_URL is not set." >&2
    exit 1
  fi

  target_version="$(resolve_target_version)"
  if [ -z "$target_version" ]; then
    echo "Failed to resolve target version." >&2
    exit 1
  fi

  current_marker=""
  current_version_marker=""
  current_bundle_version_value="$(current_bundle_version)"
  if [ -f "$BUNDLE_MARKER" ]; then
    current_marker="$(cat "$BUNDLE_MARKER")"
  fi
  if [ -f "$VERSION_MARKER" ]; then
    current_version_marker="$(cat "$VERSION_MARKER")"
  fi

  log "检查发布包。target_version=$target_version target_url=$BUNDLE_URL current_version=${current_bundle_version_value:-missing} current_version_marker=${current_version_marker:-missing}"

  if [ "$current_marker" = "$BUNDLE_URL" ] \
    && [ "$current_version_marker" = "$target_version" ] \
    && [ "$current_bundle_version_value" = "$target_version" ] \
    && [ -x "$CURRENT_ROOT/Microsoft365_E5_Renew_X" ]; then
    log "命中当前发布包缓存，继续使用现有版本 $target_version。"
    return
  fi

  log "当前发布包与目标版本不一致，开始重新下载并解压。"
  temp_dir="$(mktemp -d)"
  trap 'rm -rf "$temp_dir"' EXIT INT TERM

  if ! download_url_to_file "$BUNDLE_URL" "$temp_dir/release.tar.gz"; then
    log "发布包下载失败。url=$BUNDLE_URL"
    exit 1
  fi
  tar -xzf "$temp_dir/release.tar.gz" -C "$temp_dir"
  chmod +x "$temp_dir/Microsoft365_E5_Renew_X"

  extracted_version=""
  if [ -f "$temp_dir/release-version.txt" ]; then
    extracted_version="$(tr -d '\r\n' < "$temp_dir/release-version.txt")"
  fi

  if [ "$extracted_version" != "$target_version" ]; then
    log "下载到的发布包版本不匹配。expected=$target_version actual=${extracted_version:-missing}"
    exit 1
  fi

  rm -rf "$CURRENT_ROOT"
  mkdir -p "$CURRENT_ROOT"
  cp -R "$temp_dir"/. "$CURRENT_ROOT"/
  rm -rf "$CURRENT_ROOT/Deploy" "$CURRENT_ROOT/runtime"
  ln -s "$DEPLOY_DIR" "$CURRENT_ROOT/Deploy"
  ln -s "$APP_ROOT/runtime" "$CURRENT_ROOT/runtime"
  printf '%s' "$BUNDLE_URL" > "$BUNDLE_MARKER"
  printf '%s' "$target_version" > "$VERSION_MARKER"
  log "发布包已切换到版本 $target_version。"

  rm -rf "$temp_dir"
  trap - EXIT INT TERM
}

if [ -n "${USER_SECRET_JSON_B64:-}" ]; then
  printf '%s' "$USER_SECRET_JSON_B64" | base64 -d > "$DEPLOY_DIR/user-secret.json"
elif [ -n "${USER_SECRET_JSON:-}" ]; then
  printf '%s' "$USER_SECRET_JSON" > "$DEPLOY_DIR/user-secret.json"
elif [ ! -f "$DEPLOY_DIR/user-secret.json" ]; then
  cat > "$DEPLOY_DIR/user-secret.json" <<'EOF'
{"users":[],"settings":{"from_time":"08:00:00","to_time":"23:59:59","days":[0,1,2,3,4,5,6],"api_call_interval_min_seconds":1,"api_call_interval_max_seconds":1,"frontend_refresh_seconds":5}}
EOF
fi

if [ -n "${TOKEN_TXT_B64:-}" ]; then
  printf '%s' "$TOKEN_TXT_B64" | base64 -d > "$DEPLOY_DIR/token.txt"
elif [ -n "${TOKEN_TXT:-}" ]; then
  printf '%s' "$TOKEN_TXT" > "$DEPLOY_DIR/token.txt"
fi

export PORT="${PORT:-7860}"
export HOST="${HOST:-0.0.0.0}"
export ASPNETCORE_URLS="${ASPNETCORE_URLS:-http://${HOST}:${PORT}}"
export DOTNET_RUNNING_IN_CONTAINER="${DOTNET_RUNNING_IN_CONTAINER:-true}"
RESTART_FLAG="$APP_ROOT/runtime/restart.requested"
APP_PID=""

start_app() {
  log "启动应用进程，版本 $(current_bundle_version)。"
  "$CURRENT_ROOT/Microsoft365_E5_Renew_X" &
  APP_PID=$!
  log "应用进程已启动，pid=$APP_PID。"
}

stop_app() {
  reason="$1"
  if [ -z "${APP_PID:-}" ]; then
    return
  fi

  if ! kill -0 "$APP_PID" 2>/dev/null; then
    wait "$APP_PID" 2>/dev/null || true
    APP_PID=""
    return
  fi

  log "准备停止应用进程，原因=$reason，pid=$APP_PID。"
  kill "$APP_PID" 2>/dev/null || true

  waited=0
  while kill -0 "$APP_PID" 2>/dev/null; do
    waited=$((waited + 1))
    if [ "$waited" -ge 30 ]; then
      log "应用进程在 30 秒内未退出，执行强制终止。pid=$APP_PID。"
      kill -9 "$APP_PID" 2>/dev/null || true
      break
    fi

    sleep 1
  done

  wait "$APP_PID" 2>/dev/null || true
  APP_PID=""
}

child_exit_code() {
  if [ -z "${APP_PID:-}" ]; then
    printf '0'
    return
  fi

  if wait "$APP_PID"; then
    printf '0'
  else
    printf '%s' "$?"
  fi
}

ensure_release_bundle
start_app

while true; do
  reload_reason=""

  if [ -f "$RESTART_FLAG" ]; then
    rm -f "$RESTART_FLAG"
    reload_reason="manual-restart"
  else
    target_version="$(resolve_target_version 2>/dev/null || true)"
    current_version="$(current_bundle_version)"
    if [ -n "$target_version" ] && [ -n "$current_version" ] && [ "$target_version" != "$current_version" ]; then
      reload_reason="release-update:$current_version->$target_version"
    fi
  fi

  if [ -n "$reload_reason" ]; then
    stop_app "$reload_reason"
    ensure_release_bundle
    start_app
    sleep 1
    continue
  fi

  if ! kill -0 "$APP_PID" 2>/dev/null; then
    exit_code="$(child_exit_code)"
    log "应用进程退出，exit_code=$exit_code。"

    target_version="$(resolve_target_version 2>/dev/null || true)"
    current_version="$(current_bundle_version)"
    if [ -n "$target_version" ] && [ -n "$current_version" ] && [ "$target_version" != "$current_version" ]; then
      log "检测到进程退出后有新版本可用，准备拉取。target_version=$target_version current_version=$current_version"
      ensure_release_bundle
      start_app
      sleep 1
      continue
    fi

    exit "$exit_code"
  fi

  sleep "$RELEASE_POLL_INTERVAL_SECONDS"
done
