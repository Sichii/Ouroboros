using System.Windows;
using Ouroboros.Defintions;
using Ouroboros.Memory;
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

    private async void LaunchBtn_Click(object sender, RoutedEventArgs e)
    {
        var window = await DaWindowFactory.CreateAsync(MemoryEditFlags.AllExceptWalls)
                                          .ConfigureAwait(false);

        ClientManager.AddWindow(window);
    }
}