using Chaos.Common.Definitions;
using Chaos.Geometry.Abstractions.Definitions;

namespace Ouroboros.Model;

public class Merchant : Creature
{
    public string Name { get; }

    public Merchant(
        uint id,
        Map map,
        ushort sprite,
        int x,
        int y,
        Direction direction,
        string name)
        : base(
            id,
            map,
            sprite,
            x,
            y,
            CreatureType.Merchant,
            direction)
        => Name = name;
}