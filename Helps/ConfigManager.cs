using demo.Helps;
using RexHelps;
using System.Collections.Generic;
using System.Linq;

public class ConfigManager
{
    private string _configFilePath;

    public ConfigManager(string configFilePath)
    {
        _configFilePath = configFilePath;
    }

    // 从 INI 文件加载配置
    public ProductConfig LoadConfig(string camera)
    {
        RIni ini = new RIni(_configFilePath);
        var section = $"[{camera}]";
        // 读取指定节的所有键值对
        var keyValuePairs = ini.ReadSection(section);
        // 将键值对转换为字典
        var engineeringSettings = keyValuePairs
            .Where(kv => kv.Key.StartsWith("camera"))
            .ToDictionary(kv => kv.Key, kv => kv.Value);

        var config = new ProductConfig
        {
            EngineeringSettings = engineeringSettings,
        };

        return config;
    }

    // 保存配置到 INI 文件
    public void SaveConfig(string productModel,string key,string value)
    {
        RIni ini = new RIni(_configFilePath);
        var section = $"[{productModel}]";
        ini.DeleteKey(section, key); // 删除旧节
        ini.WriteValue(section, key, value);
    }
}