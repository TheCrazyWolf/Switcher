﻿using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Switcher.Managers.Adapters;
using Switcher.Managers.Config;
using Switcher.Models.Configs;

namespace Switcher.ModelViews.Editor;

public partial class EditorViewModel(ConfigurationManager configurationManager, AdaptersManager adaptersManager) : ObservableObject
{
    [ObservableProperty] private AdapterConfiguration _adapterConfiguration = new ();
    [ObservableProperty] private ObservableCollection<NetworkInterface> _adapters = new (adaptersManager.GetAdapters());
    [ObservableProperty] private NetworkInterface? _selectedAdapter;
    
    [RelayCommand]
    public void Apply(AdapterConfiguration adapterConfiguration)
    {
        // TO DO APPLY
    }
}