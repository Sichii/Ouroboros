using System.ComponentModel;
using System.Windows;
using Chaos.Extensions.Common;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using Ouroboros.Abstractions;
using Ouroboros.Defintions;
using Ouroboros.ViewModel;

namespace Ouroboros.Controls;

/// <summary>
///     Interaction logic for OptionsWindow.xaml
/// </summary>
public sealed partial class OptionsWindow
{
    public IStorage<GeneralOptions> GeneralOptions { get; }

    public OptionsWindow(IStorage<GeneralOptions> generalOptions)
    {
        GeneralOptions = generalOptions;
        DataContext = GeneralOptions.Value;
        
        InitializeComponent();
    }

    private void BrowseButton_Click(object sender, RoutedEventArgs e)
    {
        var dlg = new OpenFileDialog
        {
            DefaultExt = ".exe",
            Filter = "Executables (*.exe)|*.exe"
        };

        var success = dlg.ShowDialog();

        if (success == true)
        {
            var path = dlg.FileName;
            GeneralOptions.Value.DarkAgesPath = path;
        }
    }

    private void CloseButton_Click(object sender, RoutedEventArgs e) => Close();

    private async void OptionsWindow_OnClosing(object? sender, CancelEventArgs e)
    {
        try
        {
            await GeneralOptions.SaveAsync()
                                .ConfigureAwait(false);
        } catch
        {
            //ignored
        }
    }

    private void SetBaseTheme(IBaseTheme baseTheme)
    {
        var paletteHelper = new PaletteHelper();
        var theme = paletteHelper.GetTheme();

        theme.SetBaseTheme(baseTheme);

        paletteHelper.SetTheme(theme);
    }

    private void ThemeToggle_OnChecked(object sender, RoutedEventArgs e) => SetBaseTheme(Theme.Dark);

    private void ThemeToggle_OnUnchecked(object sender, RoutedEventArgs e) => SetBaseTheme(Theme.Light);

    private void OptionsWindow_OnInitialized(object? sender, EventArgs e)
    {
        WindowSizeCmbox.ItemsSource = EnumExtensions.GetEnumNames<WindowSize>();
    }
}