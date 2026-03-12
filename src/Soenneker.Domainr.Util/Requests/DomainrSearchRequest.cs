using System.Text.Json.Serialization;

namespace Soenneker.Domainr.Util.Requests;

/// <summary>
/// Represents the request parameters for performing a domain search query.
/// </summary>
public record DomainrSearchRequest
{
    /// <summary>
    /// Term(s) to search against. This parameter is required.
    /// Example: "foo bar"
    /// </summary>
    [JsonPropertyName("query")]
    public required string Query { get; set; }

    /// <summary>
    /// Overrides IP location detection for country-code zones.
    /// Accepts a two-character country code. This parameter is optional.
    /// Example: "de"
    /// </summary>
    [JsonPropertyName("location")]
    public string? Location { get; set; }

    /// <summary>
    /// The domain name of a specific registrar.
    /// Used for filtering results by zones supported by the registrar. This parameter is optional.
    /// Example: "dnsimple.com"
    /// </summary>
    [JsonPropertyName("registrar")]
    public string? Registrar { get; set; }

    /// <summary>
    /// Comma-separated list of default zones to include in the response.
    /// This parameter is optional.
    /// Example: "club"
    /// </summary>
    [JsonPropertyName("defaults")]
    public string? Defaults { get; set; }

    /// <summary>
    /// Beta feature: Comma-separated list of keywords for seeding the results.
    /// This can help improve search result relevance.
    /// Example: "kitchen,vegan"
    /// </summary>
    [JsonPropertyName("keywords")]
    public string? Keywords { get; set; }
}