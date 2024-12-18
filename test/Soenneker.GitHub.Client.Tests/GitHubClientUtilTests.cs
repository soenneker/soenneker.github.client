using System.Threading;
using Soenneker.GitHub.Client.Abstract;
using Soenneker.Tests.FixturedUnit;
using System.Threading.Tasks;
using Xunit;

using FluentAssertions;
using Octokit;
using Soenneker.Facts.Local;

namespace Soenneker.GitHub.Client.Tests;

[Collection("Collection")]
public class GitHubClientUtilTests : FixturedUnitTest
{
    private readonly IGitHubClientUtil _util;

    public GitHubClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IGitHubClientUtil>();
    }

    [LocalFact]
    public async Task Get_should_get()
    {
        GitHubClient client = await _util.Get();
        client.Should().NotBeNull();
       
    }
}
