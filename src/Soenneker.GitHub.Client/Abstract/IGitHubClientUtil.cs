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
    /// <summary>
    /// Gets the value.
    /// </summary>
    /// <param name="token">The token.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<GitHubClient> Get(string token, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the value.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<GitHubClient> Get(CancellationToken cancellationToken = default);
}