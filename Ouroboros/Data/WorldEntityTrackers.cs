namespace Ouroboros.Data;

public class WorldEntityTrackers
{
    public DateTime Creation { get; } = DateTime.UtcNow;
    public DateTime? LastSeen { get; set; }
    public DateTime? LastAction { get; set; }
}