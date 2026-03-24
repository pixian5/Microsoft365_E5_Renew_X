$ErrorActionPreference = 'Stop'

$ScriptRootResolved = (Resolve-Path $PSScriptRoot).Path
if ((Test-Path (Join-Path $ScriptRootResolved 'app')) -or (Test-Path (Join-Path $ScriptRootResolved 'Microsoft365_E5_Renew_X'))) {
    $Root = $ScriptRootResolved
    $DefaultAppDir = Join-Path $Root 'app'
}
else {
    $Root = (Resolve-Path (Join-Path $PSScriptRoot '../..')).Path
    $DefaultAppDir = Join-Path $Root 'bin/Release/net10.0'
}

$AppDir = if ($env:APP_DIR) { $env:APP_DIR } else { $DefaultAppDir }
$RuntimeDir = if ($env:RUNTIME_DIR) { $env:RUNTIME_DIR } else { Join-Path $Root 'runtime' }
$LogDir = Join-Path $RuntimeDir 'history'
$PidFile = Join-Path $RuntimeDir 'app.pid'
$Timestamp = Get-Date -Format 'yyyyMMdd-HHmmss'
$LogFile = Join-Path $LogDir "console-$Timestamp.log"

New-Item -ItemType Directory -Force -Path $LogDir | Out-Null

if (Test-Path $PidFile) {
    $OldPid = (Get-Content $PidFile -ErrorAction SilentlyContinue | Select-Object -First 1).Trim()
    if ($OldPid) {
        $Running = Get-Process -Id ([int]$OldPid) -ErrorAction SilentlyContinue
        if ($Running) {
            Write-Host "程序已在后台运行，PID=$OldPid"
            exit 0
        }
    }

    Remove-Item $PidFile -Force -ErrorAction SilentlyContinue
}

$ExePath = Join-Path $AppDir 'Microsoft365_E5_Renew_X.exe'
$DllPath = Join-Path $AppDir 'Microsoft365_E5_Renew_X.dll'

if (Test-Path $ExePath) {
    $FilePath = $ExePath
    $ArgumentList = @()
}
elseif (Test-Path $DllPath) {
    $FilePath = 'dotnet'
    $ArgumentList = @($DllPath)
}
else {
    throw "未找到可运行产物，请先执行构建：$AppDir"
}

$Process = Start-Process -FilePath $FilePath -ArgumentList $ArgumentList -WorkingDirectory $Root -WindowStyle Hidden -RedirectStandardOutput $LogFile -RedirectStandardError $LogFile -PassThru
$Process.Id | Set-Content -Path $PidFile -NoNewline

Write-Host "后台启动成功，PID=$($Process.Id)"
Write-Host "日志文件：$LogFile"
