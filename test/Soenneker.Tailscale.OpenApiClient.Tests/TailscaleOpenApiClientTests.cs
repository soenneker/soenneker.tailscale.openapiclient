using Soenneker.Tests.HostedUnit;

namespace Soenneker.Tailscale.OpenApiClient.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class TailscaleOpenApiClientTests : HostedUnitTest
{
    public TailscaleOpenApiClientTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}
