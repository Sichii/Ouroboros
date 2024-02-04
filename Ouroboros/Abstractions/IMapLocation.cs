using Chaos.Geometry.Abstractions;
using Ouroboros.Model;

namespace Ouroboros.Abstractions;

public interface IIdLocation : ILocation
{
    public ushort MapId { get; }
}