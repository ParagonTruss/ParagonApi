using System.Text.Json;
using System.Text.Json.Serialization;

namespace ParagonApi;

internal static class Serialization
{
    private static readonly JsonSerializerOptions SerializerOptions = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) },
    };

    internal static string Serialize<T>(T value) => JsonSerializer.Serialize(value, SerializerOptions);

    internal static T Deserialize<T>(string value) =>
        JsonSerializer.Deserialize<T>(value, SerializerOptions) ?? throw new NullReferenceException();
}
