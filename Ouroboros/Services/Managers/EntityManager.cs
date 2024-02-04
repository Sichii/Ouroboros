using Chaos.Common.Definitions;
using Chaos.Common.Synchronization;
using Chaos.Extensions.Geometry;
using Ouroboros.Model;
using Ouroboros.Networking;
using CONSTANTS = Ouroboros.Defintions.CONSTANTS;

namespace Ouroboros.Services.Managers;

public class EntityManager
{
    private readonly Client Client;
    private readonly Dictionary<uint, VisibleEntity> Entities;
    private readonly HashSet<Door> Doors;
    private readonly HashSet<uint> NearbyAislingIds;
    private readonly HashSet<uint> NearbyGroundItemIds;
    private readonly HashSet<uint> NearbyMonsterIds;
    private readonly HashSet<uint> NearbyMerchantIds;
    private readonly AutoReleasingMonitor Sync;

    public EntityManager(Client client)
    {
        Client = client;
        Entities = new Dictionary<uint, VisibleEntity>();
        Doors = new HashSet<Door>();
        NearbyAislingIds = new HashSet<uint>();
        NearbyGroundItemIds = new HashSet<uint>();
        NearbyMonsterIds = new HashSet<uint>();
        NearbyMerchantIds = new HashSet<uint>();
        Sync = new AutoReleasingMonitor();
    }

    public List<Aisling> GetNearbyAislings(Func<Aisling, bool>? predicate)
    {
        using var @lock = Sync.Enter();

        var ret = new List<Aisling>();

        foreach (var id in NearbyAislingIds)
            if (Entities.TryGetValue(id, out var entity) && entity is Aisling aisling && (predicate?.Invoke(aisling) ?? true))
                ret.Add(aisling);

        return ret;
    }

    public List<GroundItem> GetNearbyGroundItems(Func<GroundItem, bool>? predicate)
    {
        using var @lock = Sync.Enter();

        var ret = new List<GroundItem>();
        
        foreach (var id in NearbyGroundItemIds)
            if (Entities.TryGetValue(id, out var entity) && entity is GroundItem groundItem && (predicate?.Invoke(groundItem) ?? true))
                ret.Add(groundItem);

        return ret;
    }

    public List<Merchant> GetNearbyMerchants(Func<Merchant, bool>? predicate)
    {
        using var @lock = Sync.Enter();

        var ret = new List<Merchant>();

        foreach (var id in NearbyMerchantIds)
            if (Entities.TryGetValue(id, out var entity) && entity is Merchant merchant && (predicate?.Invoke(merchant) ?? true))
                ret.Add(merchant);

        return ret;
    }

    public List<Creature> GetNearbyMonsters(Func<Creature, bool>? predicate)
    {
        using var @lock = Sync.Enter();

        var ret = new List<Creature>();

            foreach (var id in NearbyMonsterIds)
            if (Entities.TryGetValue(id, out var entity)
                && entity is Creature { Type: CreatureType.Normal or CreatureType.WalkThrough } monster
                && (predicate?.Invoke(monster) ?? true))
                ret.Add(monster);

        return ret;
    }

    public List<Creature> GetNearbyCreatures(Func<Creature, bool>? predicate)
    {
        using var @lock = Sync.Enter();
        
        var ret = new List<Creature>();
        
        foreach (var id in NearbyMonsterIds)
            if (Entities.TryGetValue(id, out var entity) && entity is Creature monster && (predicate?.Invoke(monster) ?? true))
                ret.Add(monster);

        foreach (var id in NearbyMerchantIds)
            if (Entities.TryGetValue(id, out var entity) && entity is Creature merchant && (predicate?.Invoke(merchant) ?? true))
                ret.Add(merchant);

        foreach (var id in NearbyAislingIds)
            if (Entities.TryGetValue(id, out var entity) && entity is Creature aisling && (predicate?.Invoke(aisling) ?? true))
                ret.Add(aisling);

        return ret;
    }

    public List<Door> GetNearbyDoors(Func<Door, bool>? predicate)
    {
        using var @lock = Sync.Enter();

        var ret = new List<Door>();
        
        foreach (var door in Doors)
            if ((predicate?.Invoke(door) ?? true) && (Client.ServerPoint.DistanceFrom(door) <= CONSTANTS.DEFAULT_MAX_RANGE))
                ret.Add(door);

        return ret;
    }

    public List<VisibleEntity> GetNearbyVisibleEntities(Func<VisibleEntity, bool>? predicate)
    {
        using var @lock = Sync.Enter();

        var ret = new List<VisibleEntity>();

        foreach (var id in NearbyMonsterIds)
            if (Entities.TryGetValue(id, out var entity) && (predicate?.Invoke(entity) ?? true))
                ret.Add(entity);

        foreach (var id in NearbyMerchantIds)
            if (Entities.TryGetValue(id, out var entity) && (predicate?.Invoke(entity) ?? true))
                ret.Add(entity);

        foreach (var id in NearbyAislingIds)
            if (Entities.TryGetValue(id, out var entity) && (predicate?.Invoke(entity) ?? true))
                ret.Add(entity);

        foreach (var id in NearbyGroundItemIds)
            if (Entities.TryGetValue(id, out var entity) && (predicate?.Invoke(entity) ?? true))
                ret.Add(entity);

        return ret;
    }

    public void Add(VisibleEntity entity)
    {
        using var @lock = Sync.Enter();
        
        switch (entity)
        {
            case GroundItem:
                NearbyGroundItemIds.Add(entity.Id);

                break;
            case Creature creature:
                switch (creature.Type)
                {
                    case CreatureType.Aisling:
                        NearbyAislingIds.Add(entity.Id);

                        break;
                    case CreatureType.Merchant:
                        NearbyMerchantIds.Add(entity.Id);

                        break;
                    default:
                        NearbyMonsterIds.Add(entity.Id);

                        break;
                }

                break;
        }
        
        Entities.Add(entity.Id, entity);
    }

    public void Add(Door door)
    {
        using var @lock = Sync.Enter();
        
        Doors.Add(door);
    }
    
    public void Remove(uint id)
    {
        using var @lock = Sync.Enter();
        
        if(!Entities.TryGetValue(id, out var entity))
            return;

        switch (entity)
        {
            case GroundItem:
                NearbyGroundItemIds.Remove(entity.Id);
                Entities.Remove(entity.Id);

                break;
            case Creature creature:
                switch (creature.Type)
                {
                    case CreatureType.Aisling:
                        NearbyAislingIds.Remove(entity.Id);

                        break;
                    case CreatureType.Merchant:
                        NearbyMerchantIds.Remove(entity.Id);
                        Entities.Remove(entity.Id);

                        break;
                    default:
                        NearbyMonsterIds.Remove(entity.Id);

                        //if creature is dead, remove it
                        //if we're on an ao sith map and the creature goes out of range, remove it
                        if ((creature.HealthPercent == 0)
                            || ((Client.ServerPoint.DistanceFrom(creature) > 10) && CONSTANTS.AO_SITH_MAPS.Contains(creature.Map.Name)))
                            Entities.Remove(entity.Id);
                        
                        break;
                }

                break;
            default:
                Entities.Remove(entity.Id);

                break;
        }
    }

    public void Clear(bool nearbyOnly = true)
    {
        using var @lock = Sync.Enter();

        NearbyAislingIds.Clear();
        NearbyGroundItemIds.Clear();
        NearbyMonsterIds.Clear();
        NearbyMerchantIds.Clear();
        Doors.Clear();
        
        if(!nearbyOnly)
            Entities.Clear();
    }
}