using System.Text.Json;
using System.Text.Json.Serialization;
using Soenneker.Domainr.Util.Responses;
using Soenneker.Domainr.Util.Requests;

namespace Soenneker.Domainr.Util;

[JsonSourceGenerationOptions(JsonSerializerDefaults.Web, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
[JsonSerializable(typeof(DomainrSearchRequest))]
[JsonSerializable(typeof(DomainrStatusRequest))]
[JsonSerializable(typeof(RegisterRequest))]
[JsonSerializable(typeof(DomainrSearchResponse))]
[JsonSerializable(typeof(DomainrStatusResponse))]
[JsonSerializable(typeof(DomainrRegisterResponse))]
internal partial class DomainrJsonContext : JsonSerializerContext;
