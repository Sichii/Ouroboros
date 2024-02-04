using Chaos.Geometry.Abstractions;
using Ouroboros.Abstractions;
using Ouroboros.Data;

namespace Ouroboros.Model;

public abstract class MapEntity : WorldEntity, IIdLocation
{
    /// <inheritdoc />
    public int X { get; set; }

    /// <inheritdoc />
    public int Y { get; set; }

    /// <inheritdoc />
    public ushort MapId => Map.Id;
    public required Map Map { get; set; }

    /// <inheritdoc />
    string ILocation.Map => Map.Name;

    /// <inheritdoc />
    public override MapEntityTrackers Trackers { get; }

    protected MapEntity(Map map, int x, int y, MapEntityTrackers? trackers = null)
        : base(trackers ??= new MapEntityTrackers())
    {
        Trackers = trackers;
        Map = map;
        X = x;
        Y = y;
    }
}