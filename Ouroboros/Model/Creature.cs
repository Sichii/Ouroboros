using Chaos.Common.Definitions;
using Chaos.Geometry.Abstractions.Definitions;
using Ouroboros.Data;

namespace Ouroboros.Model;

public abstract class Creature : VisibleEntity
{
    /// <inheritdoc />
    public override CreatureTrackers Trackers { get; }
    public Direction Direction { get; set; }
    public CreatureType Type { get; set; }
    public virtual byte HealthPercent { get; set; } = 100;

    /// <inheritdoc />
    protected Creature(
        uint id,
        Map map,
        ushort sprite,
        int x,
        int y,
        CreatureType type,
        Direction direction,
        CreatureTrackers? trackers = null)
        : base(
            id,
            map,
            sprite,
            x,
            y,
            trackers ??= new CreatureTrackers())
    {
        Type = type;
        Direction = direction;
        Trackers = trackers;
    }
}