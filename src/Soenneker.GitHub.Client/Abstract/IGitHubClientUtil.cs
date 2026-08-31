using System;
using System.Threading;
using System.Threading.Tasks;
using Octokit;

namespace Soenneker.GitHub.Client.Abstract;

/// <summary>
/// Provides cached Octokit clients keyed by GitHub token.
/// </summary>
public interface IGitHubClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the cached client for an explicit GitHub token.
    /// </summary>
    /// <param name="token">The GitHub token used by the returned client.</param>
    /// <param name="cancellationToken">Token used to cancel retrieval.</param>
    /// <returns>The client associated with <paramref name="token"/>.</returns>
    ValueTask<GitHubClient> Get(string token, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the cached client using the configured <c>GH:Token</c> value.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel retrieval.</param>
    /// <returns>The client associated with the configured token.</returns>
    ValueTask<GitHubClient> Get(CancellationToken cancellationToken = default);
}
