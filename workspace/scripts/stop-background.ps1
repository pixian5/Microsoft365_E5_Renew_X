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
    Write-Host '未找到 PID 文件，程序可能没有在后台运行。'
    exit 0
}

$PidText = (Get-Content $PidFile -ErrorAction SilentlyContinue | Select-Object -First 1).Trim()
if (-not $PidText) {
    Remove-Item $PidFile -Force -ErrorAction SilentlyContinue
    Write-Host 'PID 文件为空，已清理。'
    exit 0
}

$TargetPid = [int]$PidText
$Process = Get-Process -Id $TargetPid -ErrorAction SilentlyContinue
if (-not $Process) {
    Remove-Item $PidFile -Force -ErrorAction SilentlyContinue
    Write-Host "PID=$TargetPid 对应进程不存在，已清理 PID 文件。"
    exit 0
}

Stop-Process -Id $TargetPid -Force
Remove-Item $PidFile -Force -ErrorAction SilentlyContinue
Write-Host "后台进程已停止，PID=$TargetPid"
