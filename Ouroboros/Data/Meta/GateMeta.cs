using Chaos.Geometry;
using Ouroboros.Utilities;

namespace Ouroboros.Data.Meta;

public sealed record GateMeta
{
    public Point SourcePoint { get; set; }
    public required IdLocation Destination { get; set; }
    public required string Id { get; set; }
}