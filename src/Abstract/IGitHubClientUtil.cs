using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Octokit;

namespace Soenneker.GitHub.Client.Abstract;

/// <summary>
/// An async thread-safe singleton for Octokit's GitHubClient
/// </summary>
public interface IGitHubClientUtil : IDisposable, IAsyncDisposable
{
    ValueTask<GitHubClient> Get(CancellationToken cancellationToken = default);

    ValueTask<HttpClient> GetHttpClient(CancellationToken cancellationToken = default);
}