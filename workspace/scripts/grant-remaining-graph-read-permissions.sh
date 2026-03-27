#!/usr/bin/env bash
set -euo pipefail

APP_ID="${1:-}"
GRAPH_APP_ID="00000003-0000-0000-c000-000000000000"

if [[ -z "$APP_ID" ]]; then
  echo "用法: $0 <app-id>" >&2
  echo "示例: $0 b94aa3ed-e89c-4bd7-a218-281fa054b988" >&2
  exit 1
fi

if ! command -v az >/dev/null 2>&1; then
  echo "未找到 Azure CLI: az" >&2
  exit 1
fi

# 这批权限对应当前保留下来、且仍可能通过补权限解决的只读接口。
# 已确认不适合 app-only 的接口，已经从代码里移除，不再继续申请。
PERMISSIONS=(
  "Policy.Read.All"
  "Policy.Read.AuthenticationMethod"
  "Domain-InternalFederation.Read.All"
)

resolve_role_id() {
  local permission_name="$1"
  az ad sp show \
    --id "$GRAPH_APP_ID" \
    --query "appRoles[?value=='${permission_name}' && contains(allowedMemberTypes, 'Application')].id | [0]" \
    -o tsv
}

echo "目标应用: $APP_ID"
echo "Microsoft Graph: $GRAPH_APP_ID"
echo

for permission_name in "${PERMISSIONS[@]}"; do
  role_id="$(resolve_role_id "$permission_name")"

  if [[ -z "$role_id" ]]; then
    echo "跳过 $permission_name: 未在当前租户的 Microsoft Graph 应用角色中找到。"
    continue
  fi

  echo "添加 $permission_name -> $role_id"
  az ad app permission add \
    --id "$APP_ID" \
    --api "$GRAPH_APP_ID" \
    --api-permissions "${role_id}=Role"
done

echo
echo "执行管理员同意"
az ad app permission admin-consent --id "$APP_ID"

echo
echo "当前 Microsoft Graph 权限清单:"
az ad app permission list --id "$APP_ID" -o table
