namespace Ouroboros.Utilities;

public sealed class HandlerResult
{
    public static HandlerResult Default { get; } = new();
    
    public static HandlerResult Edited { get; } = new()
    {
        UseOriginal = false
    };

    public static HandlerResult Canceled { get; } = new()
    {
        Cancel = true
    };
    
    public bool Cancel { get; init; }
    public bool UseOriginal { get; init; } = true;
}