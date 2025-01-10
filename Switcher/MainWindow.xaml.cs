using Switcher.Managers.Config;
using Wpf.Ui.Appearance;

namespace Switcher;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    private readonly ConfigurationManager _configurationManager;
    public MainWindow(ConfigurationManager configurationManager)
    {
        _configurationManager = configurationManager;
        InitializeComponent();
        ApplicationThemeManager.Apply(this);
        _configurationManager.GetAdapterConfigurations();
    }
}