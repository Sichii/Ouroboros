namespace Ouroboros.Data.Meta;

public sealed class WorldMeta
{
    public IDictionary<int, FieldMeta> Fields { get; set; } = new Dictionary<int, FieldMeta>();
    public IDictionary<short, MapMeta> Maps { get; set; } = new Dictionary<short, MapMeta>();
}