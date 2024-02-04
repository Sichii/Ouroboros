using Ouroboros.Data;

namespace Ouroboros.Model;

public class GroundItem : VisibleEntity
{
    public GroundItem(
        uint id,
        Map map,
        ushort sprite,
        int x,
        int y,
        MapEntityTrackers? trackers = null)
        : base(
            id,
            map,
            sprite,
            x,
            y,
            trackers) { }
}