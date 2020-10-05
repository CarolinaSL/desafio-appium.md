using Microsoft.Extensions.Configuration;
using System.IO;

namespace NapistaTests.Config
{
    public class ConfigurationHelper
    {
        private readonly IConfiguration _config;

        public ConfigurationHelper()
        {
            _config = new ConfigurationBuilder()
                .AddJsonFile("appSettings.json")
                .Build();
        }


        public string WebDrivers => $"{_config.GetSection("WebDrivers").Value}";
        public string FolderPath => Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
        public string AppiumServer => $"{_config.GetSection("AppiumServer").Value}";
        public string DeviceName => $"{_config.GetSection("deviceName").Value}";
        public string PlatformName => $"{_config.GetSection("platformName").Value}";
        public string app => $"{_config.GetSection("app").Value}";

    }
}