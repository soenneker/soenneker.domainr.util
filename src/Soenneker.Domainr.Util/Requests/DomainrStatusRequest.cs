using System.Text.Json.Serialization;

namespace Soenneker.Domainr.Util.Requests;

/// <summary>
/// Represents the request parameters for checking the availability status of a domain.
/// </summary>
public record DomainrStatusRequest
{
    /// <summary>
    /// The domain name to check for availability status. This parameter is required.
    /// Example: "acmecoffee.com"
    /// </summary>
    [JsonPropertyName("domain")]
    public required string Domain { get; set; }
}