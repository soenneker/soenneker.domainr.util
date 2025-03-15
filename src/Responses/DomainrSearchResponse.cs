namespace Soenneker.Domainr.Util.Responses;

using System.Collections.Generic;
using System.Text.Json.Serialization;

/// <summary>
/// The search method performs a real-time query of the search term(s) against the known zone database,
/// making recommendations, stemming, applying Unicode folding, IDN normalization, registrar supported-zone
/// restrictions, and other refinements.
/// </summary>
public record DomainrSearchResponse
{
    [JsonPropertyName("results")]
    public List<DomainrSearchResult>? Results { get; set; }
}