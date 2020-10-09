using NapistaTests.Models;
using OpenQA.Selenium.Appium.Service;
using System;
using Xunit;

namespace NapistaTests.Config
{
    [CollectionDefinition(nameof(AutomationMobileFixtureCollection))]
    public class AutomationMobileFixtureCollection : ICollectionFixture<AutomationMobileFixture> { }
    public class AutomationMobileFixture : IDisposable
    {
        public AppiumHelper BrowserHelper;
        public readonly Usuario usuario;
        public readonly AppiumLocalService service;
        public readonly ConfigurationHelper Configuration;


        public AutomationMobileFixture()
        {
            service = new AppiumServiceBuilder().Build();

            service.Start();

            Configuration = new ConfigurationHelper();
            BrowserHelper = new AppiumHelper(Configuration);

            usuario = new Usuario()
            {
                Email = "testedasilva1@grr.la",
                Password = "qee123"
            };


        }

        public void Dispose()
        {
            service.Dispose();
        }
    }
}
