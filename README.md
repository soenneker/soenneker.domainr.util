[![](https://img.shields.io/nuget/v/soenneker.domainr.util.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.domainr.util/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.domainr.util/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.domainr.util/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.domainr.util.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.domainr.util/)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Domainr.Util
### A .NET typesafe implementation of Domainr's API

**DomainrUtil** is a utility class that provides an easy way to interact with the [Domainr](https://domainr.com/) API. It helps check domain name availability, fetch domain status, and get registration details.  

## Features  

- **Search** for available domain names.  
- **Check status** of domain names.  
- **Retrieve registration** information for domains.  

## Installation

```
dotnet add package Soenneker.Domainr.Util
```

Register via DI:
```csharp
services.AddDomainrUtilAsScoped();
```

## Usage  

### Searching for a Domain 

```csharp
var searchRequest = new DomainrSearchRequest { Query = "example" };
var result = await _domainrUtil.Search(searchRequest);

if (result?.Results != null)
{
    foreach (var domain in result.Results)
    {
        Console.WriteLine($"Domain: {domain.Domain}, Register: {domain.RegisterUrl}");
    }
}
```

#### 🔹 Search Response Structure  

| Property     | Type    | Description |
|-------------|--------|-------------|
| `Domain`    | `string?` | The full domain name found in search results. |
| `Host`      | `string?` | The host part of the domain. |
| `Subdomain` | `string?` | The subdomain part of the domain. |
| `Zone`      | `string?` | The top-level domain (TLD) of the domain name. |
| `Path`      | `string?` | Any associated path with the domain (if applicable). |
| `RegisterUrl` | `string?` | A direct URL to register the domain. |

### 3. Checking Domain Status  

The `Status` method fetches real-time information about a domain’s availability.  

```csharp
var statusRequest = new DomainrStatusRequest { Domain = "example.com" };
var statusResponse = await _domainrUtil.Status(statusRequest);

if (statusResponse?.Status != null)
{
    foreach (var status in statusResponse.Status)
    {
        Console.WriteLine($"Domain: {status.Domain}, Status: {status.Status}");
    }
}
```

#### 🔹 Status Response Structure  

| Property  | Type    | Description |
|-----------|--------|-------------|
| `Status`  | `List<DomainrStatusResult>?` | A list of domain status results. |

Each `DomainrStatusResult` contains information about the queried domain’s availability and status.

#### 🔹 Status Result Structure  

| Property  | Type    | Description |
|-----------|--------|-------------|
| `Domain`  | `string?` | The full domain name being checked. |
| `Zone`    | `string?` | The top-level domain (TLD) of the domain. |
| `Status`  | `string?` | A space-delimited list of status types (e.g., `available taken blocked`). |
| `Summary` | `string?` | *(Deprecated)* |