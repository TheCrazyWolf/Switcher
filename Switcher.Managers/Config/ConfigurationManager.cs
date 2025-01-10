using Newtonsoft.Json;
using Switcher.Models.Configs;

namespace Switcher.Managers.Config;

public class ConfigurationManager
{
    const string ConfigFile = "config.json";
    private IList<AdapterConfiguration> _adapterConfigurations = new List<AdapterConfiguration>();
    
    public ConfigurationManager()
    {
        OpenConfig();
    }

    public IList<AdapterConfiguration> GetAdapterConfigurations()
    {
        return _adapterConfigurations;
    }
    
    public void OpenConfig()
    {
        if (File.Exists(ConfigFile))
        {
            _adapterConfigurations =
                JsonConvert.DeserializeObject<List<AdapterConfiguration>>(File.ReadAllText(ConfigFile)) ??
                [];
        }
        else
        {
            SaveConfig();
        }
    }

    public void SaveConfig()
    {
        File.WriteAllText(ConfigFile, JsonConvert.SerializeObject(_adapterConfigurations));
    }

    public void AddConfig(AdapterConfiguration adapterConfiguration)
    {
        _adapterConfigurations.Add(adapterConfiguration);
        SaveConfig();
    }
}