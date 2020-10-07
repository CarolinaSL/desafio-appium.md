using Microsoft.Extensions.Configuration;
using System;
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

        public string AppiumServer => $"{_config.GetSection("AppiumServer").Value}";
        public string DeviceName => $"{_config.GetSection("deviceName").Value}";
        public string PlatformName => $"{_config.GetSection("platformName").Value}";
        public string app => Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, _config.GetSection("app").Value);
        public string avd => $"{_config.GetSection("avd").Value}";

    }
}