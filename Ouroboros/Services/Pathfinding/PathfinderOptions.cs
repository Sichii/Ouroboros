using Chaos.Geometry.Abstractions;
using Chaos.Geometry.EqualityComparers;

namespace Ouroboros.Services.Pathfinding;

public sealed class PathfinderOptions
{
    public bool IgnoreWalls { get; set; }
    public HashSet<IPoint> BlockedPoints { get; set; } = new(PointEqualityComparer.Instance);
    public int? MaxRadius { get; set; }
}