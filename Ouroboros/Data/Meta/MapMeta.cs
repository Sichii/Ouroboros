namespace Ouroboros.Data.Meta;

public sealed record MapMeta
{
    public short MapId { get; set; }
    public required string Name { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }
    public ICollection<WarpMeta> Warps { get; set; } = Array.Empty<WarpMeta>();
    public ICollection<FieldMetaRef> Fields { get; set; } = Array.Empty<FieldMetaRef>();
    public ICollection<GateMeta> Gates { get; set; } = Array.Empty<GateMeta>();
}