using System.IO;
using Ouroboros.Abstractions;
using Ouroboros.Defintions;
using Ouroboros.Memory;
using Ouroboros.ViewModel;

namespace Ouroboros.Services.Factories;

public sealed class DaWindowFactory
{
    private readonly GeneralOptions GeneralOptions;
    public DaWindowFactory(IReadOnlyStorage<GeneralOptions> generalOptions) => GeneralOptions = generalOptions.Value;
    
    public async Task<DaWindow> CreateAsync(MemoryEditFlags memoryEditFlags)
    {
        var path = Path.Combine(GeneralOptions.DarkAgesPath, "Darkages.exe");
        
        var window = DaWindow.Create(path);
        
        if (GeneralOptions.InjectDawnd)
            await window.InjectDawndAsync();
        
        window.ApplyMemoryEdits(memoryEditFlags);
        
        await window.WaitForHandleAsync();
        
        window.Resize(GeneralOptions.WindowSize);
        
        return window;
    }
}