using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Switcher.Managers.Config;
using Switcher.Models.Configs;

namespace Switcher.ModelViews.Editor;

public partial class EditorViewModel(ConfigurationManager configurationManager) : ObservableObject
{
    [ObservableProperty] private AdapterConfiguration _adapterConfiguration = new ();
    
    [RelayCommand]
    public void RefreshAdapterConfigurationsCommand()
    {
    }
    
    [RelayCommand]
    public void Apply(AdapterConfiguration adapterConfiguration)
    {
        // TO DO APPLY
    }
}