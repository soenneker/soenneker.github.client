using System.Threading.Tasks;
using FluentAssertions;
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
        var client = await _util.Get("blah");
        client.Should().NotBeNull();
    }

    [Fact]
    public async ValueTask Get_should_get_client_without_token()
    {
        var client = await _util.Get();
        client.Should().NotBeNull();
    }
}
