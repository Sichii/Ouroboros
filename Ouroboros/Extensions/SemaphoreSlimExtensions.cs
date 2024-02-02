namespace Ouroboros.Extensions;

public static class SemaphoreSlimExtensions
{
    public static void TryRelease(this SemaphoreSlim semaphore)
    {
        try
        {
            semaphore.Release();
        }
        catch
        {
            // ignored
        }
    }
}