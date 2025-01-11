using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Switcher.Interfaces;
using Switcher.Managers.Adapters;
using Switcher.Managers.Config;
using Switcher.Models.Configs;
using Switcher.Models.Network;

namespace Switcher.ModelViews.Editor;

public partial class EditorViewModel(ConfigurationManager configurationManager, AdaptersManager adaptersManager) : ObservableObject
{
    public IWindowService? WindowService;
    [ObservableProperty] private AdapterConfiguration _adapterConfiguration = new ();
    [ObservableProperty] private ObservableCollection<NetworkAdapter> _adapters = new (adaptersManager.GetAdapters());
    [ObservableProperty] private NetworkAdapter? _selectedAdapter;
    
    [RelayCommand]
    public void Save()
    {
        AdapterConfiguration.NetworkInterface = SelectedAdapter;
        configurationManager.AddConfig(AdapterConfiguration);
        if(WindowService is not null) WindowService.CloseWindow();
    }

    public void WithAdapter(AdapterConfiguration adapterConfiguration)
    {
        AdapterConfiguration = adapterConfiguration;
        SelectedAdapter = Adapters.FirstOrDefault(x=> x.Id == AdapterConfiguration.NetworkInterface.Id);
        if(WindowService is not null) WindowService.CloseWindow();
    }
}