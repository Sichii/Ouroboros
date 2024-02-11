using Ouroboros.Utilities;

namespace Ouroboros.Data.Meta;

public sealed record FieldMeta
{
    public int FieldId { get; set; }
    public ICollection<IdLocation> Destinations { get; set; } = Array.Empty<IdLocation>();
}