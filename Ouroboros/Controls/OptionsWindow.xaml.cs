using MaterialDesignThemes.Wpf;
using System.Windows;
using Ouroboros.Services.Options;

namespace Ouroboros.Controls
{
    /// <summary>
    /// Interaction logic for OptionsWindow.xaml
    /// </summary>
    public sealed partial class OptionsWindow
    {
        public GeneralOptions GeneralOptions { get; }

        public OptionsWindow(GeneralOptions generalOptions)
        {
            GeneralOptions = generalOptions;
            InitializeComponent();
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e) => Close();

        private void ThemeToggle_OnChecked(object sender, RoutedEventArgs e)
        {
            var paletteHelper = new PaletteHelper();
            var theme = paletteHelper.GetTheme();

            theme.SetBaseTheme(Theme.Light);

            paletteHelper.SetTheme(theme);
        }

        private void ThemeToggle_OnUnchecked(object sender, RoutedEventArgs e)
        {
            var paletteHelper = new PaletteHelper();
            var theme = paletteHelper.GetTheme();

            theme.SetBaseTheme(Theme.Dark);

            paletteHelper.SetTheme(theme);
        }
        
        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".exe",
                Filter = "Executables (*.exe)|*.exe"
            };
            
            var result = dlg.ShowDialog();
            
            if (result == true)
            {
                var filename = dlg.FileName;
                GeneralOptions.DarkAgesPath = filename;
            }
        }
    }
}
