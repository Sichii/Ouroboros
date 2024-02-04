using Chaos.Geometry.Abstractions;
using Ouroboros.Abstractions;

namespace Ouroboros.Utilities;

public sealed class IdLocation : IIdLocation
{
    /// <inheritdoc />
    public int X { get; init; }

    /// <inheritdoc />
    public int Y { get; init; }

    /// <inheritdoc />
    string ILocation.Map => MapId.ToString();
    
    public ushort MapId { get; init; }
    
    public IdLocation(ushort mapId, int x, int y)
    {
        MapId = mapId;
        X = x;
        Y = y;
    }
}