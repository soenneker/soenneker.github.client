using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Github.Client.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Github.Client.Registrars;

/// <summary>
/// An async thread-safe singleton for Octokit's GitHubClient
/// </summary>
public static class GitHubClientUtilRegistrar
{
    /// <summary>
    /// Adds the <see cref="IGitHubClientUtil"/> to the <see cref="IServiceCollection"/> as a singleton
    /// </summary>
    public static void AddGitHubClientUtil(this IServiceCollection services)
    {
        services.AddHttpClientCache();
        services.TryAddSingleton<IGitHubClientUtil, GitHubClientUtil>();
    }
}