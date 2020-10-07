using Microsoft.Extensions.Configuration;
using System.IO;
using System.Reflection;

namespace NapistaTests.Config
{
    public class ConfigurationHelper
    {
        private readonly IConfiguration _config;

        public ConfigurationHelper()
        {
            _config = new ConfigurationBuilder()
                .SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
                .AddJsonFile("appSettings.json")
                .Build();
        }

        public string FolderPath => Path.GetDirectoryName(Path.GetDirectoryName(Directory.GetCurrentDirectory()));
        public string AppiumServer => $"{_config.GetSection("AppiumServer").Value}";
        public string DeviceName => $"{_config.GetSection("deviceName").Value}";
        public string PlatformName => $"{_config.GetSection("platformName").Value}";
        public string app => "C:\\Users\\Carolina\\Workspace\\desafio-appium.md\\DesafioAppiumNapista\\NapistaTests\\app-release.apk";
        public string avd => $"{_config.GetSection("avd").Value}";

    }
}