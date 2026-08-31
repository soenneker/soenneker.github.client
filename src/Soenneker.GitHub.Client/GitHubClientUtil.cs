using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Octokit;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.String;
using Soenneker.GitHub.Client.Abstract;

namespace Soenneker.GitHub.Client;

public sealed class GitHubClientUtil : IGitHubClientUtil
{
    private readonly ConcurrentDictionary<string, GitHubClient> _clients = new(StringComparer.Ordinal);
    private readonly ILogger<GitHubClientUtil> _logger;
    private readonly IConfiguration _config;

    public GitHubClientUtil(ILogger<GitHubClientUtil> logger, IConfiguration config)
    {
        _logger = logger;
        _config = config;
    }

    private GitHubClient CreateClient(string token)
    {
        _logger.LogInformation("Connecting to GitHub...");

        var client = new GitHubClient(new ProductHeaderValue(nameof(GitHubClientUtil)));

        var basicAuth = new Credentials(token);
        client.Credentials = basicAuth;
        return client;
    }

    public ValueTask<GitHubClient> Get(string token, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        if (token.IsNullOrEmpty())
            token = _config.GetValueStrict<string>("GH:Token");

        return ValueTask.FromResult(_clients.GetOrAdd(token, CreateClient));
    }

    public ValueTask<GitHubClient> Get(CancellationToken cancellationToken = default)
        => Get(string.Empty, cancellationToken);

    public ValueTask DisposeAsync()
    {
        _clients.Clear();
        return ValueTask.CompletedTask;
    }

    public void Dispose()
    {
        _clients.Clear();
    }
}
