using Soenneker.Domainr.Client.Abstract;
using Soenneker.Domainr.Util.Abstract;
using Soenneker.Domainr.Util.Responses;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Domainr.Util.Requests;
using Soenneker.Extensions.HttpClient;
using Soenneker.Extensions.ValueTask;
using Soenneker.Extensions.Object;

namespace Soenneker.Domainr.Util;

/// <inheritdoc cref="IDomainrUtil"/>
public class DomainrUtil : IDomainrUtil
{
    private readonly IDomainrClientUtil _clientUtil;

    public DomainrUtil(IDomainrClientUtil clientUtil)
    {
        _clientUtil = clientUtil;
    }

    public async ValueTask<DomainrSearchResponse?> Search(DomainrSearchRequest request, CancellationToken cancellationToken = default)
    {
        var endpoint = $"search{request.ToQueryString()}";

        HttpClient client = await _clientUtil.Get(cancellationToken).NoSync();

        return await client.SendToType<DomainrSearchResponse>(HttpMethod.Get, endpoint, cancellationToken: cancellationToken).NoSync();
    }

    public async ValueTask<DomainrStatusResponse?> Status(DomainrStatusRequest request, CancellationToken cancellationToken = default)
    {
        var endpoint = $"status{request.ToQueryString()}";

        HttpClient client = await _clientUtil.Get(cancellationToken).NoSync();

        return await client.SendToType<DomainrStatusResponse>(HttpMethod.Get, endpoint, cancellationToken: cancellationToken).NoSync();
    }

    public async ValueTask<DomainrRegisterResponse?> Register(RegisterRequest request, CancellationToken cancellationToken = default)
    {
        var endpoint = $"register{request.ToQueryString()}";

        HttpClient client = await _clientUtil.Get(cancellationToken).NoSync();

        return await client.SendToType<DomainrRegisterResponse>(HttpMethod.Get, endpoint, cancellationToken: cancellationToken).NoSync();
    }
}