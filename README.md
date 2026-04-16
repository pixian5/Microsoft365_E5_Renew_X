---
title: Microsoft365 E5 Renew X Next
sdk: docker
app_port: 7860
---

# Microsoft365 E5 Renew X Next

`Microsoft365 E5 Renew X Next` 是一个基于 `.NET 10` 的 Microsoft 365 E5 自动续订控制台项目。它在 `E5Renewer.Net` 核心能力之上，补了一层更适合长期运维的 Web 仪表盘、账户管理、运行日志、健康检查、配置落盘、重启生效、Docker/Hugging Face Space 发布链路。

这个仓库的定位不是“从零实现 E5 刷新逻辑”，而是把已有的续订引擎封装成一个更容易本地运行、远程托管、多人维护的管理端。

当前推荐流程已经切换为：

- 本地主要负责改代码、提交、推送
- GitHub Actions 负责构建 `linux-x64` 发布包并创建 Release
- Hugging Face Space 从 GitHub Release 拉取发布包并自动部署
- Windows、macOS、Linux 实体机如果要直接运行，优先使用 GitHub Release 解压后的发布目录

## 项目特性

- 多账户统一管理，可直接在 Web 页面里新增、修改、暂停、恢复账号。
- 支持账号级时间窗口与星期限制，也支持全局默认时间策略。
- 内置运行状态面板，可查看运行中、等待中、已停止账户以及最近运行日志。
- 提供 `/healthz` 健康检查接口，便于反向代理、容器平台、外部监控接入。
- 暴露底层 `E5Renewer` 的 `/api/v1/*` 能力，同时增加时间戳与 Bearer Token 保护。
- 支持本地直接运行、Docker 部署、GitHub Actions 打包发布、Hugging Face Space 同步。
- 在 macOS 下支持通过应用内触发服务重启，配置保存后更容易生效。

## 适用场景

- 你有多个 Microsoft 365 E5 账号，希望集中配置和观察运行状态。
- 你已经有 `tenant_id`、`client_id`、`client_secret` 或证书，希望减少手工维护 JSON 的成本。
- 你需要一个比原始 API 更直观的管理界面。
- 你希望把现成构建产物发布到服务器、Docker 或 Hugging Face Space。

## 技术结构

仓库主体是一个 ASP.NET Core Web 项目，核心结构如下：

```text
.
├── src/                         # 当前项目新增的配置、页面、运行时服务
├── wwwroot/                     # 静态资源
├── Deploy/                      # 运行时配置与密钥文件
├── runtime/                     # 运行日志、重启辅助文件
├── workspace/scripts/           # 构建、发布、运行、同步脚本
├── workspace/build/             # 构建与发布产物目录
├── workspace/research/          # 引入的上游研究/参考代码
└── Microsoft365_E5_Renew_X.csproj
```

几个关键目录说明：

- `src/Program.cs`
  当前程序入口。首页 HTML、Dashboard API、`/healthz` 和 `/dashboard/*` 都在这里注册。
- `src/Infrastructure/`
  放配置保存、运行历史、重启服务、Kestrel 监听等基础设施代码。
- `Deploy/user-secret.json`
  多账户配置主文件，程序最核心的外部输入。
- `Deploy/token.txt`
  底层 `/api/v1/*` 接口的 Bearer Token 文件。
- `workspace/research/E5Renewer.Net/`
  上游续订核心工程，被当前项目通过 `ProjectReference` 引用。

## 运行界面与接口概览

程序启动后主要提供两类能力：

### 1. 管理仪表盘

- `/`
  Web 首页，包含账户列表、统一设置、运行状态、历史日志和一键重启。
- `/dashboard/accounts`
  读取或保存账户配置。
- `/dashboard/settings`
  读取或保存统一设置。
- `/dashboard/history`
  查看最近运行日志，可按账户过滤。
- `/dashboard/summary`
  查看账户汇总信息。
- `/dashboard/restart`
  提交服务重启请求，使部分配置变更更快生效。

### 2. 底层续订 API

- `/api/v1/*`
  映射到底层 `E5Renewer` 控制器。
- 只允许 `appsettings.json` 中声明的 HTTP 方法，默认是 `GET` 和 `POST`。
- 需要 Bearer Token 认证。
- 需要带时间戳，且默认只接受 30 秒内的请求。
- 认证失败或时间戳不合法时，会返回伪装结果而不是直接暴露真实状态。

### 3. 健康检查

- `/healthz`
  返回运行健康状态、最近成功/失败计数、版本号等信息，适合被监控系统轮询。

## 环境要求

### 本地开发

- macOS / Linux / Windows 均可，仓库当前主要按 macOS 使用习惯整理。
- `.NET SDK 10.0.x`
- 可访问 Microsoft Graph 的网络环境

### 容器运行

- Docker
- 可从 GitHub Release 下载预编译发布包

## 快速开始

### 1. 克隆仓库

```bash
git clone https://github.com/pixian5/Microsoft365_E5_Renew_X.git
cd Microsoft365_E5_Renew_X
```

如果你的远端仓库地址不同，替换成自己的仓库即可。

### 2. 准备配置文件

复制示例文件：

```bash
cp Deploy/user-secret.json.example Deploy/user-secret.json
cp Deploy/token.txt.example Deploy/token.txt
```

然后编辑 `Deploy/user-secret.json` 与 `Deploy/token.txt`。

### 3. 本地开发构建

仓库已经自带脚本：

```bash
./workspace/scripts/build.sh
```

这个脚本会做几件事：

- 执行 `dotnet clean`
- 执行 `dotnet build -c Release`
- 清理历史构建里残留的无用目录
- 删除 `.pdb`、`.xml` 和 `.DS_Store`

### 4. 前台启动

```bash
./workspace/scripts/run.sh
```

默认监听地址来自 `appsettings.json`：

```json
"Runtime": {
  "Urls": [
    "http://127.0.0.1:51066"
  ]
}
```

也就是说，默认访问地址是：

- [http://127.0.0.1:51066](http://127.0.0.1:51066)

### 5. 后台启动

这个项目现在提供了适合实体机长期运行的后台脚本，默认会：

- 把进程 PID 写入 `runtime/app.pid`
- 把控制台输出写入 `runtime/history/console-时间戳.log`
- 避免重复启动同一个后台实例

macOS / Linux：

```bash
./workspace/scripts/start-background.sh
./workspace/scripts/status.sh
./workspace/scripts/stop-background.sh
```

Windows PowerShell：

```powershell
./workspace/scripts/start-background.ps1
./workspace/scripts/status.ps1
./workspace/scripts/stop-background.ps1
```

如果你运行的是 GitHub Release 解压后的发布目录，也可以直接用发布目录里的同名脚本：

- `start-background.sh`
- `stop-background.sh`
- `status.sh`
- `start-background.ps1`
- `stop-background.ps1`
- `status.ps1`

### 6. 推荐的日常发布方式

如果你的目标是部署到服务器或 Hugging Face，推荐流程不是本地 build，而是：

1. 本地修改代码。
2. 提交并推送到 GitHub。
3. GitHub Actions 自动创建新版本 Release。
4. GitHub Actions 自动同步 Hugging Face Space。
5. 服务器场景直接下载 GitHub Release 解压运行。

也就是说，日常维护时，本地更像“编辑端”，GitHub Actions 才是正式“构建端”。

### 7. 三平台实体机运行说明

#### macOS

推荐两种方式：

1. 开发态直接跑源码：
   安装 `.NET 10 SDK`，执行 `./workspace/scripts/build.sh`，再执行 `./workspace/scripts/start-background.sh`
2. 运维态跑发布包：
   下载 GitHub Release，解压后直接执行发布目录里的 `./start-background.sh`

常用命令：

- 后台运行：`./workspace/scripts/start-background.sh`
- 查看状态：`./workspace/scripts/status.sh`
- 查看日志：`tail -f runtime/history/console-*.log`

#### Linux

推荐直接使用 GitHub Release 发布包，解压后运行发布目录里的：

- `./start-background.sh`
- `./status.sh`
- `./stop-background.sh`

如果你确实要在 Linux 上从源码开发，再安装 `.NET 10 SDK` 后执行：

- `./workspace/scripts/build.sh`
- `./workspace/scripts/start-background.sh`
- `./workspace/scripts/status.sh`
- `./workspace/scripts/stop-background.sh`

如果是服务器场景，更推荐直接使用 GitHub Release 发布包，解压后运行发布目录中的后台脚本，而不是在服务器现编译源码。

#### Windows

推荐优先使用 GitHub Release 发布包。解压后在 PowerShell 中执行：

```powershell
./start-background.ps1
./status.ps1
./stop-background.ps1
```

如果你是本地开发，再安装 `.NET 10 SDK` 或对应运行时，用 PowerShell 进入仓库目录后执行构建：

```powershell
dotnet clean .\Microsoft365_E5_Renew_X.csproj -c Release
dotnet build .\Microsoft365_E5_Renew_X.csproj -c Release
```

4. 后台运行：

```powershell
./workspace/scripts/start-background.ps1
```

5. 查看状态或停止：

```powershell
./workspace/scripts/status.ps1
./workspace/scripts/stop-background.ps1
```

默认日志目录同样是 `runtime/history/`。

### 8. 验证

浏览器打开首页后，应该能看到：

- 账户列表
- 运行状态卡片
- 历史日志面板
- 设置按钮
- 重启服务按钮

命令行也可以验证：

```bash
curl http://127.0.0.1:51066/healthz
```

## `user-secret.json` 配置说明

当前项目在上游 `user-secret` 格式上做了 Dashboard 友好化封装，主结构如下：

```json
{
  "users": [
    {
      "name": "e5-account-01",
      "tenant_id": "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx",
      "client_id": "xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx",
      "secret": "your-client-secret",
      "certificate": null,
      "from_time": "08:00:00",
      "to_time": "23:59:59",
      "days": [1, 2, 3, 4, 5]
    }
  ],
  "passwords": {
    "<sha512sum>": "<certificate-password>"
  },
  "settings": {
    "from_time": "08:00:00",
    "to_time": "23:59:59",
    "days": [0, 1, 2, 3, 4, 5, 6],
    "api_call_interval_min_seconds": 1,
    "api_call_interval_max_seconds": 3,
    "frontend_refresh_seconds": 5
  }
}
```

字段说明：

- `users`
  账户列表。
- `users[].name`
  Dashboard 内显示的账号名称，建议唯一。
- `users[].tenant_id`
  Azure / Microsoft Entra 租户 ID。
- `users[].client_id`
  应用注册后的客户端 ID。
- `users[].secret`
  客户端密钥。若同时填写 `certificate`，通常会优先使用证书。
- `users[].certificate`
  证书文件路径，可替代 `secret`。
- `users[].from_time`
  允许执行的起始时间，支持类似 `08:00:00`、`08:00`、`8`。
- `users[].to_time`
  允许执行的结束时间，支持类似 `23:59:59`、`24:00`、`24`。
- `users[].days`
  允许执行的星期数组，遵循 .NET `DayOfWeek`：
  `0=Sunday, 1=Monday, 2=Tuesday, 3=Wednesday, 4=Thursday, 5=Friday, 6=Saturday`
- `passwords`
  证书密码映射，键是证书文件的 `sha512` 小写值。
- `settings`
  全局默认设置。保存统一设置时，程序会把运行时间和星期应用到全部账户，并把部分值写回 `appsettings.json`。
- `settings.api_call_interval_min_seconds`
  底层 Graph API 调用后的最小等待秒数，范围会被限制到 `1-3600` 秒。
- `settings.api_call_interval_max_seconds`
  底层 Graph API 调用后的最大等待秒数，范围会被限制到 `1-3600` 秒；若小于最小值，程序会自动交换。
- `settings.frontend_refresh_seconds`
  Dashboard 自动刷新间隔，范围会被限制到 `1-3600` 秒。

### 配置规范化行为

程序保存配置时会自动做一部分清洗：

- 去掉前后空格
- 统一时间格式为 `HH:mm:ss`
- 星期数组去重并排序
- 过滤空账号
- 将空的 `passwords` 视为 `null`

这意味着你可以在 Dashboard 里比较放心地编辑，不必担心格式越改越乱。

## `appsettings.json` 关键项

默认配置如下：

```json
{
  "Runtime": {
    "DashboardTitle": "Microsoft365 E5 Renew X Next",
    "ApiBasePath": "/api",
    "Urls": [
      "http://127.0.0.1:51066"
    ],
    "AllowedMethods": [
      "GET",
      "POST"
    ],
    "AllowedMaxAgeSeconds": 30,
    "DashboardRefreshSeconds": 5,
    "GraphApiIntervalMinSeconds": 10,
    "GraphApiIntervalMaxSeconds": 30,
    "UserSecretPath": "Deploy/user-secret.json",
    "TokenFilePath": "Deploy/token.txt"
  }
}
```

建议重点关注这些配置：

- `Runtime.DashboardTitle`
  页面标题。
- `Runtime.ApiBasePath`
  底层 API 的根路径，默认 `/api`。
- `Runtime.Urls`
  本地监听地址数组。
- `Runtime.AllowedMethods`
  API 允许的方法。
- `Runtime.AllowedMaxAgeSeconds`
  API 请求允许的最大时间偏差。
- `Runtime.DashboardRefreshSeconds`
  前端自动刷新秒数。
- `Runtime.GraphApiIntervalMinSeconds`
  后端每次调用 Graph 后的最小等待秒数。
- `Runtime.GraphApiIntervalMaxSeconds`
  后端每次调用 Graph 后的最大等待秒数。

部署到 Hugging Face Space 时，建议不要把这个区间压到很低；如果低于 `10` 秒，程序会自动抬到 `10` 秒以上，避免被平台按异常高频连接拦截。
- `Runtime.UserSecretPath`
  用户配置文件路径。
- `Runtime.TokenFilePath`
  Bearer Token 文件路径。

此外仓库还保留了一组 `LegacySite` 配置，用于兼容旧站点的一些历史字段与展示信息；当前项目会读取其中部分值，但主入口已经切换到新的 Dashboard。

## API 访问说明

### 鉴权要求

访问 `/api/v1/*` 时：

- 需要请求头 `Authorization: Bearer <token>`
- Token 默认从 `Deploy/token.txt` 第一行读取
- GET 请求需要带 `timestamp` 查询参数
- 时间戳必须在服务端允许窗口内，默认 30 秒

示例：

```bash
TOKEN="$(head -n 1 Deploy/token.txt)"
TS="$(python3 - <<'PY'
import time
print(int(time.time() * 1000))
PY
)"

curl \
  -H "Authorization: Bearer ${TOKEN}" \
  "http://127.0.0.1:51066/api/v1/list_apis?timestamp=${TS}"
```

常见接口可参考：

- `/api/v1/list_apis`
- `/api/v1/running_users`
- `/api/v1/waiting_users`
- `/api/v1/user_results?user=<name>&api_name=<api>`

更细的底层接口说明可继续看：

- [workspace/research/E5Renewer.Net/http-api.md](/Users/x/code/Microsoft365_E5_Renew_X/workspace/research/E5Renewer.Net/http-api.md)

## Docker 部署

仓库根目录的 `Dockerfile` 不是本地源码编译型，而是“下载 GitHub Release 里预编译发布包”的模式。优点是：

- Hugging Face Space 不需要现场编译整个 .NET 工程
- 仓库体积更轻
- 发布流程更稳定

### 运行方式

容器启动脚本会自动处理这些事情：

- 创建 `/app/Deploy`、`/app/runtime/history`
- 从环境变量写入 `Deploy/user-secret.json`
- 从环境变量写入 `Deploy/token.txt`
- 设置 `ASPNETCORE_URLS`

支持的环境变量：

- `USER_SECRET_JSON`
- `USER_SECRET_JSON_B64`
- `TOKEN_TXT`
- `TOKEN_TXT_B64`
- `PORT`
- `HOST`
- `ASPNETCORE_URLS`

### 本地示例

```bash
docker build \
  --build-arg RELEASE_BUNDLE_URL="https://github.com/<owner>/<repo>/releases/download/<tag>/Microsoft365_E5_Renew_X-<tag>.tar.gz" \
  -t microsoft365-e5-renew-x .

docker run --rm -p 7860:7860 \
  -e USER_SECRET_JSON="$(cat Deploy/user-secret.json)" \
  -e TOKEN_TXT="$(cat Deploy/token.txt)" \
  microsoft365-e5-renew-x
```

容器内默认监听 `7860` 端口。

## Hugging Face Space 部署

当前仓库已针对 Hugging Face Space 做过精简适配：

- 根 `README.md` 会作为项目总说明使用
- 发布时通过 GitHub Actions 先构建压缩包
- 再由同步脚本把轻量 Space 内容推送到 Hugging Face
- Space 构建时只下载发布包，不现场编译源码

需要的 Hugging Face Space Secrets：

- `USER_SECRET_JSON`
- `TOKEN_TXT`

可选地也可以传 Base64 版本，由入口脚本自行解码。

### 推荐的 Secret 托管方式

如果你不希望把真实账号配置放在本地仓库或手工粘贴到 Hugging Face，可以直接把运行配置放到 GitHub Secrets，再由 GitHub Actions 自动同步到 HF Space。

推荐在 GitHub 仓库里配置这些 Secrets：

- `HF_TOKEN`
- `HF_SPACE_ID`
- `USER_SECRET_JSON` 或 `USER_SECRET_JSON_B64`
- `TOKEN_TXT` 或 `TOKEN_TXT_B64`

这样做之后：

1. 真实的 `Tenant ID`、`Client ID`、`Client Secret` 只保存在 GitHub Secrets
2. 工作流发布时会先调用 Hugging Face API 更新 Space Secrets
3. 然后再同步 HF Space 仓库内容并触发部署
4. 容器启动时由 `docker/entrypoint.sh` 自动写入 `/app/Deploy/user-secret.json` 和 `/app/Deploy/token.txt`

也就是说，真实账户配置不会出现在源码仓库里，也不需要手工进 HF 页面重复维护。

## GitHub Actions 发布流程

工作流文件：

- [release-and-deploy-v2.yml](/Users/x/code/Microsoft365_E5_Renew_X/.github/workflows/release-and-deploy-v2.yml)

触发方式：

- 推送到 `main`
- 手工触发 `workflow_dispatch`

主要步骤：

1. 检出代码
2. 解析 [Directory.Build.props](/Users/x/code/Microsoft365_E5_Renew_X/workspace/research/E5Renewer.Net/Directory.Build.props) 中的版本号
3. 用 `linux-x64` 执行 `workspace/scripts/publish.sh`
4. 打包 `workspace/build/publish`
5. 创建或更新对应 Git tag 与 GitHub Release
6. 自动同步 Hugging Face Space
7. 自动触发 HF 重启，并等待新 runtime sha 与 Space sha 一致

GitHub Secrets：

- `HF_TOKEN`
- `HF_SPACE_ID`
- `USER_SECRET_JSON` 或 `USER_SECRET_JSON_B64`
- `TOKEN_TXT` 或 `TOKEN_TXT_B64`

如果这些 Secrets 配齐了，那么标准流程就是：

1. 改代码
2. `git commit`
3. `git push`
4. 等 GitHub Actions 自动完成 Release 与 HF 部署

## 构建与发布脚本

仓库内现有脚本：

- `workspace/scripts/build.sh`
  本地清理并构建 Release。
- `workspace/scripts/run.sh`
  直接运行 Release 配置。
- `workspace/scripts/publish.sh`
  生成可分发目录到 `workspace/build/publish`。
- `workspace/scripts/prepare-hf-space.sh`
  组装 Hugging Face Space 所需轻量文件。
- `workspace/scripts/sync-hf-space.sh`
  把轻量 Space 内容推送到 Hugging Face。

发布完成后，可执行文件入口在：

- `workspace/build/publish/Microsoft365_E5_Renew_X`

它本质上是一个包装脚本，会转发到：

- `workspace/build/publish/app/Microsoft365_E5_Renew_X`

## 本地运维建议

- 不要把真实的 `tenant_id`、`client_id`、`secret`、证书密码直接提交到公共仓库。
- `Deploy/user-secret.json` 与 `Deploy/token.txt` 更适合通过私有仓库、服务器环境变量或 CI Secret 管理。
- 如果你修改了统一设置里的接口间隔和前端刷新时间，程序会直接改写根目录 `appsettings.json`。
- 保存账号配置后，页面会提示需要重启；这是预期行为。
- `runtime/history/` 下会保留运行日志，排查问题时先看这里。
- macOS 下如果一键重启失败，程序会在 `runtime/restart.log` 里留下启动和回退信息。
- 现在更推荐让 GitHub Actions 负责正式构建；本地构建主要用于开发调试。

## 常见问题

### 1. 首页能打开，但账户一直为空

先检查：

- `Deploy/user-secret.json` 是否存在
- JSON 是否合法
- `users` 是否真的填了账号

### 2. `/api/v1/*` 一直返回看起来像假数据

大概率是下面其中一个原因：

- Bearer Token 不对
- 没带 `timestamp`
- 时间戳超过允许窗口
- 请求方法不在允许列表

### 3. 修改设置后为什么要求重启

因为部分配置需要重新初始化运行时服务，当前项目采用“保存后提示重启”的策略，而不是在内存里做复杂热更新。

### 4. 为什么仓库里还有 `LegacySite` 配置

这是从旧版本工程整理过来的兼容层，当前项目会读取部分值，但新的主入口和管理界面已经以 Dashboard 为中心。

## 开发说明

### 代码入口

- [src/Program.cs](/Users/x/code/Microsoft365_E5_Renew_X/src/Program.cs)
- [src/Configuration/AppOptions.cs](/Users/x/code/Microsoft365_E5_Renew_X/src/Configuration/AppOptions.cs)
- [src/Infrastructure/UserSecretManagementService.cs](/Users/x/code/Microsoft365_E5_Renew_X/src/Infrastructure/UserSecretManagementService.cs)
- [src/Infrastructure/DashboardSettingsService.cs](/Users/x/code/Microsoft365_E5_Renew_X/src/Infrastructure/DashboardSettingsService.cs)
- [src/Infrastructure/ApplicationRestartService.cs](/Users/x/code/Microsoft365_E5_Renew_X/src/Infrastructure/ApplicationRestartService.cs)

### 上游参考

- [workspace/research/E5Renewer.Net/README.md](/Users/x/code/Microsoft365_E5_Renew_X/workspace/research/E5Renewer.Net/README.md)

这个仓库已经把上游核心能力“包”进自己的运行壳层里，因此后续维护建议优先看当前项目入口和基础设施代码，再去追上游实现细节。

## 当前默认端口与路径

- 本地默认首页: [http://127.0.0.1:51066](http://127.0.0.1:51066)
- 本地默认健康检查: [http://127.0.0.1:51066/healthz](http://127.0.0.1:51066/healthz)
- 本地默认 API 根路径: [http://127.0.0.1:51066/api/v1](http://127.0.0.1:51066/api/v1)
- 容器默认端口: `7860`
- 用户配置文件: `Deploy/user-secret.json`
- Token 文件: `Deploy/token.txt`
- 运行历史目录: `runtime/history`
- 重启日志: `runtime/restart.log`

## 免责声明

本项目仅用于学习、研究和自动化运维测试。你需要自行确认：

- Microsoft Graph 应用权限配置是否合规
- 账户凭据和证书是否得到妥善保管
- 自动化调用频率是否符合你的使用边界

如果你准备长期使用，建议至少补上：

- 反向代理
- 外层鉴权
- 访问日志
- 备份策略
- Secret 管理方案
