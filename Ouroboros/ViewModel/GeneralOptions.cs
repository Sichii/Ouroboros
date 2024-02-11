using Ouroboros.Defintions;
using Ouroboros.ViewModel.Abstractions;

namespace Ouroboros.ViewModel;

public sealed class GeneralOptions : NotifyPropertyChangedBase
{
    private string _darkAgesPath = CONSTANTS.DEFAULT_DARKAGES_DIRECTORY;
    private WindowSize _windowSize = WindowSize.Small;
    private bool _injectDawnd;
    private bool _darkTheme = true;
    private bool _logRawPackets = false;

    public string DarkAgesPath
    {
        get => _darkAgesPath;
        set => SetField(ref _darkAgesPath, value);
    }

    public WindowSize WindowSize
    {
        get => _windowSize;
        set => SetField(ref _windowSize, value);
    }

    public bool InjectDawnd
    {
        get => _injectDawnd;
        set => SetField(ref _injectDawnd, value);
    }

    public bool DarkTheme
    {
        get => _darkTheme;
        set => SetField(ref _darkTheme, value);
    }
    
    public bool LogRawPackets
    {
        get => _logRawPackets;
        set => SetField(ref _logRawPackets, value);
    }
}