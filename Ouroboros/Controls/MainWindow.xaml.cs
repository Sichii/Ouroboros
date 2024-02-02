using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Ouroboros.Defintions;
using Ouroboros.Services.Factories;
using Ouroboros.Services.Managers;

namespace Ouroboros.Controls;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public sealed partial class MainWindow
{
    private readonly DaWindowFactory DaWindowFactory;
    private readonly ClientManager ClientManager;

    public MainWindow(DaWindowFactory daWindowFactory, ClientManager clientManager)
    {
        DaWindowFactory = daWindowFactory;
        ClientManager = clientManager;
        
        InitializeComponent();
    }

    #region TopBar UI
    private void CloseButton_Click(object sender, RoutedEventArgs e) => Close();

    private void MinimizeButton_Click(object sender, RoutedEventArgs e) => WindowState = WindowState.Minimized;

    private void HamburgerButton_Click(object sender, RoutedEventArgs e)
    {
        DrawerHost.IsLeftDrawerOpen = !DrawerHost.IsLeftDrawerOpen;
    }

    #endregion TopBar UI

    private async void LaunchBtn_Click(object sender, RoutedEventArgs e)
    {
        var window = await DaWindowFactory.CreateAsync(MemoryEditFlags.AllExceptWalls)
                                          .ConfigureAwait(false);

        ClientManager.AddWindow(window);
    }

    private void OptionsButton_Click(object sender, RoutedEventArgs e)
    {
        var options = App.Instance.Provider.GetRequiredService<OptionsWindow>();
        options.Owner = this;
        options.WindowStartupLocation = WindowStartupLocation.CenterOwner;
        options.Show();
    }
}