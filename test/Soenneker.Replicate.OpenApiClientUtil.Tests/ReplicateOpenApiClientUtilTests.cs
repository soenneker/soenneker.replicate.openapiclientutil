using Soenneker.Replicate.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Replicate.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class ReplicateOpenApiClientUtilTests : HostedUnitTest
{
    private readonly IReplicateOpenApiClientUtil _openapiclientutil;

    public ReplicateOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<IReplicateOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
