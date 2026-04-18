# This script is used to publish the App for different runtimes.
# It uses the configuration from publish.json to determine target framework, runtimes, and projects.

# Get the repository root (parent of the 'scripts' directory)
$repoRoot = Split-Path -Parent $PSScriptRoot

# Load configuration from publish.json
$configPath = Join-Path $PSScriptRoot "publish.json"
if (!(Test-Path $configPath)) {
    Write-Error "Could not find configuration at $configPath"
    exit 1
}
$config = Get-Content $configPath | ConvertFrom-Json
$appsDirectory = "C:\Apps"

# Move to repo root for dotnet commands
Push-Location $repoRoot

Write-Output "Starting build process in $repoRoot..."
dotnet clean
dotnet restore
dotnet build

foreach ($publishItem in $config.profiles) {
    $project = $publishItem.project
    $runtimes = $publishItem.runtimes
    $targetFramework = $publishItem.targetFramework
    $selfContained = if ($publishItem.selfContained) { "--self-contained" } else { "--no-self-contained" }
    $type = if ($publishItem.type) { $publishItem.type } else { "src" }

    # Project path is relative to repo root
    $projectPath = Join-Path $type $project "$project.csproj"

    $outputBase = "$appsDirectory\$project"

    foreach ($runtime in $runtimes) {
        Write-Output "Publishing $project for $runtime..."
        # Strip prefixes for output folder
        $runtimeSuffix = $runtime.Replace('win-', '').Replace('linux-', '')
        dotnet publish $projectPath -c Release -o "$outputBase\$runtimeSuffix" -r $runtime -f $targetFramework $selfContained
    }

    if ($publishItem.withAppLauncher) {
        # Copy AppLauncher and rename it to the app name
        $appLauncherSource = "$appsDirectory\AppLauncher\x64\AppLauncher.exe"
        $appLauncherTarget = "$appsDirectory\$project\$project.exe"

        if (Test-Path $appLauncherSource) {
            Write-Output "Copying AppLauncher to $appLauncherTarget..."
            if (!(Test-Path "$appsDirectory\$project")) {
                New-Item -ItemType Directory -Path "$appsDirectory\$project" -Force
            }
            Copy-Item -Path $appLauncherSource -Destination $appLauncherTarget -Force
            Write-Output "Launcher ready: $appLauncherTarget"
        }
        else {
            Write-Warning "AppLauncher not found at $appLauncherSource"
        }
    }
}

# Return to original location
Pop-Location
Set-Location $PSScriptRoot
