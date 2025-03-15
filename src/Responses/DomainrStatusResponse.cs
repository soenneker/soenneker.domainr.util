using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Soenneker.Domainr.Util.Responses;

/// <summary>
/// The status method checks the availability status of a single domain name.
/// It returns an array of status objects containing information about the domain and its availability.
/// </summary>
public record DomainrStatusResponse
{
    /// <summary>
    /// The list of status results for the queried domain.
    /// </summary>
    [JsonPropertyName("status")]
    public List<DomainrStatusResult>? Status { get; set; }
}