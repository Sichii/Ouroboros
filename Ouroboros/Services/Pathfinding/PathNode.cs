using Chaos.Geometry.Abstractions;
using Chaos.Geometry.EqualityComparers;

namespace Ouroboros.Services.Pathfinding;

internal sealed class PathNode(int x, int y) : IEquatable<IPoint>, IPoint
{
    public bool Closed { get; set; } = true;

    /// <summary>
    ///     The node is blacklisted. Blacklisted nodes are not to ever be opened, and you shouldn't walk onto them even if it's
    ///     the last point in the path
    /// </summary>
    public bool IsBlackListed { get; set; }

    /// <summary>
    ///     The node is blocked. Blocked nodes are opened, but cannot be ignored. Blocked nodes can be walked on if it's the
    ///     last point in the path.
    /// </summary>
    public bool IsBlocked { get; set; }

    /// <summary>
    ///     The node is a wall. Walls are opened, and can be ignored depending on the pathfinding request
    /// </summary>
    public bool IsWall { get; set; }

    public bool Open { get; set; }
    public PathNode? Parent { get; set; }
    public PathNode?[] Neighbors { get; } = new PathNode?[4];
    public int X { get; } = x;
    public int Y { get; } = y;

    #region IEquatable
    public bool Equals(IPoint? other) => PointEqualityComparer.Instance.Equals(this, other);

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        return Equals((IPoint)obj);
    }

    public override int GetHashCode() => PointEqualityComparer.Instance.GetHashCode(this);
    #endregion

    public bool IsWalkable(bool ignoreWalls) => !IsBlackListed && !IsBlocked && (ignoreWalls || !IsWall);

    public void Reset()
    {
        Closed = IsBlackListed;
        Open = false;
        Parent = null;
        IsBlocked = false;
    }
}