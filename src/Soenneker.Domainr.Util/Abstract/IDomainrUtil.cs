using Soenneker.Domainr.Util.Requests;
using Soenneker.Domainr.Util.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Domainr.Util.Abstract;

/// <summary>
/// Provides typed access to Domainr search, status, and registrar redirect operations.
/// </summary>
public interface IDomainrUtil
{
    /// <summary>
    /// Performs a real-time search query against the known zone database.
    /// </summary>
    /// <param name="request">The search request parameters.</param>
    /// <param name="cancellationToken">Optional cancellation token.</param>
    /// <returns>The deserialized search response.</returns>
    ValueTask<DomainrSearchResponse?> Search(DomainrSearchRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Checks the availability status of a single domain name.
    /// </summary>
    /// <param name="request">The status request parameters.</param>
    /// <param name="cancellationToken">Optional cancellation token.</param>
    /// <returns>The deserialized status response.</returns>
    ValueTask<DomainrStatusResponse?> Status(DomainrStatusRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a supporting registrar redirect for a domain.
    /// </summary>
    /// <param name="request">The register request parameters.</param>
    /// <param name="cancellationToken">Optional cancellation token.</param>
    /// <returns>The deserialized registrar redirect response.</returns>
    ValueTask<DomainrRegisterResponse?> Register(RegisterRequest request, CancellationToken cancellationToken = default);
}
