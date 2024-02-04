using Chaos.Common.Definitions;
using Chaos.Geometry.Abstractions.Definitions;

namespace Ouroboros.Data;

public class CreatureTrackers : MapEntityTrackers
{
    public Direction? LastSeenDirection { get; set; }
    public DateTime? LastTalked { get; set; }
    public string? LastTalkedText { get; set; }
    public DateTime? LastTurned { get; set; }
    public DateTime? LastWalked { get; set; }
    public Direction? LastWalkedDirection { get; set; }
    public DateTime? LastAnimated { get; set; }
    public Animation? LastAnimation { get; set; }
    public DateTime? LastHealthShown { get; set; }
    public DateTime? LastBodyAnimated { get; set; }
    public BodyAnimation? LastBodyAnimation { get; set; }
    public Dictionary<ushort, DateTime> AnimationHistory { get; set; } = new();
}