using System.Threading;
using System.Threading.Tasks;
using AwesomeAssertions;
using Octokit;
using Soenneker.GitHub.Client.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.GitHub.Client.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class GitHubClientUtilTests : HostedUnitTest
{
    private readonly IGitHubClientUtil _util;

    public GitHubClientUtilTests(Host host) : base(host)
    {
        _util = Resolve<IGitHubClientUtil>(true);
    }

    [Test]
    public async ValueTask Get_should_get_client(CancellationToken cancellationToken)
    {
        GitHubClient client = await _util.Get("blah", cancellationToken);
        client.Should().NotBeNull();
    }

    [Test]
    public async ValueTask Get_should_get_client_with_null(CancellationToken cancellationToken)
    {
        GitHubClient client = await _util.Get(null!, cancellationToken);
        client.Should().NotBeNull();
    }

    [Test]
    public async ValueTask Get_should_get_client_with_empty(CancellationToken cancellationToken)
    {
        GitHubClient client = await _util.Get("", cancellationToken);
        client.Should().NotBeNull();
    }

    [Test]
    public async ValueTask Get_should_get_client_without_token(CancellationToken cancellationToken)
    {
        GitHubClient client = await _util.Get(cancellationToken);
        client.Should().NotBeNull();
    }
}
