using System.Text.Json.Serialization;

namespace Soenneker.Domainr.Util.Requests;

/// <summary>
/// Represents the request parameters for registering a domain.
/// </summary>
public record RegisterRequest
{
    /// <summary>
    /// The domain name to register. This parameter is required.
    /// Example: "acmefoobar.coffee"
    /// </summary>
    [JsonPropertyName("domain")]
    public required string Domain { get; set; }

    /// <summary>
    /// The registrar's URL for domain registration. This parameter is optional.
    /// Example: "dnsimple.com"
    /// </summary>
    [JsonPropertyName("registrar")]
    public string? Registrar { get; set; }
}