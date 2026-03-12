using System;
using System.Threading;
using System.Threading.Tasks;
using Octokit;

namespace Soenneker.GitHub.Client.Abstract;

/// <summary>
/// An async thread-safe singleton for Octokit's GitHubClient
/// </summary>
public interface IGitHubClientUtil : IDisposable, IAsyncDisposable
{
    ValueTask<GitHubClient> Get(string token, CancellationToken cancellationToken = default);

    ValueTask<GitHubClient> Get(CancellationToken cancellationToken = default);
}