using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Octokit;
using Soenneker.Extensions.Configuration;
using Soenneker.GitHub.Client.Abstract;
using Soenneker.Utils.AsyncSingleton;
using Soenneker.Utils.HttpClientCache.Abstract;

namespace Soenneker.GitHub.Client;

///<inheritdoc cref="IGitHubClientUtil"/>
public class GitHubClientUtil : IGitHubClientUtil
{
    private readonly IHttpClientCache _httpClientCache;
    private readonly AsyncSingleton<GitHubClient> _client;

    public GitHubClientUtil(ILogger<GitHubClientUtil> logger, IHttpClientCache httpClientCache, IConfiguration config)
    {
        _httpClientCache = httpClientCache;

        _client = new AsyncSingleton<GitHubClient>(() =>
        {
            var username = config.GetValueStrict<string>("Github:Username");
            var token = config.GetValueStrict<string>("Github:Token");

            logger.LogInformation("Connecting to Github...");

            var client = new GitHubClient(new ProductHeaderValue(username));

            var basicAuth = new Credentials(token);
            client.Credentials = basicAuth;
            return client;
        });
    }

    public ValueTask<GitHubClient> Get()
    {
        return _client.Get();
    }

    public ValueTask<HttpClient> GetHttpClient()
    {
        return _httpClientCache.Get(nameof(GitHubClientUtil));
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        _client.Dispose();
        _httpClientCache.RemoveSync(nameof(GitHubClientUtil));
    }

    public async ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);

        await _client.DisposeAsync().ConfigureAwait(false);
        await _httpClientCache.Remove(nameof(GitHubClientUtil)).ConfigureAwait(false);
    }
}