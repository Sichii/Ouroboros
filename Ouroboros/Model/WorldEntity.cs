using Chaos.Networking.Entities.Server;
using Ouroboros.Data;

namespace Ouroboros.Model;

public abstract class WorldEntity
{
    public virtual WorldEntityTrackers Trackers { get; }

    protected WorldEntity(WorldEntityTrackers? trackers = null) => Trackers = trackers ?? new WorldEntityTrackers();
}