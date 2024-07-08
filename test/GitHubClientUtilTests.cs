using System.Threading;
using Soenneker.GitHub.Client.Abstract;
using Soenneker.Tests.FixturedUnit;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using FluentAssertions;
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
        var client = await _util.Get(CancellationToken.None);
        client.Should().NotBeNull();
       
    }
}
