$ErrorActionPreference = 'Stop'

$ScriptRootResolved = (Resolve-Path $PSScriptRoot).Path
if ((Test-Path (Join-Path $ScriptRootResolved 'app')) -or (Test-Path (Join-Path $ScriptRootResolved 'Microsoft365_E5_Renew_X'))) {
    $Root = $ScriptRootResolved
}
else {
    $Root = (Resolve-Path (Join-Path $PSScriptRoot '../..')).Path
}

$RuntimeDir = if ($env:RUNTIME_DIR) { $env:RUNTIME_DIR } else { Join-Path $Root 'runtime' }
$PidFile = Join-Path $RuntimeDir 'app.pid'

if (-not (Test-Path $PidFile)) {
    Write-Host '状态：未运行'
    exit 0
}

$PidText = (Get-Content $PidFile -ErrorAction SilentlyContinue | Select-Object -First 1).Trim()
if (-not $PidText) {
    Write-Host '状态：未运行'
    exit 0
}

$TargetPid = [int]$PidText
$Process = Get-Process -Id $TargetPid -ErrorAction SilentlyContinue
if ($Process) {
    Write-Host "状态：运行中，PID=$TargetPid"
}
else {
    Write-Host '状态：未运行（PID 文件已过期）'
}
