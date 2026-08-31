[![](https://img.shields.io/nuget/v/Soenneker.GitHub.Client.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.GitHub.Client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.github.client/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.github.client/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/Soenneker.GitHub.Client.svg?style=for-the-badge)](https://www.nuget.org/packages/Soenneker.GitHub.Client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.github.client/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.github.client/actions/workflows/codeql.yml)

# Soenneker.GitHub.Client

Provides cached Octokit `GitHubClient` instances with credentials isolated by token.

## Installation

```bash
dotnet add package Soenneker.GitHub.Client
```

## Configure and register

```json
{
  "GH": {
    "Token": "your-github-token"
  }
}
```

```csharp
using Soenneker.GitHub.Client.Registrars;

services.AddGitHubClientUtilAsSingleton();
```

Keep the token in secret storage. Its repository and organization permissions determine what Octokit calls can do.

## Use the configured client

```csharp
using Soenneker.GitHub.Client.Abstract;

public sealed class RepositoryReader(IGitHubClientUtil clients)
{
    public async Task<Repository> Get(
        string owner,
        string repository,
        CancellationToken cancellationToken)
    {
        GitHubClient client = await clients.Get(cancellationToken);
        return await client.Repository.Get(owner, repository);
    }
}
```

`Get()` uses `GH:Token`. `Get(token)` supports an explicit token. Calls with the same token reuse one client; different tokens receive different clients, preventing one caller's credentials from leaking into another caller's requests.

The singleton registration is appropriate for application-wide reuse. A scoped registration is also available when an application intentionally wants a separate per-scope cache.
