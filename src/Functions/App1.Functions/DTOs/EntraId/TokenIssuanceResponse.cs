using System.Text.Json.Serialization;

namespace LogixPro.LogixPro.Functions.DTOs.EntraId;

public sealed class TokenIssuanceResponse
{
    [JsonPropertyName("data")]
    public TokenIssuanceResponseData Data { get; set; } = new();
}
