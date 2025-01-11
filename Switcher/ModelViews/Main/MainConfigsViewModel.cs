using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Switcher.Managers.Adapters;
using Switcher.Managers.Config;
using Switcher.Models.Configs;

namespace Switcher.ModelViews.Main;

public partial class MainConfigsViewModel(ConfigurationManager configurationManager, 
    ApplyNetworkConfigManager applyNetworkConfigManager,
    IServiceProvider serviceProvider) : ObservableObject
{
    
    [ObservableProperty] private ObservableCollection<AdapterConfiguration> _adapterConfigurations = [];
    
    [RelayCommand]
    public void RefreshAdapterConfigurationsCommand()
    {
        ReloadConfigurations();
    }
    
    [RelayCommand]
    public void Apply(AdapterConfiguration adapterConfiguration)
    {
        applyNetworkConfigManager.SetGlobally(adapterConfiguration);
    }
    
    [RelayCommand]
    public void Edit(AdapterConfiguration adapterConfiguration)
    {
        var secondWindow = serviceProvider.GetRequiredService<Windows.Editor.Editor>();
        secondWindow.ViewModel.WithAdapter(adapterConfiguration);
        secondWindow.ShowDialog();
        ReloadConfigurations();
    }
    
    [RelayCommand]
    public void Create()
    {
        var secondWindow = serviceProvider.GetRequiredService<Windows.Editor.Editor>();
        secondWindow.ShowDialog();
        ReloadConfigurations();
    }

    public void ReloadConfigurations()
    {
        AdapterConfigurations = new ObservableCollection<AdapterConfiguration>(configurationManager.GetAdapterConfigurations());
    }
}