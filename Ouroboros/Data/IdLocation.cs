using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using Chaos.Geometry.Abstractions;
using Ouroboros.Abstractions;
using Ouroboros.Converters;
using Ouroboros.Defintions;

namespace Ouroboros.Data;

[JsonConverter(typeof(IdLocationConverter))]
public sealed class IdLocation : IIdLocation, IParsable<IdLocation>
{
    /// <inheritdoc />
    public int X { get; init; }

    /// <inheritdoc />
    public int Y { get; init; }

    /// <inheritdoc />
    string ILocation.Map => MapId.ToString();
    
    public short MapId { get; init; }
    
    public IdLocation(short mapId, int x, int y)
    {
        MapId = mapId;
        X = x;
        Y = y;
    }

    #region IParsable
    /// <inheritdoc />
    public static IdLocation Parse(string s, IFormatProvider? provider)
    {
        var match = RegexCache.IDLOCATION_REGEX.Match(s);

        if (match is not { Success: true })
            throw new FormatException("Invalid format for IdLocation");
        
        var mapId = short.Parse(match.Groups[1].Value);
        var x = int.Parse(match.Groups[2].Value);
        var y = int.Parse(match.Groups[3].Value);
        
        return new IdLocation(mapId, x, y);
    }

    public override string ToString() => $"{MapId}:({X}, {Y})";

    public static bool TryParse(string? s, [MaybeNullWhen(false)] out IdLocation result) => TryParse(s, null, out result);
    
    /// <inheritdoc />
    public static bool TryParse(string? s, IFormatProvider? provider, [MaybeNullWhen(false)] out IdLocation result)
    {
        if (s is null)
        {
            result = default;

            return false;
        }

        var match = RegexCache.IDLOCATION_REGEX.Match(s);

        if (match is not { Success: true })
        {
            result = default;

            return false;
        }

        if (!short.TryParse(match.Groups[1].Value, out var mapId)
            || !int.TryParse(match.Groups[2].Value, out var x)
            || !int.TryParse(match.Groups[3].Value, out var y))
        {
            result = default;

            return false;
        }

        result = new IdLocation(mapId, x, y);

        return true;
    }
    #endregion
}