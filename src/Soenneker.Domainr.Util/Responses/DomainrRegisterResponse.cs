using System.Text.Json.Serialization;

namespace Soenneker.Domainr.Util.Responses;

/// <summary>
/// The response from the register API, typically an HTTP 302 redirect.
/// </summary>
public record DomainrRegisterResponse
{
    /// <summary>
    /// The URL to which the client should be redirected for domain registration.
    /// </summary>
    [JsonPropertyName("redirectUrl")]
    public string? RedirectUrl { get; set; }
}