using Soenneker.Replicate.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Replicate.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class ReplicateOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly IReplicateOpenApiClientUtil _openapiclientutil;

    public ReplicateOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<IReplicateOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
