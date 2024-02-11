namespace Ouroboros.Services.Pathfinding;

public sealed class RouteNode : IEquatable<RouteNode>
{
    public short MapId { get; init; }
    public RouteNode[] Neighbors { get; set; } = Array.Empty<RouteNode>();
    public RouteNode? Parent { get; set; }
    public bool Open { get; set; }
    public bool Closed { get; set; }
    public int AccumulatedCost { get; set; }
    
    public void Reset()
    {
        Open = false;
        Closed = false;
        Parent = null;
        AccumulatedCost = 0;
    }

    #region IEquatable
    /// <inheritdoc />
    public bool Equals(RouteNode? other)
    {
        if (ReferenceEquals(null, other))
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return MapId == other.MapId;
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        if (obj.GetType() != this.GetType())
            return false;

        return Equals((RouteNode)obj);
    }

    /// <inheritdoc />
    public override int GetHashCode() => MapId.GetHashCode();

    public static bool operator ==(RouteNode? left, RouteNode? right) => Equals(left, right);
    public static bool operator !=(RouteNode? left, RouteNode? right) => !Equals(left, right);
    #endregion
}