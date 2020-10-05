using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NapistaTests.Config
{
    [CollectionDefinition(nameof(AutomationMobileFixtureCollection))]
    public class AutomationMobileFixtureCollection : ICollectionFixture<AutomationMobileFixture> { }
    public class AutomationMobileFixture
    {
        public AppiumHelper BrowserHelper;
        public readonly ConfigurationHelper Configuration;

        public AutomationMobileFixture()
        {
            Configuration = new ConfigurationHelper();
            BrowserHelper = new AppiumHelper(Configuration);
        }
    }
}
