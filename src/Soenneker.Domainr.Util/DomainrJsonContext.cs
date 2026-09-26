using System.Text.Json;
using System.Text.Json.Serialization;
using Soenneker.Domainr.Util.Responses;

namespace Soenneker.Domainr.Util;

[JsonSourceGenerationOptions(JsonSerializerDefaults.Web)]
[JsonSerializable(typeof(DomainrSearchResponse))]
[JsonSerializable(typeof(DomainrStatusResponse))]
[JsonSerializable(typeof(DomainrRegisterResponse))]
internal partial class DomainrJsonContext : JsonSerializerContext;
