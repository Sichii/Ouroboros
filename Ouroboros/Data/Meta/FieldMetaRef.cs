using Chaos.Geometry;

namespace Ouroboros.Data.Meta;

public sealed record FieldMetaRef
{
    public int FieldId { get; set; }
    public Point SourcePoint { get; set; }
}