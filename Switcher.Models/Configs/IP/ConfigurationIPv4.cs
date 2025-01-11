// ReSharper disable InconsistentNaming
namespace Switcher.Models.Configs.IP;

public class ConfigurationIPv4
{
    public string IPAddress { get; set; } = string.Empty;
    public string SubnetMask { get; set; } = string.Empty;
    public string DefaultIPGateway { get; set; } = string.Empty;
}