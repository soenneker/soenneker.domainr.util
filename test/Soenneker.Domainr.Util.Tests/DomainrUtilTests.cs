using Soenneker.Domainr.Util.Abstract;
using Soenneker.Facts.Local;
using Soenneker.Tests.FixturedUnit;
using System.Threading.Tasks;
using Soenneker.Domainr.Util.Requests;
using Xunit;
using AwesomeAssertions;
using Soenneker.Domainr.Util.Responses;
using Soenneker.Facts.Manual;

namespace Soenneker.Domainr.Util.Tests;

[Collection("Collection")]
public class DomainrUtilTests : FixturedUnitTest
{
    private readonly IDomainrUtil _util;

    public DomainrUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IDomainrUtil>(true);
    }

    [Fact]
    public void Default()
    {
    }

    [ManualFact]
    //[LocalFact]
    public async ValueTask Search_should_search()
    {
        var request = new DomainrStatusRequest { Domain = "blah.com" };

        DomainrStatusResponse? result = await _util.Status(request, CancellationToken);
        result.Should()
              .NotBeNull();
    }
}