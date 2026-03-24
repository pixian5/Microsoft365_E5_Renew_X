using System.Reflection;
using System.Text;
using System.Text.Json;
using E5Renewer.Controllers;
using E5Renewer.Controllers.V1;
using E5Renewer.Models.Secrets;
using E5Renewer.Models.Statistics;
using Microsoft365_E5_Renew_X;
using Microsoft365_E5_Renew_X.Configuration;
using Microsoft365_E5_Renew_X.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
var runtimeHistory = new RuntimeHistoryService(builder.Environment.ContentRootPath);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();

var options = AppOptions.Bind(builder.Configuration, builder.Environment.ContentRootPath);
SystemConfig.Initialize(options, builder.Environment.ContentRootPath);

KestrelEndpointConfigurator.Configure(builder.WebHost, options);

var e5Assembly = Assembly.Load("E5Renewer");
var moduleAssemblies = ModuleDiscovery.Discover(e5Assembly).ToArray();

builder.Services.AddSingleton(options);
builder.Services.AddSingleton(runtimeHistory);
builder.Services.AddSingleton<IHostedService>(runtimeHistory);
builder.Services.AddSingleton<UserSecretManagementService>();
builder.Services.AddSingleton<DashboardSettingsService>();
builder.Services.AddSingleton<ApplicationRestartService>();
builder.Services.AddE5RenewerHost(moduleAssemblies, options.Runtime.UserSecretFile, options.Runtime.TokenFile);
builder.Logging.AddProvider(new RuntimeHistoryLoggerProvider(runtimeHistory));
builder.Services
    .AddControllers()
    .AddApplicationPart(typeof(JsonAPIV1Controller).Assembly)
    .AddJsonOptions(json =>
    {
        json.JsonSerializerOptions.TypeInfoResolverChain.Add(JsonAPIV1ResponseJsonSerializerContext.Default);
    });

var app = builder.Build();
string faviconPath = Path.Combine(app.Environment.ContentRootPath, "wwwroot", "favicon.svg");

app.RunModulesCheckers();

app.UseExceptionHandler(exceptionHandler =>
{
    exceptionHandler.Run(async context =>
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "application/json; charset=utf-8";
        await context.Response.WriteAsJsonAsync(new
        {
            message = "运行时发生异常",
            path = $"{context.Request.PathBase}{context.Request.Path}"
        });
    });
});

app.MapGet("/", () => Results.Content(RenderHome(options), "text/html; charset=utf-8"));

app.MapMethods("/favicon.ico", ["GET", "HEAD"], () =>
{
    if (!File.Exists(faviconPath))
    {
        return Results.NotFound();
    }

    return Results.File(faviconPath, "image/svg+xml");
});

app.MapMethods("/favicon.svg", ["GET", "HEAD"], () =>
{
    if (!File.Exists(faviconPath))
    {
        return Results.NotFound();
    }

    return Results.File(faviconPath, "image/svg+xml");
});

app.MapGet("/dashboard/accounts", async (UserSecretManagementService service, IStatusManager statusManager, CancellationToken cancellationToken) =>
{
    var document = await service.ReadAsync(cancellationToken);
    var stoppedUsers = new HashSet<string>(await statusManager.GetStoppedUsersAsync(), StringComparer.OrdinalIgnoreCase);
    var users = await Task.WhenAll(document.Users.Select(user => CloneWithResultCountsAsync(user, statusManager, stoppedUsers)));

    var response = new ManagedUserSecretDashboardResponse
    {
        Users = users.ToList(),
        Passwords = document.Passwords,
        Settings = document.Settings,
        RestartRequired = true,
        UserSecretFile = options.Runtime.UserSecretFile.FullName
    };

    return Results.Text(
        JsonSerializer.Serialize(response, ManagedUserSecretJsonSerializerContext.Default.ManagedUserSecretDashboardResponse),
        "application/json; charset=utf-8");
});

app.MapPost("/dashboard/accounts/stop-all", async (
    UserSecretManagementService service,
    IStatusManager statusManager,
    RuntimeHistoryService runtimeHistoryService,
    CancellationToken cancellationToken) =>
{
    var document = await service.ReadAsync(cancellationToken);
    string[] userNames = document.Users
        .Select(user => user.Name)
        .Where(name => !string.IsNullOrWhiteSpace(name))
        .Distinct(StringComparer.OrdinalIgnoreCase)
        .ToArray();

    string[] stoppedUsers = (await statusManager.GetStoppedUsersAsync()).ToArray();
    bool shouldStopAll = userNames.Any(name => !stoppedUsers.Contains(name, StringComparer.OrdinalIgnoreCase));

    foreach (string userName in userNames)
    {
        await statusManager.SetUserStoppedAsync(userName, shouldStopAll);
    }

    string message = shouldStopAll
        ? $"已停止全部账户，共 {userNames.Length} 个。"
        : $"已恢复全部账户，共 {userNames.Length} 个。";
    runtimeHistoryService.Add("Dashboard", shouldStopAll ? "Warning" : "Information", message);

    return Results.Json(new
    {
        message,
        stopped = shouldStopAll
    });
});

app.MapPost("/dashboard/accounts/{name}/stop", async (
    string name,
    HttpContext context,
    IStatusManager statusManager,
    RuntimeHistoryService runtimeHistoryService,
    CancellationToken cancellationToken) =>
{
    var payload = await JsonSerializer.DeserializeAsync(
        context.Request.Body,
        ManagedUserSecretJsonSerializerContext.Default.ManagedStopRequest,
        cancellationToken) ?? new ManagedStopRequest();

    await statusManager.SetUserStoppedAsync(name, payload.Stopped);
    string message = payload.Stopped ? $"账户 {name} 已停止。" : $"账户 {name} 已恢复。";
    runtimeHistoryService.Add("Dashboard", payload.Stopped ? "Warning" : "Information", message);

    return Results.Json(new
    {
        message,
        stopped = payload.Stopped
    });
});

app.MapPost("/dashboard/accounts", async (HttpContext context, UserSecretManagementService service, CancellationToken cancellationToken) =>
{
    var current = await service.ReadAsync(cancellationToken);
    var document = await JsonSerializer.DeserializeAsync(
        context.Request.Body,
        ManagedUserSecretJsonSerializerContext.Default.ManagedUserSecretDocument,
        cancellationToken) ?? new ManagedUserSecretDocument();

    document.Passwords ??= current.Passwords;
    document.Settings ??= current.Settings;

    var saved = await service.SaveAsync(document, cancellationToken);
    var response = new ManagedUserSecretSaveResponse
    {
        Message = "账户配置已保存到 user-secret.json",
        RestartRequired = true,
        Users = saved.Users,
        Settings = saved.Settings,
        UserSecretFile = options.Runtime.UserSecretFile.FullName
    };

    return Results.Text(
        JsonSerializer.Serialize(response, ManagedUserSecretJsonSerializerContext.Default.ManagedUserSecretSaveResponse),
        "application/json; charset=utf-8");
});

app.MapGet("/dashboard/settings", async (
    UserSecretManagementService service,
    DashboardSettingsService dashboardSettingsService,
    CancellationToken cancellationToken) =>
{
    var document = await service.ReadAsync(cancellationToken);
    var apiCallIntervalRange = await dashboardSettingsService.GetApiCallIntervalSecondsRangeAsync(cancellationToken);
    var settings = BuildSettingsResponse(
        document,
        apiCallIntervalRange.MinSeconds,
        apiCallIntervalRange.MaxSeconds,
        await dashboardSettingsService.GetFrontendRefreshSecondsAsync(cancellationToken));
    return Results.Json(settings);
});

app.MapPost("/dashboard/settings", async (
    HttpContext context,
    UserSecretManagementService service,
    DashboardSettingsService dashboardSettingsService,
    CancellationToken cancellationToken) =>
{
    var payload = await JsonSerializer.DeserializeAsync(
        context.Request.Body,
        ManagedUserSecretJsonSerializerContext.Default.ManagedGlobalSettings,
        cancellationToken) ?? new ManagedGlobalSettings();

    var document = await service.ReadAsync(cancellationToken);
    var normalizedSettings = NormalizeGlobalSettings(payload);
    document.Settings = normalizedSettings;
    document.Users = document.Users
        .Select(user => ApplyGlobalSettings(user, normalizedSettings))
        .ToList();

    var savedDocument = await service.SaveAsync(document, cancellationToken);
    var intervalRange = await dashboardSettingsService.SaveApiCallIntervalSecondsRangeAsync(
        normalizedSettings.ApiCallIntervalMinSeconds,
        normalizedSettings.ApiCallIntervalMaxSeconds,
        cancellationToken);
    int frontendRefreshSeconds = await dashboardSettingsService.SaveFrontendRefreshSecondsAsync(normalizedSettings.FrontendRefreshSeconds, cancellationToken);
    var settings = BuildSettingsResponse(savedDocument, intervalRange.MinSeconds, intervalRange.MaxSeconds, frontendRefreshSeconds);

    return Results.Json(new
    {
        message = "统一设置已保存。运行时间与星期已应用到全部账号；接口等待区间与前端自动刷新时间已写入 appsettings.json。",
        restart_required = true,
        settings
    });
});

app.MapPost("/dashboard/restart", (ApplicationRestartService restartService) =>
{
    runtimeHistory.Add("Dashboard", "Information", "用户从首页发起服务重启。");
    RestartRequestResult result = restartService.Restart();
    if (!result.Success)
    {
        runtimeHistory.Add("Dashboard", "Error", $"服务重启提交失败。方式={result.Method}，原因={result.Message}");
        return Results.Json(new
        {
            message = $"服务重启提交失败：{result.Message}",
            restarting = false,
            method = result.Method
        }, statusCode: StatusCodes.Status500InternalServerError);
    }

    return Results.Json(new
    {
        message = "服务正在重启，请等待几秒后刷新页面。",
        restarting = true,
        method = result.Method
    });
});

app.MapGet("/dashboard/history", (RuntimeHistoryService historyService, string? account) =>
{
    return Results.Json(new
    {
        account,
        entries = historyService.GetRecent(account)
    });
});

app.MapGet("/healthz", async (RuntimeHistoryService historyService, ISecretProvider secretProvider, IStatusManager statusManager) =>
{
    var runtimeHealth = historyService.EvaluateHealth(TimeSpan.FromMinutes(5));
    var secret = await secretProvider.GetUserSecretAsync();
    HashSet<string> stoppedUsers = new(await statusManager.GetStoppedUsersAsync(), StringComparer.OrdinalIgnoreCase);
    string[] validUserNames = secret.users
        .Where(user => user.valid && !string.IsNullOrWhiteSpace(user.name))
        .Select(user => user.name)
        .Distinct(StringComparer.OrdinalIgnoreCase)
        .ToArray();

    bool allStopped = validUserNames.Length > 0 && validUserNames.All(stoppedUsers.Contains);
    if (allStopped)
    {
        runtimeHealth = new RuntimeHealthState(
            "警告",
            "全部有效账户目前都已停止。",
            runtimeHealth.SuccessCount,
            runtimeHealth.FailureCount);
    }

    return Results.Json(new
    {
        status = "ok",
        name = options.Runtime.DashboardTitle,
        version = e5Assembly.GetName().Version?.ToString() ?? "unknown",
        runtime_status = runtimeHealth.Status,
        runtime_message = runtimeHealth.Message,
        recent_success_count = runtimeHealth.SuccessCount,
        recent_failure_count = runtimeHealth.FailureCount,
        evaluation_window_minutes = 5
    });
});

app.MapGet("/dashboard/summary", async (IStatusManager statusManager, ISecretProvider secretProvider) =>
{
    var secret = await secretProvider.GetUserSecretAsync();
    var runningUsers = (await statusManager.GetRunningUsersAsync()).ToArray();
    var waitingUsers = (await statusManager.GetWaitingUsersAsync()).ToArray();
    var stoppedUsers = (await statusManager.GetStoppedUsersAsync()).ToArray();

    return Results.Json(new
    {
        title = options.Runtime.DashboardTitle,
        api_base = $"{options.Runtime.ApiBasePath}/v1",
        user_secret_file = options.Runtime.UserSecretFile.FullName,
        token_file = options.Runtime.TokenFile?.FullName,
        total_users = secret.users.Count,
        valid_users = secret.users.Count(user => user.valid),
        running_users = runningUsers,
        waiting_users = waitingUsers,
        stopped_users = stoppedUsers,
        migrated_from_legacy = true,
        legacy = new
        {
            service_port = options.LegacySite.Service.Port,
            allow_register = options.LegacySite.ShareSite.System.AllowRegister,
            default_quota = options.LegacySite.ShareSite.System.DefaultQuota
        }
    });
});

app.Use(async (context, next) =>
{
    if (context.Request.Path.StartsWithSegments(options.Runtime.ApiBasePath, out var remaining))
    {
        context.Request.PathBase = context.Request.PathBase.Add(options.Runtime.ApiBasePath);
        context.Request.Path = remaining;
    }

    await next();
});

app.UseRouting();

app.Use(async (context, next) =>
{
    if (!context.Request.PathBase.StartsWithSegments(options.Runtime.ApiBasePath))
    {
        await next();
        return;
    }

    if (!options.Runtime.AllowedMethods.Contains(context.Request.Method, StringComparer.OrdinalIgnoreCase))
    {
        context.Response.StatusCode = StatusCodes.Status405MethodNotAllowed;
        await context.Response.WriteAsJsonAsync(new
        {
            message = "不支持的请求方法",
            allowed = options.Runtime.AllowedMethods
        });
        return;
    }

    await next();
});

app.Use(async (context, next) =>
{
    if (!context.Request.PathBase.StartsWithSegments(options.Runtime.ApiBasePath))
    {
        await next();
        return;
    }

    var timestamp = GetTimestamp(context);
    var now = context.RequestServices.GetRequiredService<IUnixTimestampGenerator>().GetUnixTimestamp();
    if (timestamp > 0 && now > timestamp && now - timestamp <= options.Runtime.AllowedMaxAgeSeconds * 1000)
    {
        await next();
        return;
    }

    context.Response.StatusCode = StatusCodes.Status403Forbidden;
    var dummy = await context.RequestServices.GetRequiredService<IDummyResultGenerator>().GenerateDummyResultAsync(context);
    await context.Response.WriteAsJsonAsync(dummy, JsonAPIV1ResponseJsonSerializerContext.Default.JsonAPIV1Response);
});

app.Use(async (context, next) =>
{
    if (!context.Request.PathBase.StartsWithSegments(options.Runtime.ApiBasePath))
    {
        await next();
        return;
    }

    var secretProvider = context.RequestServices.GetRequiredService<ISecretProvider>();
    var authorization = context.Request.Headers.Authorization.ToString();
    var expected = $"Bearer {await secretProvider.GetRuntimeTokenAsync()}";
    if (authorization == expected)
    {
        await next();
        return;
    }

    context.Response.StatusCode = StatusCodes.Status403Forbidden;
    var dummy = await context.RequestServices.GetRequiredService<IDummyResultGenerator>().GenerateDummyResultAsync(context);
    await context.Response.WriteAsJsonAsync(dummy, JsonAPIV1ResponseJsonSerializerContext.Default.JsonAPIV1Response);
});

app.MapControllers();

app.Run();

static long GetTimestamp(HttpContext context)
{
    if (HttpMethods.IsGet(context.Request.Method) &&
        context.Request.Query.TryGetValue("timestamp", out var values) &&
        long.TryParse(values, out var timestamp))
    {
        return timestamp;
    }

    return -1;
}

static async Task<ManagedUserSecretAccount> CloneWithResultCountsAsync(
    ManagedUserSecretAccount user,
    IStatusManager statusManager,
    IReadOnlySet<string> stoppedUsers)
{
    var summary = await statusManager.GetUserResultSummaryAsync(user.Name);

    return new ManagedUserSecretAccount
    {
        Name = user.Name,
        TenantId = user.TenantId,
        ClientId = user.ClientId,
        Secret = user.Secret,
        Certificate = user.Certificate,
        FromTime = user.FromTime,
        ToTime = user.ToTime,
        Days = user.Days is null ? null : [.. user.Days],
        SuccessCount = summary.SuccessCount,
        FailureCount = summary.FailureCount,
        IsStopped = !string.IsNullOrWhiteSpace(user.Name) && stoppedUsers.Contains(user.Name)
    };
}

static string RenderHome(AppOptions options)
{
    var html = $$"""
<!doctype html>
<html lang="zh-Hant">
<head>
  <meta charset="utf-8">
  <meta name="viewport" content="width=device-width, initial-scale=1">
  <title>{{options.Runtime.DashboardTitle}}</title>
  <style>
    :root { color-scheme: light; --bg: #eef4f8; --card: rgba(255,255,255,.85); --ink: #122133; --muted: #546477; --line: rgba(18,33,51,.12); --accent: #0f766e; --accent-2: #2563eb; --accent-soft: #dff6f2; --warn: #b45309; --danger: #b91c1c; --shadow: 0 24px 60px rgba(18,33,51,.10); }
    * { box-sizing: border-box; }
    body { margin: 0; font-family: "SF Pro Display", "PingFang TC", "Noto Sans TC", sans-serif; background: radial-gradient(circle at top left, #dff8ef 0, #eef4f8 38%, #e8eef8 100%); color: var(--ink); }
    main { max-width: 1280px; margin: 0 auto; padding: 32px 20px 72px; }
    .hero { background: linear-gradient(140deg, #0f766e, #2563eb 55%, #0f172a); color: #fff; border-radius: 30px; padding: 32px; box-shadow: 0 24px 60px rgba(15, 118, 110, 0.22); position: relative; overflow: hidden; }
    .hero::after { content: ""; position: absolute; inset: auto -12% -45% auto; width: 320px; height: 320px; border-radius: 999px; background: radial-gradient(circle, rgba(255,255,255,.28), rgba(255,255,255,0)); pointer-events: none; }
    .hero-head { display: flex; align-items: center; justify-content: space-between; gap: 16px; position: relative; z-index: 1; }
    .hero-actions { display: flex; align-items: center; gap: 10px; flex-wrap: wrap; justify-content: flex-end; }
    .hero h1 { margin: 10px 0 8px; font-size: clamp(28px, 4vw, 38px); }
    .hero p { margin: 0; font-size: 15px; opacity: 0.92; max-width: 760px; }
    .grid { display: grid; grid-template-columns: 1fr; gap: 18px; margin-top: 20px; align-items: start; }
    .card { background: var(--card); border: 1px solid var(--line); border-radius: 22px; padding: 22px; box-shadow: var(--shadow); backdrop-filter: blur(14px); }
    .card h2 { margin: 0 0 12px; font-size: 20px; }
    .muted { color: var(--muted); }
    code { background: #eff4fb; border-radius: 8px; padding: 2px 6px; }
    a { color: #0f766e; text-decoration: none; }
    .badge { display: inline-block; background: var(--accent-soft); color: var(--accent); border-radius: 999px; padding: 6px 10px; font-size: 12px; font-weight: 600; }
    .stats { display: grid; grid-template-columns: repeat(3, minmax(0, 1fr)); gap: 12px; margin-top: 18px; }
    .stat { background: rgba(255,255,255,.14); border: 1px solid rgba(255,255,255,.18); border-radius: 18px; padding: 16px; }
    .stat strong { display: block; font-size: 28px; margin-top: 6px; }
    .toolbar, .toolbar-right { display: flex; gap: 10px; flex-wrap: wrap; align-items: center; }
    .toolbar { justify-content: space-between; margin-bottom: 14px; }
    button, .button { border: 0; border-radius: 14px; padding: 11px 16px; font: inherit; cursor: pointer; transition: transform .18s ease, opacity .18s ease, background .18s ease; }
    button:hover, .button:hover { transform: translateY(-1px); }
    .primary { background: linear-gradient(135deg, var(--accent), var(--accent-2)); color: #fff; }
    .secondary { background: #ecf3ff; color: #1d4ed8; }
    .settings-btn { background: rgba(255,255,255,.16); color: #fff; box-shadow: inset 0 0 0 1px rgba(255,255,255,.18); }
    .settings-btn:hover { background: rgba(255,255,255,.24); }
    .danger { background: #fee2e2; color: var(--danger); }
    .ghost { background: #f4f7fb; color: var(--ink); }
    .restart { background: linear-gradient(135deg, #fff1c2, #ffd166); color: #7c4a03; box-shadow: inset 0 0 0 1px rgba(124, 74, 3, 0.08); }
    .restart:hover { background: linear-gradient(135deg, #ffe7a3, #ffc94d); }
    .table { width: 100%; border-collapse: collapse; overflow: hidden; }
    .table th, .table td { padding: 14px 12px; border-bottom: 1px solid var(--line); text-align: left; vertical-align: top; font-size: 14px; }
    .table th { color: var(--muted); font-weight: 600; }
    .table tr:last-child td { border-bottom: 0; }
    .account-trigger { background: transparent; border: 0; padding: 0; text-align: left; color: inherit; cursor: pointer; }
    .account-trigger strong { color: var(--accent-2); }
    .mono { font-family: "SF Mono", "JetBrains Mono", monospace; }
    .chip { display: inline-flex; align-items: center; gap: 6px; border-radius: 999px; padding: 4px 10px; font-size: 12px; font-weight: 600; }
    .chip.ok { background: #dcfce7; color: #166534; }
    .chip.warn { background: #fef3c7; color: #92400e; }
    .chip.bad { background: #fee2e2; color: #991b1b; }
    .chip.info { background: #dbeafe; color: #1d4ed8; }
    .empty { padding: 24px; border: 1px dashed var(--line); border-radius: 18px; color: var(--muted); text-align: center; }
    .panel-title { display: flex; justify-content: space-between; gap: 12px; align-items: center; margin-bottom: 12px; }
    form { display: grid; gap: 14px; }
    .form-grid { display: grid; grid-template-columns: repeat(2, minmax(0, 1fr)); gap: 12px; }
    .form-grid-3 { display: grid; grid-template-columns: repeat(3, minmax(0, 1fr)); gap: 12px; }
    label { display: grid; gap: 8px; font-size: 13px; color: var(--muted); }
    .field-head { display: flex; align-items: center; gap: 6px; flex-wrap: wrap; }
    input, textarea { width: 100%; border: 1px solid var(--line); border-radius: 14px; padding: 12px 14px; font: inherit; color: var(--ink); background: rgba(255,255,255,.92); }
    textarea { min-height: 92px; resize: vertical; }
    .hint { font-size: 12px; color: var(--muted); }
    .banner { border-radius: 16px; padding: 12px 14px; font-size: 14px; }
    .banner.info { background: #eff6ff; color: #1d4ed8; }
    .banner.success { background: #dcfce7; color: #166534; }
    .banner.error { background: #fee2e2; color: #991b1b; }
    .banner.warn { background: #fef3c7; color: #92400e; }
    .day-list { display: grid; grid-template-columns: repeat(7, minmax(0, 1fr)); gap: 8px; }
    .day-list label { display: flex; align-items: center; justify-content: center; gap: 6px; border: 1px solid var(--line); border-radius: 12px; padding: 10px 8px; background: #fff; color: var(--ink); }
    .day-list input { width: auto; }
    .small { font-size: 12px; }
    .modal-shell { position: fixed; inset: 0; display: none; align-items: center; justify-content: center; padding: 24px; background: rgba(15, 23, 42, 0.42); backdrop-filter: blur(8px); z-index: 40; }
    .modal-shell.open { display: flex; }
    .modal-card { width: min(920px, 100%); max-height: calc(100vh - 48px); overflow: auto; background: #fdfefe; border: 1px solid rgba(18,33,51,.08); border-radius: 28px; box-shadow: 0 30px 80px rgba(15,23,42,.24); padding: 24px; }
    .modal-head { display: flex; align-items: center; justify-content: space-between; gap: 12px; margin-bottom: 14px; }
    .modal-head h2 { margin: 0; }
    .close-btn { width: 42px; height: 42px; border-radius: 999px; background: #eff4fb; color: var(--ink); font-size: 22px; line-height: 1; }
    .runtime-grid { display: grid; grid-template-columns: repeat(4, minmax(0, 1fr)); gap: 12px; margin-top: 14px; }
    .runtime-item { border: 1px solid var(--line); border-radius: 16px; padding: 14px; background: rgba(255,255,255,.8); }
    .runtime-item .label { font-size: 12px; color: var(--muted); }
    .runtime-item .value { font-size: 24px; font-weight: 700; margin-top: 6px; }
    .runtime-list { margin-top: 12px; display: flex; flex-wrap: wrap; gap: 8px; }
    .runtime-meta { display: flex; gap: 10px; flex-wrap: wrap; margin-top: 12px; }
    .history-list { display: grid; gap: 10px; margin-top: 14px; }
    .history-item { border: 1px solid var(--line); border-radius: 16px; padding: 14px; background: rgba(255,255,255,.82); }
    .history-item.success { border-color: rgba(22, 101, 52, .22); background: linear-gradient(180deg, rgba(220,252,231,.96), rgba(255,255,255,.92)); }
    .history-item.failure { border-color: rgba(185, 28, 28, .22); background: linear-gradient(180deg, rgba(254,226,226,.98), rgba(255,255,255,.92)); }
    .history-item.ms-call { border-color: rgba(37, 99, 235, .28); background: linear-gradient(180deg, rgba(239,246,255,.92), rgba(255,255,255,.92)); }
    .history-item.ms-call.success { border-color: rgba(22, 101, 52, .22); background: linear-gradient(180deg, rgba(220,252,231,.96), rgba(255,255,255,.92)); }
    .history-item.ms-call.failure { border-color: rgba(185, 28, 28, .22); background: linear-gradient(180deg, rgba(254,226,226,.98), rgba(255,255,255,.92)); }
    .history-top { display: flex; gap: 8px; align-items: center; justify-content: space-between; flex-wrap: wrap; }
    .history-op { margin-top: 10px; font-size: 15px; font-weight: 700; color: #0f172a; }
    .history-message { margin-top: 8px; font-size: 14px; line-height: 1.5; white-space: pre-wrap; word-break: break-word; }
    .history-meta { display: flex; gap: 8px; flex-wrap: wrap; }
    .history-exception { margin-top: 8px; color: #991b1b; font-size: 13px; }
    @media (max-width: 980px) {
      .grid { grid-template-columns: 1fr; }
      .form-grid, .form-grid-3, .stats { grid-template-columns: 1fr; }
      .day-list { grid-template-columns: repeat(4, minmax(0, 1fr)); }
      .modal-card { padding: 18px; border-radius: 22px; }
      .runtime-grid { grid-template-columns: repeat(2, minmax(0, 1fr)); }
      .hero-head { flex-direction: column; align-items: flex-start; }
    }
    @media (max-width: 640px) {
      .runtime-grid { grid-template-columns: 1fr; }
    }
  </style>
</head>
<body>
  <main>
    <section class="hero">
      <div class="hero-head">
        <h1>{{options.Runtime.DashboardTitle}}</h1>
        <div class="hero-actions">
          <span class="chip info" id="runtimeVersion">版本 -</span>
          <span class="chip info" id="runtimeHealth">健康状态 -</span>
          <button class="settings-btn" type="button" id="openSettingsBtn">设置</button>
        </div>
      </div>
    </section>
    <section class="grid">
      <article class="card">
        <div class="panel-title">
          <h2>账户列表</h2>
          <div class="toolbar-right">
            <button class="secondary" type="button" id="refreshBtn">刷新</button>
            <button class="danger" type="button" id="stopAllBtn">全部停止</button>
            <button class="restart" type="button" id="restartBtn">立即重启服务使配置生效</button>
            <button class="primary" type="button" id="createBtn">新增账户</button>
          </div>
        </div>
        <div id="message"></div>
        <div id="accountsContainer" class="empty">正在加载账户列表...</div>
      </article>
    </section>
    <section class="grid">
      <article class="card">
        <div class="panel-title">
          <h2>历史详情</h2>
          <div class="toolbar-right">
            <div id="runtimeStatus" class="banner info">正在加载运行状态...</div>
            <button class="secondary" type="button" id="refreshRuntimeBtn">刷新状态</button>
          </div>
        </div>
        <div class="runtime-grid">
          <div class="runtime-item">
            <div class="label">总账户数</div>
            <div class="value" id="runtimeTotalUsers">-</div>
          </div>
          <div class="runtime-item">
            <div class="label">有效账户数</div>
            <div class="value" id="runtimeValidUsers">-</div>
          </div>
          <div class="runtime-item">
            <div class="label">运行中</div>
            <div class="value" id="runtimeRunningCount">-</div>
          </div>
          <div class="runtime-item">
            <div class="label">等待中</div>
            <div class="value" id="runtimeWaitingCount">-</div>
          </div>
        </div>
        <div style="margin-top:14px;">
          <div class="hint">运行中账户</div>
          <div class="runtime-list" id="runtimeRunningUsers"></div>
        </div>
        <div style="margin-top:14px;">
          <div class="hint">等待中账户</div>
          <div class="runtime-list" id="runtimeWaitingUsers"></div>
        </div>
        <div style="margin-top:16px;">
          <div class="panel-title">
            <h2 id="historyTitle">最近运行日志</h2>
            <div class="toolbar-right">
              <button class="secondary" type="button" id="refreshHistoryBtn">刷新日志</button>
              <button class="ghost" type="button" id="clearHistoryFilterBtn" style="display:none;">查看全部</button>
            </div>
          </div>
          <div id="historyList" class="history-list">
            <div class="empty">正在加载历史详情...</div>
          </div>
        </div>
        <div class="banner info">点击“新增账户”会弹出配置窗口；点击列表里的“编辑”也会进入同一个弹窗。保存后会直接写回配置文件。</div>
      </article>
    </section>
  </main>
  <div class="modal-shell" id="accountModal" aria-hidden="true">
    <div class="modal-card">
      <div class="modal-head">
        <div>
          <h2 id="editorTitle">新增账户</h2>
          <div class="hint">保存后会直接更新 <code>{{options.Runtime.UserSecretFile.FullName}}</code></div>
        </div>
        <button class="close-btn" type="button" id="closeModalBtn" aria-label="关闭">×</button>
      </div>
      <form id="accountForm">
        <input type="hidden" id="editingIndex" value="-1">
        <div class="form-grid">
          <label>
            <div class="field-head">
              <span>账户名</span>
              <span class="hint">：例如：e5-main</span>
            </div>
            <input id="name" placeholder="例如：e5-main">
          </label>
          <label>
            <div class="field-head">
              <span>Tenant ID</span>
              <span class="hint">：Azure 租户 ID</span>
            </div>
            <input id="tenant_id" placeholder="Azure 租户 ID">
          </label>
        </div>
        <div class="form-grid">
          <label>
            <div class="field-head">
              <span>Client ID</span>
              <span class="hint">：应用 Client ID</span>
            </div>
            <input id="client_id" placeholder="应用 Client ID">
          </label>
          <label>
            <div class="field-head">
              <span>Client Secret</span>
              <span class="hint">：应用密钥，可留空改用证书</span>
            </div>
            <input id="secret" placeholder="应用密钥，可留空改用证书">
          </label>
        </div>
        <label>
          <div class="field-head">
            <span>证书路径</span>
            <span class="hint">：/opt/e5/certs/app.pfx</span>
          </div>
          <input id="certificate" placeholder="/opt/e5/certs/app.pfx">
        </label>
        <div class="form-grid">
          <label>
            <div class="field-head">
              <span>开始时间</span>
              <span class="hint">：08:00:00 或 7</span>
            </div>
            <input id="from_time" placeholder="08:00:00 或 7">
          </label>
          <label>
            <div class="field-head">
              <span>结束时间</span>
              <span class="hint">：23:00:00 或 22</span>
            </div>
            <input id="to_time" placeholder="23:00:00 或 22">
          </label>
        </div>
        <div>
          <div class="hint" style="margin-bottom:8px;">运行星期，按 .NET `DayOfWeek`：0=周日，1=周一 ... 6=周六</div>
          <div class="day-list">
            <label><input type="checkbox" value="1" checked>周一</label>
            <label><input type="checkbox" value="2" checked>周二</label>
            <label><input type="checkbox" value="3" checked>周三</label>
            <label><input type="checkbox" value="4" checked>周四</label>
            <label><input type="checkbox" value="5" checked>周五</label>
            <label><input type="checkbox" value="6">周六</label>
            <label><input type="checkbox" value="0">周日</label>
          </div>
        </div>
        <div class="toolbar-right">
          <button class="ghost" type="button" id="resetBtn">清空表单</button>
          <button class="primary" type="submit" id="saveBtn">保存到配置文件</button>
          <button class="restart" type="submit" id="saveAndRestartBtn" data-submit-action="save-restart">保存并重启</button>
        </div>
        <div class="banner warn">保存后会直接覆盖 <code>{{options.Runtime.UserSecretFile.FullName}}</code>。如果要让续订后台任务读取新配置，请保存后重启服务。</div>
      </form>
    </div>
  </div>
  <div class="modal-shell" id="settingsModal" aria-hidden="true">
    <div class="modal-card">
      <div class="modal-head">
        <div>
          <h2>统一设置</h2>
          <div class="hint">这里可以一次设置所有账号的运行时间、运行星期、接口调用后的随机等待区间，以及账户列表/运行状态/历史详情的自动刷新时间。</div>
        </div>
        <button class="close-btn" type="button" id="closeSettingsModalBtn" aria-label="关闭">×</button>
      </div>
      <form id="settingsForm">
        <div class="form-grid">
          <label>统一开始时间
            <input id="settings_from_time" placeholder="08:00:00 或 8">
          </label>
          <label>统一结束时间
            <input id="settings_to_time" placeholder="23:00:00 或 23">
          </label>
        </div>
        <div class="form-grid">
          <label>每次调用完一个接口后的最小等待秒数
            <input id="settings_api_interval_min_seconds" type="number" min="1" max="3600" step="1" placeholder="1">
          </label>
          <label>每次调用完一个接口后的最大等待秒数
            <input id="settings_api_interval_max_seconds" type="number" min="1" max="3600" step="1" placeholder="1">
          </label>
        </div>
        <label>账户列表、运行状态、历史详情自动刷新秒数
          <input id="settings_frontend_refresh_seconds" type="number" min="1" max="3600" step="1" placeholder="5">
        </label>
        <div>
          <div class="hint" style="margin-bottom:8px;">统一运行星期，按 .NET `DayOfWeek`：0=周日，1=周一 ... 6=周六</div>
          <div class="day-list" id="settingsDayList">
            <label><input type="checkbox" value="1" checked>周一</label>
            <label><input type="checkbox" value="2" checked>周二</label>
            <label><input type="checkbox" value="3" checked>周三</label>
            <label><input type="checkbox" value="4" checked>周四</label>
            <label><input type="checkbox" value="5" checked>周五</label>
            <label><input type="checkbox" value="6">周六</label>
            <label><input type="checkbox" value="0">周日</label>
          </div>
        </div>
        <div class="toolbar-right">
          <button class="ghost" type="button" id="resetSettingsBtn">恢复工作日默认</button>
          <button class="primary" type="submit">保存统一设置</button>
        </div>
      </form>
    </div>
  </div>
  <script>
    const state = { users: [], selectedHistoryAccount: null, settings: null, accountsRefreshTimer: null, runtimeRefreshTimer: null, historyRefreshTimer: null };
    const messageEl = document.getElementById('message');
    const accountsContainer = document.getElementById('accountsContainer');
    const editorTitle = document.getElementById('editorTitle');
    const editingIndex = document.getElementById('editingIndex');
    const form = document.getElementById('accountForm');
    const dayInputs = Array.from(document.querySelectorAll('.day-list input[type="checkbox"]'));
    const accountModal = document.getElementById('accountModal');
    const settingsModal = document.getElementById('settingsModal');
    const settingsForm = document.getElementById('settingsForm');
    const settingsDayInputs = Array.from(document.querySelectorAll('#settingsDayList input[type="checkbox"]'));
    const runtimeStatus = document.getElementById('runtimeStatus');
    let shouldCloseModalFromBackdrop = false;
    let shouldCloseSettingsModalFromBackdrop = false;

    document.getElementById('refreshBtn').addEventListener('click', () => loadAccounts(true));
    document.getElementById('stopAllBtn').addEventListener('click', toggleStopAllAccounts);
    document.getElementById('refreshRuntimeBtn').addEventListener('click', () => loadRuntime(true));
    document.getElementById('refreshHistoryBtn').addEventListener('click', () => loadHistory(true, state.selectedHistoryAccount));
    document.getElementById('clearHistoryFilterBtn').addEventListener('click', () => {
      state.selectedHistoryAccount = null;
      loadHistory(true, null);
    });
    document.getElementById('restartBtn').addEventListener('click', restartService);
    document.getElementById('createBtn').addEventListener('click', () => openModalForCreate());
    document.getElementById('openSettingsBtn').addEventListener('click', openSettingsModal);
    document.getElementById('resetBtn').addEventListener('click', () => resetForm());
    document.getElementById('closeModalBtn').addEventListener('click', closeModal);
    document.getElementById('closeSettingsModalBtn').addEventListener('click', closeSettingsModal);
    document.getElementById('resetSettingsBtn').addEventListener('click', resetSettingsForm);
    form.addEventListener('submit', onSubmit);
    settingsForm.addEventListener('submit', onSettingsSubmit);
    accountModal.addEventListener('pointerdown', event => {
      shouldCloseModalFromBackdrop = event.target === accountModal;
    });
    accountModal.addEventListener('pointerup', event => {
      if (shouldCloseModalFromBackdrop && event.target === accountModal) {
        closeModal();
      }
      shouldCloseModalFromBackdrop = false;
    });
    accountModal.addEventListener('pointercancel', () => {
      shouldCloseModalFromBackdrop = false;
    });
    settingsModal.addEventListener('pointerdown', event => {
      shouldCloseSettingsModalFromBackdrop = event.target === settingsModal;
    });
    settingsModal.addEventListener('pointerup', event => {
      if (shouldCloseSettingsModalFromBackdrop && event.target === settingsModal) {
        closeSettingsModal();
      }
      shouldCloseSettingsModalFromBackdrop = false;
    });
    settingsModal.addEventListener('pointercancel', () => {
      shouldCloseSettingsModalFromBackdrop = false;
    });
    document.addEventListener('keydown', event => {
      if (event.key === 'Escape' && accountModal.classList.contains('open')) {
        closeModal();
      } else if (event.key === 'Escape' && settingsModal.classList.contains('open')) {
        closeSettingsModal();
      }
    });

    loadAccounts(false);
    loadSettings(false);
    loadRuntime(false);
    loadHistory(false, null);
    updateAutoRefreshTimers(5000);

    async function loadAccounts(showToast) {
      try {
        const response = await fetch('/dashboard/accounts');
        if (!response.ok) {
          throw new Error('读取账户配置失败');
        }

        const data = await response.json();
        state.users = Array.isArray(data.users) ? data.users : [];
        state.settings = data.settings || state.settings;
        updateStopAllButton();
        renderAccounts();
      } catch (error) {
        showMessage(error.message || '读取账户配置失败', 'error');
        accountsContainer.innerHTML = '<div class="empty">账户列表加载失败，请检查配置文件读写权限。</div>';
      }
    }

    async function loadSettings(showToast) {
      try {
        const response = await fetch('/dashboard/settings');
        if (!response.ok) {
          throw new Error('读取统一设置失败');
        }

        const data = await response.json();
        state.settings = data;
        applySettingsToForm(data);
        updateAutoRefreshTimers(Number(data.frontend_refresh_seconds || 5) * 1000);
        if (showToast) showMessage('已刷新统一设置。', 'success');
      } catch (error) {
        if (showToast) showMessage(error.message || '读取统一设置失败', 'error');
      }
    }

    async function loadRuntime(showToast) {
      try {
        const [summaryResponse, healthResponse] = await Promise.all([
          fetch('/dashboard/summary'),
          fetch('/healthz')
        ]);

        if (!summaryResponse.ok || !healthResponse.ok) {
          throw new Error('读取运行状态失败');
        }

        const summary = await summaryResponse.json();
        const health = await healthResponse.json();

        document.getElementById('runtimeTotalUsers').textContent = summary.total_users ?? '-';
        document.getElementById('runtimeValidUsers').textContent = summary.valid_users ?? '-';
        document.getElementById('runtimeRunningCount').textContent = Array.isArray(summary.running_users) ? summary.running_users.length : 0;
        document.getElementById('runtimeWaitingCount').textContent = Array.isArray(summary.waiting_users) ? summary.waiting_users.length : 0;
        document.getElementById('runtimeVersion').textContent = `版本 ${health.version || '-'}`;
        document.getElementById('runtimeHealth').textContent = `健康状态 ${health.runtime_status || '-'}`;
        document.getElementById('runtimeHealth').className = `chip ${health.runtime_status === '正常' ? 'ok' : health.runtime_status === '警告' ? 'warn' : 'bad'}`;
        renderRuntimeUsers('runtimeRunningUsers', summary.running_users, '运行中账户');
        renderRuntimeUsers('runtimeWaitingUsers', summary.waiting_users, '等待中账户');
        runtimeStatus.className = `banner ${health.runtime_status === '正常' ? 'success' : health.runtime_status === '警告' ? 'warn' : 'error'}`;
        runtimeStatus.textContent = `${health.runtime_message || '读取运行状态成功'} 最近刷新：${new Date().toLocaleTimeString('zh-TW', { hour12: false })}`;
        if (showToast) showMessage('已刷新程序运行情况。', 'success');
      } catch (error) {
        runtimeStatus.className = 'banner error';
        runtimeStatus.textContent = error.message || '读取运行状态失败';
        renderRuntimeUsers('runtimeRunningUsers', [], '运行中账户');
        renderRuntimeUsers('runtimeWaitingUsers', [], '等待中账户');
      }
    }

    async function loadHistory(showToast, account) {
      try {
        const targetAccount = account || null;
        const query = targetAccount ? `?account=${encodeURIComponent(targetAccount)}` : '';
        const response = await fetch(`/dashboard/history${query}`);
        if (!response.ok) {
          throw new Error('读取历史详情失败');
        }

        const data = await response.json();
        const entries = Array.isArray(data.entries) ? data.entries : [];
        renderHistory(entries, data.account || targetAccount);
        if (showToast) showMessage('已刷新历史详情。', 'success');
      } catch (error) {
        document.getElementById('historyList').innerHTML = '<div class="empty">历史详情加载失败。</div>';
      }
    }

    function renderRuntimeUsers(elementId, users, emptyLabel) {
      const target = document.getElementById(elementId);
      const list = Array.isArray(users) ? users : [];
      if (!list.length) {
        target.innerHTML = `<span class="chip warn">${emptyLabel}暂无数据</span>`;
        return;
      }
      target.innerHTML = list.map(user => `<span class="chip ok">${escapeHtml(user)}</span>`).join('');
    }

    function renderHistory(entries, account) {
      const target = document.getElementById('historyList');
      const title = document.getElementById('historyTitle');
      const clearButton = document.getElementById('clearHistoryFilterBtn');
      title.textContent = account ? `账户 ${account} 的运行历史` : '最近运行日志';
      clearButton.style.display = account ? 'inline-block' : 'none';
      if (!entries.length) {
        target.innerHTML = `<div class="empty">${account ? `账户 ${escapeHtml(account)} 暂时还没有历史记录。` : '最近还没有历史记录。'}</div>`;
        return;
      }

      target.innerHTML = entries.map(entry => {
        const time = entry.timestamp
          ? new Date(entry.timestamp).toLocaleString('zh-TW', { hour12: false })
          : '-';
        const historyClass = entry.outcome === '成功'
          ? 'success'
          : entry.outcome === '失败' || entry.level === 'Error' || entry.level === 'Critical'
            ? 'failure'
            : '';
        return `
          <article class="history-item ${entry.isMicrosoftCall ? 'ms-call' : ''} ${historyClass}">
            <div class="history-top">
              <div class="history-meta">
                <span class="chip info">${escapeHtml(time)}</span>
                ${entry.isMicrosoftCall ? '<span class="chip info">Microsoft Graph</span>' : `<span class="chip info">${escapeHtml(entry.category || 'Runtime')}</span>`}
                ${entry.account ? `<span class="chip ok">${escapeHtml(entry.account)}</span>` : ''}
              </div>
            </div>
            ${entry.operation ? `<div class="history-op">${escapeHtml(entry.operation)}</div>` : ''}
            <div class="history-message">${escapeHtml(entry.message || '')}</div>
            ${entry.exception ? `<div class="history-exception">${escapeHtml(entry.exception)}</div>` : ''}
          </article>`;
      }).join('');
    }

    function renderAccounts() {
      if (!state.users.length) {
        accountsContainer.innerHTML = '<div class="empty">当前还没有账户。点击右侧“新增账户”即可开始配置。</div>';
        return;
      }

      const rows = state.users.map((user, index) => {
        const valid = Boolean(user.name && user.tenant_id && user.client_id && (user.secret || user.certificate));
        const windowText = [user.from_time || '08:00:00', user.to_time || '16:00:00'].join(' - ');
        const actionLabel = user.is_stopped ? '启动' : '停止';
        const actionClass = user.is_stopped ? 'secondary' : 'danger';
        return `
          <tr>
            <td>
              <button class="account-trigger" type="button" data-account="${escapeHtml(user.name || '')}">
                <div><strong>${escapeHtml(user.name || '(未命名账户)')}</strong></div>
                <div class="small muted mono">${escapeHtml(user.tenant_id || '-')}</div>
              </button>
            </td>
            <td><span class="chip ${user.is_stopped ? 'warn' : valid ? 'ok' : 'bad'}">${user.is_stopped ? '已停止' : valid ? '可用' : '待补全'}</span></td>
            <td><span class="chip ok">${Number(user.success_count || 0)}</span></td>
            <td><span class="chip ${Number(user.failure_count || 0) > 0 ? 'bad' : 'info'}">${Number(user.failure_count || 0)}</span></td>
            <td>${escapeHtml(windowText)}</td>
            <td>
              <div class="toolbar-right">
                <button class="${actionClass}" type="button" data-action="stop" data-index="${index}">${actionLabel}</button>
                <button class="secondary" type="button" data-action="edit" data-index="${index}">编辑</button>
                <button class="danger" type="button" data-action="delete" data-index="${index}">删除</button>
              </div>
            </td>
          </tr>`;
      }).join('');

      accountsContainer.innerHTML = `
        <table class="table">
          <thead>
            <tr>
              <th>账户</th>
              <th>状态</th>
              <th>成功</th>
              <th>失败</th>
              <th>时间窗</th>
              <th>操作</th>
            </tr>
          </thead>
          <tbody>${rows}</tbody>
        </table>`;

      accountsContainer.querySelectorAll('button[data-action]').forEach(button => {
        button.addEventListener('click', () => {
          const index = Number(button.dataset.index);
          if (button.dataset.action === 'edit') {
            loadIntoForm(index);
          } else if (button.dataset.action === 'stop') {
            toggleStopAccount(index);
          } else {
            removeAccount(index);
          }
        });
      });

      accountsContainer.querySelectorAll('button[data-account]').forEach(button => {
        button.addEventListener('click', () => {
          const account = button.dataset.account || '';
          if (!account) return;
          state.selectedHistoryAccount = account;
          loadHistory(true, account);
        });
      });
    }

    function loadIntoForm(index) {
      const user = state.users[index];
      if (!user) return;
      editingIndex.value = String(index);
      editorTitle.textContent = `编辑账户 #${index + 1}`;
      document.getElementById('name').value = user.name || '';
      document.getElementById('tenant_id').value = user.tenant_id || '';
      document.getElementById('client_id').value = user.client_id || '';
      document.getElementById('secret').value = user.secret || '';
      document.getElementById('certificate').value = user.certificate || '';
      document.getElementById('from_time').value = user.from_time || '';
      document.getElementById('to_time').value = user.to_time || '';
      const selectedDays = new Set(Array.isArray(user.days) ? user.days.map(String) : ['1','2','3','4','5']);
      dayInputs.forEach(input => input.checked = selectedDays.has(input.value));
      openModal();
    }

    function resetForm() {
      editingIndex.value = '-1';
      editorTitle.textContent = '新增账户';
      form.reset();
      dayInputs.forEach(input => input.checked = ['1','2','3','4','5'].includes(input.value));
    }

    function openModalForCreate() {
      resetForm();
      openModal();
    }

    function openModal() {
      shouldCloseModalFromBackdrop = false;
      accountModal.classList.add('open');
      accountModal.setAttribute('aria-hidden', 'false');
      setTimeout(() => document.getElementById('name').focus(), 50);
    }

    function closeModal() {
      shouldCloseModalFromBackdrop = false;
      accountModal.classList.remove('open');
      accountModal.setAttribute('aria-hidden', 'true');
    }

    function openSettingsModal() {
      applySettingsToForm(state.settings);
      shouldCloseSettingsModalFromBackdrop = false;
      settingsModal.classList.add('open');
      settingsModal.setAttribute('aria-hidden', 'false');
      setTimeout(() => document.getElementById('settings_from_time').focus(), 50);
    }

    function closeSettingsModal() {
      shouldCloseSettingsModalFromBackdrop = false;
      settingsModal.classList.remove('open');
      settingsModal.setAttribute('aria-hidden', 'true');
    }

    async function removeAccount(index) {
      const user = state.users[index];
      if (!user) return;
      if (!confirm(`确定删除账户 ${user.name || '(未命名账户)'} 吗？`)) return;
      const nextUsers = state.users.filter((_, i) => i !== index);
      await saveUsers(nextUsers, '账户已删除。');
      resetForm();
    }

    async function onSubmit(event) {
      event.preventDefault();
      const submitAction = event.submitter?.dataset.submitAction || 'save';
      const index = Number(editingIndex.value);
      const payload = collectForm();
      const nextUsers = [...state.users];
      if (index >= 0 && index < nextUsers.length) {
        nextUsers[index] = payload;
      } else {
        nextUsers.push(payload);
      }
      const saved = await saveUsers(nextUsers, '账户配置已保存。');
      if (!saved) {
        return;
      }

      resetForm();
      closeModal();

      if (submitAction === 'save-restart') {
        await restartService();
      }
    }

    async function saveUsers(users, successMessage) {
      try {
        const response = await fetch('/dashboard/accounts', {
          method: 'POST',
          headers: { 'Content-Type': 'application/json' },
          body: JSON.stringify({ users, settings: state.settings })
        });
        if (!response.ok) {
          throw new Error('保存失败');
        }

        const data = await response.json();
        state.users = Array.isArray(data.users) ? data.users : [];
        state.settings = data.settings || state.settings;
        renderAccounts();
        showMessage(`${successMessage} 已写入配置文件，重启服务后后台任务会读取新配置。`, 'success');
        return true;
      } catch (error) {
        showMessage(error.message || '保存失败', 'error');
        return false;
      }
    }

    async function onSettingsSubmit(event) {
      event.preventDefault();
      const payload = collectSettingsForm();
      try {
        const response = await fetch('/dashboard/settings', {
          method: 'POST',
          headers: { 'Content-Type': 'application/json' },
          body: JSON.stringify(payload)
        });
        if (!response.ok) {
          throw new Error('保存统一设置失败');
        }

        const data = await response.json();
        state.settings = data.settings || payload;
        applySettingsToForm(state.settings);
        updateAutoRefreshTimers(Number(state.settings.frontend_refresh_seconds || 5) * 1000);
        await loadAccounts(false);
        showMessage(`${data.message} 如需让运行时间和星期立即影响后台调度，请重启服务。`, 'success');
        closeSettingsModal();
      } catch (error) {
        showMessage(error.message || '保存统一设置失败', 'error');
      }
    }

    async function restartService() {
      try {
        const response = await fetch('/dashboard/restart', { method: 'POST' });
        if (!response.ok) {
            throw new Error('发起重启失败');
        }
        showMessage('已经发起重启，请等待 3-5 秒后刷新页面。', 'success');
      } catch (error) {
        showMessage(error.message || '发起重启失败', 'error');
      }
    }

    async function toggleStopAllAccounts() {
      try {
        const response = await fetch('/dashboard/accounts/stop-all', { method: 'POST' });
        if (!response.ok) {
          throw new Error('批量切换账户状态失败');
        }

        const data = await response.json();
        await Promise.all([loadAccounts(false), loadRuntime(false), loadHistory(false, state.selectedHistoryAccount)]);
        showMessage(data.message || '批量切换账户状态完成。', 'success');
      } catch (error) {
        showMessage(error.message || '批量切换账户状态失败', 'error');
      }
    }

    async function toggleStopAccount(index) {
      const user = state.users[index];
      if (!user || !user.name) return;

      const nextStopped = !Boolean(user.is_stopped);
      try {
        const response = await fetch(`/dashboard/accounts/${encodeURIComponent(user.name)}/stop`, {
          method: 'POST',
          headers: { 'Content-Type': 'application/json' },
          body: JSON.stringify({ stopped: nextStopped })
        });
        if (!response.ok) {
          throw new Error(nextStopped ? '停止账户失败' : '启动账户失败');
        }

        const data = await response.json();
        await Promise.all([loadAccounts(false), loadRuntime(false), loadHistory(false, state.selectedHistoryAccount)]);
        showMessage(data.message || (nextStopped ? '账户已停止。' : '账户已恢复。'), 'success');
      } catch (error) {
        showMessage(error.message || (nextStopped ? '停止账户失败' : '启动账户失败'), 'error');
      }
    }

    function collectForm() {
      const days = dayInputs.filter(input => input.checked).map(input => Number(input.value));
      return {
        name: document.getElementById('name').value.trim(),
        tenant_id: document.getElementById('tenant_id').value.trim(),
        client_id: document.getElementById('client_id').value.trim(),
        secret: normalizeNullable(document.getElementById('secret').value),
        certificate: normalizeNullable(document.getElementById('certificate').value),
        from_time: normalizeNullable(document.getElementById('from_time').value),
        to_time: normalizeNullable(document.getElementById('to_time').value),
        days
      };
    }

    function normalizeNullable(value) {
      const trimmed = value.trim();
      return trimmed ? trimmed : null;
    }

    function resetSettingsForm() {
      document.getElementById('settings_from_time').value = '08:00:00';
      document.getElementById('settings_to_time').value = '16:00:00';
      document.getElementById('settings_api_interval_min_seconds').value = '1';
      document.getElementById('settings_api_interval_max_seconds').value = '1';
      document.getElementById('settings_frontend_refresh_seconds').value = '5';
      settingsDayInputs.forEach(input => input.checked = ['1', '2', '3', '4', '5'].includes(input.value));
    }

    function applySettingsToForm(settings) {
      const source = settings || {};
      document.getElementById('settings_from_time').value = source.from_time || '08:00:00';
      document.getElementById('settings_to_time').value = source.to_time || '16:00:00';
      const minSeconds = Number(source.api_call_interval_min_seconds || source.api_call_interval_seconds || 1);
      const maxSeconds = Number(source.api_call_interval_max_seconds || source.api_call_interval_seconds || minSeconds || 1);
      document.getElementById('settings_api_interval_min_seconds').value = String(minSeconds);
      document.getElementById('settings_api_interval_max_seconds').value = String(maxSeconds);
      document.getElementById('settings_frontend_refresh_seconds').value = String(Number(source.frontend_refresh_seconds || 5));
      const selectedDays = new Set(Array.isArray(source.days) && source.days.length ? source.days.map(String) : ['1', '2', '3', '4', '5']);
      settingsDayInputs.forEach(input => input.checked = selectedDays.has(input.value));
    }

    function collectSettingsForm() {
      const days = settingsDayInputs.filter(input => input.checked).map(input => Number(input.value));
      const minSeconds = Math.max(1, Number(document.getElementById('settings_api_interval_min_seconds').value || '1'));
      const maxSeconds = Math.max(1, Number(document.getElementById('settings_api_interval_max_seconds').value || String(minSeconds)));
      return {
        from_time: normalizeNullable(document.getElementById('settings_from_time').value),
        to_time: normalizeNullable(document.getElementById('settings_to_time').value),
        days: days.length ? days : [1, 2, 3, 4, 5],
        api_call_interval_min_seconds: Math.min(minSeconds, maxSeconds),
        api_call_interval_max_seconds: Math.max(minSeconds, maxSeconds),
        frontend_refresh_seconds: Math.max(1, Number(document.getElementById('settings_frontend_refresh_seconds').value || '5'))
      };
    }

    function updateAutoRefreshTimers(milliseconds) {
      const interval = Math.max(1000, Number(milliseconds) || 5000);
      if (state.accountsRefreshTimer) clearInterval(state.accountsRefreshTimer);
      if (state.runtimeRefreshTimer) clearInterval(state.runtimeRefreshTimer);
      if (state.historyRefreshTimer) clearInterval(state.historyRefreshTimer);
      state.accountsRefreshTimer = setInterval(() => loadAccounts(false), interval);
      state.runtimeRefreshTimer = setInterval(() => loadRuntime(false), interval);
      state.historyRefreshTimer = setInterval(() => loadHistory(false, state.selectedHistoryAccount), interval);
    }

    function showMessage(text, kind) {
      messageEl.innerHTML = `<div class="banner ${kind}">${escapeHtml(text)}</div>`;
    }

    function updateStopAllButton() {
      const stopAllButton = document.getElementById('stopAllBtn');
      const activeUsers = state.users.filter(user => user.name);
      const allStopped = activeUsers.length > 0 && activeUsers.every(user => Boolean(user.is_stopped));
      stopAllButton.textContent = allStopped ? '全部启动' : '全部停止';
      stopAllButton.className = allStopped ? 'secondary' : 'danger';
    }

    function escapeHtml(text) {
      return String(text)
        .replaceAll('&', '&amp;')
        .replaceAll('<', '&lt;')
        .replaceAll('>', '&gt;')
        .replaceAll('"', '&quot;')
        .replaceAll("'", '&#39;');
    }
  </script>
</body>
</html>
""";

    return html;
}

static ManagedGlobalSettings BuildSettingsResponse(ManagedUserSecretDocument document, int apiCallIntervalMinSeconds, int apiCallIntervalMaxSeconds, int frontendRefreshSeconds)
{
    ManagedGlobalSettings settings = document.Settings ?? DeriveSettingsFromUsers(document.Users);
    settings.ApiCallIntervalMinSeconds = Math.Clamp(apiCallIntervalMinSeconds, 1, 3600);
    settings.ApiCallIntervalMaxSeconds = Math.Clamp(apiCallIntervalMaxSeconds, 1, 3600);
    settings.FrontendRefreshSeconds = Math.Clamp(frontendRefreshSeconds, 1, 3600);
    return NormalizeGlobalSettings(settings);
}

static ManagedGlobalSettings DeriveSettingsFromUsers(IReadOnlyList<ManagedUserSecretAccount> users)
{
    ManagedUserSecretAccount? firstUser = users.FirstOrDefault();
    return new ManagedGlobalSettings
    {
        FromTime = firstUser?.FromTime ?? "08:00:00",
        ToTime = firstUser?.ToTime ?? "16:00:00",
        Days = firstUser?.Days is { Count: > 0 } ? [.. firstUser.Days] : [1, 2, 3, 4, 5],
        ApiCallIntervalMinSeconds = 1,
        ApiCallIntervalMaxSeconds = 1,
        FrontendRefreshSeconds = 5
    };
}

static ManagedGlobalSettings NormalizeGlobalSettings(ManagedGlobalSettings settings)
{
    int apiCallIntervalMinSeconds = Math.Clamp(settings.ApiCallIntervalMinSeconds, 1, 3600);
    int apiCallIntervalMaxSeconds = Math.Clamp(settings.ApiCallIntervalMaxSeconds, 1, 3600);
    if (apiCallIntervalMaxSeconds < apiCallIntervalMinSeconds)
    {
        (apiCallIntervalMinSeconds, apiCallIntervalMaxSeconds) = (apiCallIntervalMaxSeconds, apiCallIntervalMinSeconds);
    }

    return new ManagedGlobalSettings
    {
        FromTime = NormalizeDashboardTime(settings.FromTime, false) ?? "08:00:00",
        ToTime = NormalizeDashboardTime(settings.ToTime, true) ?? "16:00:00",
        Days = settings.Days?.Distinct().Order().ToList() is { Count: > 0 } days ? days : [1, 2, 3, 4, 5],
        ApiCallIntervalMinSeconds = apiCallIntervalMinSeconds,
        ApiCallIntervalMaxSeconds = apiCallIntervalMaxSeconds,
        FrontendRefreshSeconds = Math.Clamp(settings.FrontendRefreshSeconds, 1, 3600)
    };
}

static ManagedUserSecretAccount ApplyGlobalSettings(ManagedUserSecretAccount user, ManagedGlobalSettings settings)
{
    return new ManagedUserSecretAccount
    {
        Name = user.Name,
        TenantId = user.TenantId,
        ClientId = user.ClientId,
        Secret = user.Secret,
        Certificate = user.Certificate,
        FromTime = settings.FromTime,
        ToTime = settings.ToTime,
        Days = settings.Days is null ? null : [.. settings.Days],
        SuccessCount = user.SuccessCount,
        FailureCount = user.FailureCount
    };
}

static string? NormalizeDashboardTime(string? value, bool isEndTime)
{
    string? trimmed = string.IsNullOrWhiteSpace(value) ? null : value.Trim();
    if (trimmed is null)
    {
        return null;
    }

    if (int.TryParse(trimmed, out int hourOnly))
    {
        if (hourOnly is >= 0 and <= 23)
        {
            return new TimeOnly(hourOnly, 0, 0).ToString("HH:mm:ss");
        }

        if (hourOnly == 24)
        {
            return isEndTime ? "23:59:59" : "00:00:00";
        }
    }

    if (trimmed is "24:00" or "24:00:00")
    {
        return isEndTime ? "23:59:59" : "00:00:00";
    }

    if (TimeOnly.TryParse(trimmed, out TimeOnly parsed))
    {
        return parsed.ToString("HH:mm:ss");
    }

    return trimmed;
}
