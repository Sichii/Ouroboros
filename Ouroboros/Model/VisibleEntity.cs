using Ouroboros.Data;

namespace Ouroboros.Model;

public abstract class VisibleEntity : MapEntity, IEquatable<VisibleEntity>
{
    public uint Id { get; }
    public ushort Sprite { get; init; }
    
    protected VisibleEntity(uint id, Map map, ushort sprite, int x, int y, MapEntityTrackers? trackers = null)
        : base(map, x, y, trackers)
    {

        Id = id;
        Sprite = sprite;
    }

    #region IEquatable
    /// <inheritdoc />
    public bool Equals(VisibleEntity? other)
    {
        if (ReferenceEquals(null, other))
            return false;

        if (ReferenceEquals(this, other))
            return true;

        return Id == other.Id;
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

        return Equals((VisibleEntity)obj);
    }

    /// <inheritdoc />
    public override int GetHashCode() => (int)Id;

    public static bool operator ==(VisibleEntity? left, VisibleEntity? right) => Equals(left, right);
    public static bool operator !=(VisibleEntity? left, VisibleEntity? right) => !Equals(left, right);
    #endregion
}