using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using Switcher.Managers.Config;
using Switcher.Models.Configs;

namespace Switcher.ModelViews.Main;

public partial class MainConfigsViewModel(ConfigurationManager configurationManager, IServiceProvider serviceProvider) : ObservableObject
{
    
    [ObservableProperty] private ObservableCollection<AdapterConfiguration> _adapterConfigurations = [];
    
    [RelayCommand]
    public void RefreshAdapterConfigurationsCommand()
    {
        AdapterConfigurations = new ObservableCollection<AdapterConfiguration>(configurationManager.GetAdapterConfigurations());
    }
    
    [RelayCommand]
    public void Apply(AdapterConfiguration adapterConfiguration)
    {
        // TO DO APPLY
    }
    
    [RelayCommand]
    public void Edit(AdapterConfiguration adapterConfiguration)
    {
        var secondWindow = serviceProvider.GetRequiredService<Windows.Editor.Editor>();
        secondWindow.ViewModel.AdapterConfiguration = adapterConfiguration;
        secondWindow.ShowDialog();
    }
    
}