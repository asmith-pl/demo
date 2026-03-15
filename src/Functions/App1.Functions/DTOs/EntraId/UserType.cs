using System.Text.Json.Serialization;

namespace LogixPro.LogixPro.Functions.DTOs.EntraId;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum UserType
{
    Member,
    Guest
}
