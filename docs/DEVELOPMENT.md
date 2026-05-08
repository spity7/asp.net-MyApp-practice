# Local development and secrets

## Configuration

- **`appsettings.json`** stores non-secret defaults. **Do not commit production connection strings, API keys, or certificates.**
- For local overrides, use **User Secrets** (right-click the API project → Manage User Secrets in Visual Studio), or environment variables on the machine or container.
- **Connection strings** belong in `ConnectionStrings:DefaultConnection`. For SQL Server LocalDB or Windows auth, your current sample is fine for a dev machine.
- **External API endpoints** are under `ExternalApis:Mocki` and `ExternalApis:Joke`. Change base addresses or paths there when vendors move without recompiling.

## Health and diagnostics

- **Liveness / readiness:** GET `https://localhost:{port}/health` — includes a **database** check when the app can reach SQL Server.
- **OpenAPI / Swagger:** Available in the **Development** environment only (see `Program.cs`).

## Testing

- Validator unit tests live in `MyApp.Application.Tests`. Run with `dotnet test` from the repository root or point to the solution file.

## Entity Framework CLI

Short **`dotnet ef`** cheat sheet: **[EF_CORE_COMMANDS.md](./EF_CORE_COMMANDS.md)**.

## Troubleshooting

- If migrations fail, ensure the connection string points to an available SQL Server instance and that the **MyApp.Api** project is the startup project for EF tooling.
- If upstream HTTP calls return **502**, see `ExternalServiceException` handling in `Middleware/GlobalExceptionHandler.cs` and verify `ExternalApis` URLs.
