using Switcher.Managers.Adapters;
using Switcher.Managers.Config;
using Switcher.Models.Configs;
using Wpf.Ui.Appearance;

namespace Switcher;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    private readonly ConfigurationManager _configurationManager;
    public MainWindow(ConfigurationManager configurationManager, IpManager ipManager, AdaptersManager adaptersManager)
    {
        _configurationManager = configurationManager;
        InitializeComponent();
        ApplicationThemeManager.Apply(this);
        _configurationManager.GetAdapterConfigurations();
        var adapters = adaptersManager.GetAdapters();
        var s = adapters[1].Description;
        ipManager.SetDns(new AdapterConfiguration()
        {
            
        }, s);
    }
}