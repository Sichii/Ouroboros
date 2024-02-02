namespace Ouroboros.Utilities;

public sealed class AsyncSignal
{
    private TaskCompletionSource Tcs = new();
    
    public async Task WaitAsync()
    {
        await Tcs.Task;
        
        Tcs = new TaskCompletionSource();
    }

    public void Pulse() => Tcs.TrySetResult();
}