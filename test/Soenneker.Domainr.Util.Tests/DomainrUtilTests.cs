using Soenneker.Domainr.Util.Abstract;
using Soenneker.Tests.Attributes.Local;
using Soenneker.Tests.HostedUnit;
using System.Threading.Tasks;
using Soenneker.Domainr.Util.Requests;
using AwesomeAssertions;
using Soenneker.Domainr.Util.Responses;

namespace Soenneker.Domainr.Util.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class DomainrUtilTests : HostedUnitTest
{
    private readonly IDomainrUtil _util;

    public DomainrUtilTests(Host host) : base(host)
    {
        _util = Resolve<IDomainrUtil>(true);
    }

    [Test]
    public void Default()
    {
    }

    [Skip("Manual")]
    //[LocalOnly]
    public async ValueTask Search_should_search()
    {
        var request = new DomainrStatusRequest { Domain = "blah.com" };

        DomainrStatusResponse? result = await _util.Status(request, CancellationToken);
        result.Should()
              .NotBeNull();
    }
}
