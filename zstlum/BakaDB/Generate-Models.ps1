param(
    [Parameter(Mandatory = $false)]
    [string[]]$Tables = @("dbo.zaci", "dbo.tridy", "dbo.organiz", "dbo.ucitele")
)

# Get the connection string from appsettings.json
$appSettingsPath = Join-Path $PSScriptRoot 'appsettings.json'
if (-not (Test-Path $appSettingsPath)) {
    throw "Could not find appsettings.json at '$appSettingsPath'."
}

$appSettings = Get-Content -Path $appSettingsPath -Raw | ConvertFrom-Json
$connectionString = $appSettings.ConnectionStrings.Bakalari
if ([string]::IsNullOrWhiteSpace($connectionString)) {
    throw "Connection string 'ConnectionStrings:Bakalari' was not found in appsettings.json."
}

# Install EF Core tools if not already installed
dotnet tool install dotnet-ef

# Generate models using scaffold command
$tableArgs = $Tables | ForEach-Object { "--table", $_ }
dotnet ef dbcontext scaffold $connectionString Microsoft.EntityFrameworkCore.SqlServer `
    --project "$PSScriptRoot" `
    --output-dir "$PSScriptRoot/Generated" `
    --namespace "BakaDB" `
    $tableArgs `
    --force `
    --no-pluralize `
    --no-onconfiguring
