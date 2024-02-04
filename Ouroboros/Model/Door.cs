using Chaos.Geometry.EqualityComparers;
using Ouroboros.Data;

namespace Ouroboros.Model;

public class Door : MapEntity, IEquatable<Door>
{
    public bool Closed { get; set; }

    /// <inheritdoc />
    public Door(
        Map map,
        int x,
        int y,
        bool closed,
        MapEntityTrackers? trackers = null)
        : base(
            map,
            x,
            y,
            trackers)
        => Closed = closed;

    #region IEquatable
    /// <inheritdoc />
    public bool Equals(Door? other)
    {
        if (ReferenceEquals(null, other))
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return LocationEqualityComparer.Instance.Equals(this, other);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj))
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        if (obj.GetType() != GetType())
            return false;

        return Equals((Door)obj);
    }

    /// <inheritdoc />
    public override int GetHashCode() => throw new NotImplementedException();

    public static bool operator ==(Door? left, Door? right) => Equals(left, right);
    public static bool operator !=(Door? left, Door? right) => !Equals(left, right);
    #endregion
}