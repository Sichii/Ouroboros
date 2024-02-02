using Chaos.Geometry.Abstractions;

namespace Ouroboros.Utilities;

public sealed class IdLocation : ILocation
{
    /// <inheritdoc />
    public int X { get; init; }

    /// <inheritdoc />
    public int Y { get; init; }

    /// <inheritdoc />
    string ILocation.Map => MapId.ToString();
    
    public int MapId { get; init; }
    
    public IdLocation(int mapId, int x, int y)
    {
        MapId = mapId;
        X = x;
        Y = y;
    }
}