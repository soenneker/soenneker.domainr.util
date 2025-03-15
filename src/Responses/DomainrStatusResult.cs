using System.Text.Json.Serialization;

namespace Soenneker.Domainr.Util.Responses;

public record DomainrStatusResult
{
    /// <summary>
    /// The domain name being checked.
    /// </summary>
    [JsonPropertyName("domain")]
    public string? Domain { get; set; }

    /// <summary>
    /// The zone (TLD) of the domain.
    /// </summary>
    [JsonPropertyName("zone")]
    public string? Zone { get; set; }

    /// <summary>
    /// The space-delimited list of status types for the domain.
    /// </summary>
    [JsonPropertyName("status")]
    public string? Status { get; set; }

    /// <summary>
    /// Deprecated: The most significant status. Use the "status" field instead.
    /// </summary>
    [JsonPropertyName("summary")]
    public string? Summary { get; set; }
}
