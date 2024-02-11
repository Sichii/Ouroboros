using Chaos.Geometry;
using Ouroboros.Utilities;

namespace Ouroboros.Data.Meta;

public sealed record WarpMeta
{
    public Point SourcePoint { get; set; }
    public required IdLocation Destination { get; set; }
}