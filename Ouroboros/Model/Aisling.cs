using Chaos.Common.Definitions;
using Chaos.Geometry.Abstractions.Definitions;
using Ouroboros.Data;

namespace Ouroboros.Model;

public class Aisling : Creature
{
    public string Name { get; }

    /// <inheritdoc />
    public override AislingTrackers Trackers { get; }

    /// <inheritdoc />
    public Aisling(
        uint id,
        Map map,
        ushort sprite,
        int x,
        int y,
        CreatureType type,
        Direction direction,
        string name,
        AislingTrackers? trackers = null)
        : base(
            id,
            map,
            sprite,
            x,
            y,
            type,
            direction,
            trackers ??= new AislingTrackers())
    {
        Name = name;
        Trackers = trackers;
    }
}