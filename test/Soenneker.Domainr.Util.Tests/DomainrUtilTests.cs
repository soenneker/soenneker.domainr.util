using Soenneker.Domainr.Util.Abstract;
using Soenneker.Tests.Attributes.Local;
using Soenneker.Tests.HostedUnit;
using System.Threading.Tasks;
using Soenneker.Domainr.Util.Requests;
using AwesomeAssertions;
using Soenneker.Domainr.Util.Responses;
using Soenneker.Domainr.Client.Abstract;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;

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

    [Test]
    [Skip("Manual")]
    //[LocalOnly]
    public async ValueTask Search_should_search(CancellationToken cancellationToken)
    {
        var request = new DomainrStatusRequest { Domain = "blah.com" };

        DomainrStatusResponse? result = await _util.Status(request, cancellationToken);
        result.Should()
              .NotBeNull();
    }

    [Test]
    public async Task Search_should_encode_query_and_deserialize_success(CancellationToken cancellationToken)
    {
        Uri? requestedUri = null;
        using var client = new HttpClient(new StubHandler(request =>
        {
            requestedUri = request.RequestUri;
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent("{\"results\":[{\"domain\":\"example.com\"}]}", Encoding.UTF8, "application/json")
            };
        }))
        {
            BaseAddress = new Uri("https://example.test/v2/")
        };

        var util = new DomainrUtil(new StubClientUtil(client));
        DomainrSearchResponse? result = await util.Search(new DomainrSearchRequest {Query = "example & test"}, cancellationToken: cancellationToken);

        requestedUri.Should().Be(new Uri("https://example.test/v2/search?query=example%20%26%20test"));
        result!.Results![0].Domain.Should().Be("example.com");
    }

    [Test]
    public async Task Status_should_throw_for_non_success_response(CancellationToken cancellationToken)
    {
        using var client = new HttpClient(new StubHandler(_ => new HttpResponseMessage(HttpStatusCode.TooManyRequests)))
        {
            BaseAddress = new Uri("https://example.test/v2/")
        };

        var util = new DomainrUtil(new StubClientUtil(client));
        Func<Task> act = async () => await util.Status(new DomainrStatusRequest {Domain = "example.com"}, cancellationToken: cancellationToken);

        await act.Should().ThrowAsync<HttpRequestException>();
    }

    private sealed class StubClientUtil(HttpClient client) : IDomainrClientUtil
    {
        public ValueTask<HttpClient> Get(CancellationToken cancellationToken = default) => new(client);

        public void Dispose()
        {
        }

        public ValueTask DisposeAsync() => ValueTask.CompletedTask;
    }

    private sealed class StubHandler(Func<HttpRequestMessage, HttpResponseMessage> handler) : HttpMessageHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) =>
            Task.FromResult(handler(request));
    }
}

