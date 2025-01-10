namespace Switcher.Models.Configs.Proxy;

public class ConfigurationProxy
{
    // ReSharper disable once InconsistentNaming
    public string IPv4 { get; set; } = string.Empty;
    public int Port { get; set; }
    public bool DontUserForLocallyAdres { get; set; }
}