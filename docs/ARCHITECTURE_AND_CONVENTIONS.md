# MyApp.Api — architecture and conventions

## Layering

| Project                  | Responsibility                                                                                       |
| ------------------------ | ---------------------------------------------------------------------------------------------------- |
| **MyApp.Api**            | HTTP, OpenAPI/Swagger, health checks, middleware (exception handling), controller mapping to MediatR |
| **MyApp.Application**    | Use cases: MediatR commands/queries, DTOs, FluentValidation, cross-cutting pipeline behaviors        |
| **MyApp.Core**           | Domain entities, interfaces, options binding keys, shared exceptions used across layers              |
| **MyApp.Infrastructure** | EF Core, repository implementations, outbound HTTP clients                                           |

**Dependency direction:** API → Application + Infrastructure; Infrastructure → Core only (not Application).

## Request flow

1. Controller receives HTTP and maps to a **command/query** (MediatR).
2. **Validation** runs in `ValidationBehavior` before the handler.
3. Handlers call **repository or gateway** interfaces with `CancellationToken`.
4. Responses use **DTOs** for employees; entities stay inside Application/Core mapping.

## Naming

- **`IExternalVendorGateway` / `ExternalVendorGateway`:** HTTP integration with third parties (not a SQL “repository”).

## Errors

- **400** — `ApplicationValidationException` with `errors` keyed by property (RFC 7807 `ProblemDetails`).
- **404** — Missing employee (controller checks null/false from handlers).
- **502** — `ExternalServiceException` from HTTP client integration.
- **500** — Unexpected errors; details limited outside Development.

## Improvement checklist (ongoing)

- Add integration tests (`WebApplicationFactory`) for API contracts.
- Consider API versioning and rate limiting for public deployments.
- Expand health checks (e.g., optional SQL query, external ping) per environment needs.
