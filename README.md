[![](https://img.shields.io/nuget/v/soenneker.replicate.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.replicate.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.replicate.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.replicate.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.replicate.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.replicate.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.replicate.openapiclientutil/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.replicate.openapiclientutil/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Replicate.OpenApiClientUtil

Provides a lazily initialized Replicate client for models, predictions, deployments, trainings, files, search, hardware, collections, account details, and webhook secrets.

## Installation

```bash
dotnet add package Soenneker.Replicate.OpenApiClientUtil
```

## Configuration

```json
{
  "Replicate": {
    "ApiKey": "your-replicate-api-token"
  }
}
```

## Usage

```csharp
using Soenneker.Replicate.OpenApiClientUtil.Abstract;
using Soenneker.Replicate.OpenApiClientUtil.Registrars;

services.AddReplicateOpenApiClientUtilAsSingleton();

public sealed class ReplicateAccountReader
{
    private readonly IReplicateOpenApiClientUtil _replicate;

    public ReplicateAccountReader(IReplicateOpenApiClientUtil replicate)
    {
        _replicate = replicate;
    }

    public async Task GetAccount(CancellationToken cancellationToken)
    {
        var client = await _replicate.Get(cancellationToken);
        var account = await client.Account.GetAsync(
            cancellationToken: cancellationToken);
    }
}
```

The underlying provider sends `Authorization: Bearer <token>` and targets `https://api.replicate.com/v1/` by default. Use `AddReplicateOpenApiClientUtilAsScoped()` when each scope should have its own lazily initialized API client; both registrations reuse the singleton authenticated HTTP client provider.
