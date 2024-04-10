using Soenneker.GitHub.Client.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;
using Xunit.Abstractions;

namespace Soenneker.GitHub.Client.Tests;

[Collection("Collection")]
public class GitHubClientUtilTests : FixturedUnitTest
{
    private readonly IGitHubClientUtil _util;

    public GitHubClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IGitHubClientUtil>();
    }
}
