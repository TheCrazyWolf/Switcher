using System.Diagnostics.CodeAnalysis;
using Microsoft.Win32;
using Switcher.Models.Configs;

namespace Switcher.Managers.Adapters;

[SuppressMessage("Interoperability", "CA1416:Проверка совместимости платформы")]
public class ProxyManager
{
    private const string RegistryKeyPath = @"Software\Microsoft\Windows\CurrentVersion\Internet Settings";
    
    public void SetProxy(AdapterConfiguration configurationProxy)
    {
        using RegistryKey? key = Registry.CurrentUser.OpenSubKey(RegistryKeyPath, writable: true);
        if (key == null) return;
        key.SetValue("ProxyEnable", configurationProxy.UseProxy ? 1 : 0, RegistryValueKind.DWord);
        if (configurationProxy.UseProxy) key.SetValue("ProxyServer", configurationProxy.UseProxy, RegistryValueKind.String);
        else key.DeleteValue("ProxyServer", throwOnMissingValue: false);
    }
}