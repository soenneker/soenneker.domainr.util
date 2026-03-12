using Soenneker.Domainr.Util.Requests;
using Soenneker.Domainr.Util.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Domainr.Util.Abstract;

/// <summary>
/// A .NET typesafe implementation of Domainr's API
/// </summary>
public interface IDomainrUtil
{
    /// <summary>
    /// Performs a real-time search query against the known zone database.
    /// </summary>
    /// <param name="request">The search request parameters.</param>
    /// <param name="cancellationToken">Optional cancellation token.</param>
    /// <returns>A Task representing the asynchronous operation, returning a SearchResponse object.</returns>
    ValueTask<DomainrSearchResponse?> Search(DomainrSearchRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Checks the availability status of a single domain name.
    /// </summary>
    /// <param name="request">The status request parameters.</param>
    /// <param name="cancellationToken">Optional cancellation token.</param>
    /// <returns>A Task representing the asynchronous operation, returning a StatusResponse object.</returns>
    ValueTask<DomainrStatusResponse?> Status(DomainrStatusRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Registers a domain and redirects to a supporting registrar.
    /// </summary>
    /// <param name="request">The register request parameters.</param>
    /// <param name="cancellationToken">Optional cancellation token.</param>
    /// <returns>A Task representing the asynchronous operation, returning a RegisterResponse object.</returns>
    ValueTask<DomainrRegisterResponse?> Register(RegisterRequest request, CancellationToken cancellationToken = default);
}