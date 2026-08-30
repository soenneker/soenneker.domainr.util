[![](https://img.shields.io/nuget/v/soenneker.domainr.util.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.domainr.util/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.domainr.util/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.domainr.util/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.domainr.util.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.domainr.util/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.domainr.util/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.domainr.util/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Domainr.Util

Provides typed Domainr search, status, and registrar-redirect operations through RapidAPI.

## Installation

```bash
dotnet add package Soenneker.Domainr.Util
```

## Configuration

```json
{
  "Domainr": {
    "Host": "domainr.p.rapidapi.com",
    "ApiKey": "your-rapidapi-key"
  }
}
```

Keep the API key in a secret provider. `Host` is trusted configuration because it determines the destination that receives the key.

## Registration

```csharp
using Soenneker.Domainr.Util.Registrars;

services.AddDomainrUtilAsScoped();
```

The scoped registration creates a util per dependency-injection scope while retaining the underlying Domainr HTTP client provider as a singleton. Use `AddDomainrUtilAsSingleton()` when the typed util should also live for the application lifetime.

## Search

```csharp
using Soenneker.Domainr.Util.Abstract;
using Soenneker.Domainr.Util.Requests;
using Soenneker.Domainr.Util.Responses;

DomainrSearchResponse? response = await domainr.Search(
    new DomainrSearchRequest
    {
        Query = "example",
        Location = "us",
        Defaults = "com,net"
    },
    cancellationToken);

foreach (DomainrSearchResult result in response?.Results ?? [])
{
    Console.WriteLine($"{result.Domain}: {result.RegisterUrl}");
}
```

Optional `Registrar` and `Keywords` values can further constrain or seed a search. Request values are URL-encoded and null optional values are omitted.

## Check status

```csharp
DomainrStatusResponse? response = await domainr.Status(
    new DomainrStatusRequest {Domain = "example.com"},
    cancellationToken);

foreach (DomainrStatusResult result in response?.Status ?? [])
{
    Console.WriteLine($"{result.Domain}: {result.Status}");
}
```

`Status` is Domainr’s space-delimited status string. Interpret all returned tokens rather than testing one exact value.

## Get a registrar redirect

```csharp
DomainrRegisterResponse? response = await domainr.Register(
    new RegisterRequest
    {
        Domain = "example.com",
        Registrar = "dnsimple.com"
    },
    cancellationToken);

string? redirectUrl = response?.RedirectUrl;
```

`Register` obtains a redirect URL; it does not purchase or register the domain.

All operations require a successful HTTP status and then deserialize JSON. Non-success responses throw `HttpRequestException`; invalid or empty JSON can throw `JsonException`. The util does not retry rate limits or transient failures, so apply retries at the application boundary when appropriate and always pass cancellation tokens.
