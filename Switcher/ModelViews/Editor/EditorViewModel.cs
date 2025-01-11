using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Switcher.Managers.Adapters;
using Switcher.Managers.Config;
using Switcher.Models.Configs;
using Switcher.Models.Network;

namespace Switcher.ModelViews.Editor;

public partial class EditorViewModel(ConfigurationManager configurationManager, AdaptersManager adaptersManager) : ObservableObject
{
    [ObservableProperty] private AdapterConfiguration _adapterConfiguration = new ();
    [ObservableProperty] private ObservableCollection<NetworkAdapter> _adapters = new (adaptersManager.GetAdapters());
    [ObservableProperty] private NetworkAdapter? _selectedAdapter;

    public bool IsCanEditDhcp => !AdapterConfiguration.IsAutoIpv4;
    
    [RelayCommand]
    public void Save()
    {
        AdapterConfiguration.NetworkInterface = _selectedAdapter;
        configurationManager.AddConfig(AdapterConfiguration);
    }
}