# EF Core — quick commands

Run from the folder with **`MyApp.Api.slnx`**. Migrations live in **`MyApp.Infrastructure`**; startup/config in **`MyApp.Api`**. Keep the **`Migrations`** folder in git (do not `.gitignore` it).

**Install tool (once):**

```powershell
dotnet tool install --global dotnet-ef
```

**Apply migrations / create or update DB** (most used after you changed code or deleted the DB):

```powershell
dotnet ef database update --project MyApp.Infrastructure --startup-project MyApp.Api
```

**Dev only — drop database, then recreate from migrations (all data lost):**

```powershell
dotnet ef database drop --project MyApp.Infrastructure --startup-project MyApp.Api --force
dotnet ef database update --project MyApp.Infrastructure --startup-project MyApp.Api
```

Or from repo root: **`.\scripts\Reset-DevDatabase.ps1 -Force`**

**After you change entities or `DbContext`:**

```powershell
dotnet ef migrations add YourName --project MyApp.Infrastructure --startup-project MyApp.Api
dotnet ef database update --project MyApp.Infrastructure --startup-project MyApp.Api
```

**Undo the last migration locally** (before others depend on it):

```powershell
dotnet ef migrations remove --project MyApp.Infrastructure --startup-project MyApp.Api
```

**See what migrations exist:**

```powershell
dotnet ef migrations list --project MyApp.Infrastructure --startup-project MyApp.Api
```

**Solution build & tests:**

```powershell
dotnet build MyApp.Api.slnx
dotnet test MyApp.Api.slnx
```

If `database update` fails: SQL Server must be running; connection string is `ConnectionStrings:DefaultConnection` (default DB name **`TestAPIDb`**). Create that database in SSMS if your login cannot create it. If `database drop` says the database does not exist, run **`database update`** anyway.
