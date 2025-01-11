﻿using Switcher.Models.Configs.Dns;
using Switcher.Models.Configs.IP;
using Switcher.Models.Configs.Proxy;

namespace Switcher.Models.Configs;

public class AdapterConfiguration
{
    public string Id { get; private set; } = Guid.NewGuid().ToString().Split("-").First();
    public string DisplayName { get; set; } = string.Empty;
    public string AdapterName { get; set; } = string.Empty;
    public bool IsAutoIpv4 { get; set; }
    // ReSharper disable once InconsistentNaming
    public ConfigurationIPv4 IPv4 { get; set; } = new ConfigurationIPv4();
    public bool IsAutoDns { get; set; }
    public ConfigurationDns Dns { get; set; } = new ConfigurationDns();
    public bool UseProxy { get; set; }
    public ConfigurationProxy Proxy { get; set; } = new ConfigurationProxy();
}