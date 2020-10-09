using NapistaTests.Models;
using OpenQA.Selenium.Appium.Service;
using System;
using System.IO;
using Xunit;

namespace NapistaTests.Config
{
    [CollectionDefinition(nameof(AutomationMobileFixtureCollection))]
    public class AutomationMobileFixtureCollection : ICollectionFixture<AutomationMobileFixture> { }
    public class AutomationMobileFixture : IDisposable
    {
        public AppiumHelper BrowserHelper;
        public readonly Usuario usuario;
        private AppiumLocalService service;
        public readonly ConfigurationHelper Configuration;
        public FileInfo log;


        public AutomationMobileFixture()
        {
            IniciarServidor();

            Configuration = new ConfigurationHelper();
            BrowserHelper = new AppiumHelper(Configuration);

            usuario = new Usuario()
            {
                Email = "testedasilva1@grr.la",
                Password = "qee123"
            };

        }

        public void IniciarServidor()
        {
            log = new FileInfo("Log.txt");
            service = new AppiumServiceBuilder().WithLogFile(log).Build();
            service.Start();

            
        }

        public void Dispose()
        {
            service?.Dispose();
        }
    }
}
