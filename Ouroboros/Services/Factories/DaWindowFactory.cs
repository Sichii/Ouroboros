using System.IO;
using Ouroboros.Defintions;
using Ouroboros.Memory;
using Ouroboros.Services.Options;

namespace Ouroboros.Services.Factories;

public sealed class DaWindowFactory
{
    private readonly GeneralOptions GeneralOptions;
    public DaWindowFactory(GeneralOptions generalOptions) => GeneralOptions = generalOptions;
    
    public async Task<DaWindow> CreateAsync(MemoryEditFlags memoryEditFlags)
    {
        var path = Path.Combine(GeneralOptions.DarkAgesPath, "Darkages.exe");
        
        var window = DaWindow.Create(path);
        
        if (GeneralOptions.InjectDawnd)
            await window.InjectDawndAsync();
        
        window.ApplyMemoryEdits(memoryEditFlags);
        
        await window.WaitForHandleAsync();
        
        window.Resize(WindowSize.Small);
        
        return window;
    }
}