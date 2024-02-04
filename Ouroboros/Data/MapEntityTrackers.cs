using Ouroboros.Utilities;

namespace Ouroboros.Data;

public class MapEntityTrackers : WorldEntityTrackers
{
    public IdLocation? LastSeenLocation { get; set; }
    public DateTime? LastMoved { get; set; }
    public DateTime? LastMapChanged { get; set; }
    public DateTime? LastClicked { get; set; }
}