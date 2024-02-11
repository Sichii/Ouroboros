using System.Text.Json;
using System.Text.Json.Serialization;
using Ouroboros.Data;
using Ouroboros.Utilities;

namespace Ouroboros.Converters;

public sealed class IdLocationConverter : JsonConverter<IdLocation>
{
    /// <inheritdoc />
    public override IdLocation? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.String)
            throw new JsonException();

        var stringValue = reader.GetString();

        if (!IdLocation.TryParse(stringValue, out var idLocation))
            return default;

        return idLocation;
    }

    /// <inheritdoc />
    public override void Write(Utf8JsonWriter writer, IdLocation value, JsonSerializerOptions options) => writer.WriteStringValue(value.ToString());
}