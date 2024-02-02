using Ouroboros.Defintions;

namespace Ouroboros.Services.Options;

public sealed class GeneralOptions
{
    public string DarkAgesPath { get; set; } = CONSTANTS.DEFAULT_DARKAGES_DIRECTORY;
    public bool InjectDawnd { get; set; }
    public WindowSize WindowSize { get; set; } = WindowSize.Small;
}