<#
.SYNOPSIS
  Drops the dev database and reapplies EF Core migrations (destructive).

.DESCRIPTION
  Uses the connection string from MyApp.Api (startup project). Intended for local development only.
  All data in the target database is permanently deleted.

.PARAMETER Force
  Omitting this flag exits immediately with an error (no interactive prompt).
.EXAMPLE
  .\scripts\Reset-DevDatabase.ps1 -Force
#>
[CmdletBinding()]
param(
    [switch] $Force
)

if (-not $Force.IsPresent)
{
    Write-Error "This script deletes all data in the configured database. Re-run with -Force to proceed."
    exit 2
}

$ErrorActionPreference = "Stop"

$repoRoot = Split-Path -Parent $PSScriptRoot
Set-Location $repoRoot

$efArgs = @(
    "--project", "MyApp.Infrastructure",
    "--startup-project", "MyApp.Api"
)

Write-Warning "DESTRUCTIVE: Dropping database defined by ConnectionStrings:DefaultConnection, then running migrations."
& dotnet ef database drop @efArgs --force
if ($LASTEXITCODE -ne 0) {
    Write-Host "Drop exited with code $LASTEXITCODE (OK if database was already missing)." -ForegroundColor Yellow
}

& dotnet ef database update @efArgs
if ($LASTEXITCODE -ne 0) {
    exit $LASTEXITCODE
}

Write-Host "Database reset complete." -ForegroundColor Green
