namespace Ouroboros.Data;

public class AislingTrackers : CreatureTrackers
{
    public DateTime? LastChanted { get; set; }
    public string? LastChantedText { get; set; }
}