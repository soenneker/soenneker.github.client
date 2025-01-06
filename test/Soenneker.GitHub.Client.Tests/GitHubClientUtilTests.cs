using System.Threading.Tasks;
using FluentAssertions;
using Octokit;
using Soenneker.GitHub.Client.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.GitHub.Client.Tests;

[Collection("Collection")]
public class GitHubClientUtilTests : FixturedUnitTest
{
    private readonly IGitHubClientUtil _util;

    public GitHubClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IGitHubClientUtil>(true);
    }

    [Fact]
    public async ValueTask Get_should_get_client()
    {
        GitHubClient client = await _util.Get("blah", CancellationToken);
        client.Should().NotBeNull();
    }

    [Fact]
    public async ValueTask Get_should_get_client_with_null()
    {
        GitHubClient client = await _util.Get(null!, CancellationToken);
        client.Should().NotBeNull();
    }

    [Fact]
    public async ValueTask Get_should_get_client_with_empty()
    {
        GitHubClient client = await _util.Get("", CancellationToken);
        client.Should().NotBeNull();
    }

    [Fact]
    public async ValueTask Get_should_get_client_without_token()
    {
        GitHubClient client = await _util.Get(CancellationToken);
        client.Should().NotBeNull();
    }
}
