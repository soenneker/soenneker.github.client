﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.GitHub.Client.Abstract;

namespace Soenneker.GitHub.Client.Registrars;

/// <summary>
/// An async thread-safe singleton for Octokit's GitHubClient
/// </summary>
public static class GitHubClientUtilRegistrar
{
    /// <summary>
    /// Adds the <see cref="IGitHubClientUtil"/> to the <see cref="IServiceCollection"/> as a singleton
    /// </summary>
    public static IServiceCollection AddGitHubClientUtilAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<IGitHubClientUtil, GitHubClientUtil>();

        return services;
    }

    public static IServiceCollection AddGitHubClientUtilAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<IGitHubClientUtil, GitHubClientUtil>();

        return services;
    }
}