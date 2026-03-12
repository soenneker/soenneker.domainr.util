using System.Text.Json.Serialization;

namespace Soenneker.Domainr.Util.Responses;

public record DomainrSearchResult
{
    /// <summary>
    /// The domain name found in the search results.
    /// </summary>
    [JsonPropertyName("domain")]
    public string? Domain { get; set; }

    /// <summary>
    /// The host part of the domain name.
    /// </summary>
    [JsonPropertyName("host")]
    public string? Host { get; set; }

    /// <summary>
    /// The subdomain part of the domain name.
    /// </summary>
    [JsonPropertyName("subdomain")]
    public string? Subdomain { get; set; }

    /// <summary>
    /// The zone (TLD) of the domain name.
    /// </summary>
    [JsonPropertyName("zone")]
    public string? Zone { get; set; }

    /// <summary>
    /// The path associated with the domain, if applicable.
    /// </summary>
    [JsonPropertyName("path")]
    public string? Path { get; set; }

    /// <summary>
    /// The URL to register the domain name.
    /// </summary>
    [JsonPropertyName("registerURL")]
    public string? RegisterUrl { get; set; }
}