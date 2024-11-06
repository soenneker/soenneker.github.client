using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Octokit;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.GitHub.Client.Abstract;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.GitHub.Client;

///<inheritdoc cref="IGitHubClientUtil"/>
public class GitHubClientUtil : IGitHubClientUtil
{
    private readonly AsyncSingleton<GitHubClient> _client;

    public GitHubClientUtil(ILogger<GitHubClientUtil> logger, IConfiguration config)
    {
        _client = new AsyncSingleton<GitHubClient>(() =>
        {
            var username = config.GetValueStrict<string>("GitHub:Username");
            var token = config.GetValueStrict<string>("GitHub:Token");

            logger.LogInformation("Connecting to GitHub...");

            var client = new GitHubClient(new ProductHeaderValue(username));

            var basicAuth = new Credentials(token);
            client.Credentials = basicAuth;
            return client;
        });
    }

    public ValueTask<GitHubClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public async ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);

        await _client.DisposeAsync().NoSync();
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        _client.Dispose();
    }
}