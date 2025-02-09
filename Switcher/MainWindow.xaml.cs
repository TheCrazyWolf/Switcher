﻿using Wpf.Ui.Appearance;
using MainConfigsViewModel = Switcher.ModelViews.Main.MainConfigsViewModel;

namespace Switcher;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    public MainWindow(MainConfigsViewModel viewModel)
    {
        InitializeComponent();
        ApplicationThemeManager.Apply(this);
        DataContext = viewModel;
        viewModel.RefreshAdapterConfigurationsCommand();
    }
}