dotnet build

if ($LASTEXITCODE -eq 0) {
    Write-Host "Build succeeded. Proceeding with EF Core migration and database update." -ForegroundColor Green
    dotnet ef migrations add InitialMigration
    dotnet ef database update
} else {
    Write-Host "Build failed. Please check the build errors." -ForegroundColor Red
}