using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.WaitHelpers;
using System;

namespace NapistaTests.Config
{
    public class AppiumHelper
    {
        public AppiumDriver<AndroidElement> Driver;
        public readonly ConfigurationHelper Configuration;
        public OpenQA.Selenium.Support.UI.WebDriverWait Wait;

        public AppiumHelper(ConfigurationHelper configuration)
        {
            var driverOption = new AppiumOptions();
            driverOption.AddAdditionalCapability(MobileCapabilityType.PlatformName, configuration.PlatformName);
            driverOption.AddAdditionalCapability(MobileCapabilityType.DeviceName, configuration.DeviceName);
            driverOption.AddAdditionalCapability(MobileCapabilityType.App, configuration.app);
            driverOption.AddAdditionalCapability("avd", configuration.avd);

            Driver = new AndroidDriver<AndroidElement>(new Uri(configuration.AppiumServer), driverOption);

            var contexts = ((IContextAware)Driver).Contexts;
            Wait = new OpenQA.Selenium.Support.UI.WebDriverWait(Driver, TimeSpan.FromSeconds(30));
        }

        public string ObterUrl()
        {
            return Driver.Url;
        }

        public void IrParaUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public bool ValidarConteudoUrl(string conteudo)
        {
            return Wait.Until(ExpectedConditions.UrlContains(conteudo));
        }

        public void ClicarBotaoPorId(string botaoId)
        {
            var botao = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(botaoId)));
            botao.Click();
        }

        public void ClicarBotaoPorTexto(string texto)
        {
            var botao = Wait.Until(ExpectedConditions.ElementIsVisible(By.Name(texto)));
            botao.Click();
        }

        public void ClicarPorXPath(string xPath)
        {
            var elemento = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPath)));
            elemento.Click();
        }

        public IWebElement ObterElementoPorClasse(string classeCss)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(classeCss)));
        }

        public IWebElement ObterElementoPorXPath(string xPath)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xPath)));
        }

        internal string ObterValorTextBoxPorXPath(string path)
        {
            var elem = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(path)));
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(path)))
                .GetAttribute("text");
        }

        public string ObterTextoElementoPorId(string id)
        {
            return Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(id))).Text;
        }

        public void PreencherTextBoxPorId(string idCampo, string valorCampo)
        {
            var campo = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(idCampo)));
            campo.SendKeys(valorCampo);
        }

        public void PreencherTextBoxPorXPath(string path, string valorCampo)
        {
            var campo = Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(path)));
            campo.Click();
            Actions action = new Actions(Driver);
            action.SendKeys(valorCampo).Perform();
        }
        private bool ElementoExistente(By by)
        {
            try
            {
                Driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool ValidarSeElementoExistePorId(string id)
        {
            return ElementoExistente(By.Id(id));
        }

        public bool ValidarSeElementoExistePorXPath(string path)
        {
            try
            {
                var element = ObterElementoPorXPath(path);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool ValidarSeElementoExistePorTexto(string texto)
        {
            return ElementoExistente(By.Name(texto));
        }

        public void Dispose()
        {
            Driver.CloseApp();
            Driver.Quit();
            Driver.Dispose();
           

        }
    }
}
