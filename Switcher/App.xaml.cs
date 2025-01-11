using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Switcher.Managers.Adapters;
using Switcher.Managers.Config;
using Switcher.ModelViews;
using MainConfigsViewModel = Switcher.ModelViews.Main.MainConfigsViewModel;

namespace Switcher;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private IServiceProvider _serviceProvider = null!;
    protected override void OnStartup(StartupEventArgs e)
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        _serviceProvider = serviceCollection.BuildServiceProvider();
        var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
    
    private void ConfigureServices(IServiceCollection services)
    { 
        services.AddSingleton<MainWindow>();
        services.AddSingleton<MainConfigsViewModel>();
        services.AddSingleton<ConfigurationManager>();
        services.AddScoped<ProxyManager>();
        services.AddScoped<IpManager>();
        services.AddScoped<AdaptersManager>();
        services.AddScoped<DnsManager>();
    }

    protected override void OnExit(ExitEventArgs e)
    {
        if (_serviceProvider is IDisposable disposable)
        {
            disposable.Dispose();
        }
    }
}