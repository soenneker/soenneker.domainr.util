using Soenneker.Domainr.Client.Abstract;
using Soenneker.Domainr.Util.Abstract;
using Soenneker.Domainr.Util.Responses;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Soenneker.Domainr.Util.Requests;
using Soenneker.Extensions.ValueTask;
using Soenneker.Extensions.Object;

namespace Soenneker.Domainr.Util;

/// <inheritdoc cref="IDomainrUtil" />
public sealed class DomainrUtil : IDomainrUtil
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

        return await Send<DomainrSearchResponse>(client, endpoint, cancellationToken).NoSync();
    }

    public async ValueTask<DomainrStatusResponse?> Status(DomainrStatusRequest request, CancellationToken cancellationToken = default)
    {
        var endpoint = $"status{request.ToQueryString()}";

        HttpClient client = await _clientUtil.Get(cancellationToken).NoSync();

        return await Send<DomainrStatusResponse>(client, endpoint, cancellationToken).NoSync();
    }

    public async ValueTask<DomainrRegisterResponse?> Register(RegisterRequest request, CancellationToken cancellationToken = default)
    {
        var endpoint = $"register{request.ToQueryString()}";

        HttpClient client = await _clientUtil.Get(cancellationToken).NoSync();

        return await Send<DomainrRegisterResponse>(client, endpoint, cancellationToken).NoSync();
    }

    private static async ValueTask<T?> Send<T>(HttpClient client, string endpoint, CancellationToken cancellationToken)
    {
        using HttpResponseMessage response = await client.GetAsync(endpoint, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<T>(cancellationToken).ConfigureAwait(false);
    }
}
