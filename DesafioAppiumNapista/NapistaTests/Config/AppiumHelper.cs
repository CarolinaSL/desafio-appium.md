using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace NapistaTests.Config
{
    public class AppiumHelper
    {
        public IWebDriver WebDriver;
        public readonly ConfigurationHelper Configuration;
        public OpenQA.Selenium.Support.UI.WebDriverWait Wait;

        public AppiumHelper(ConfigurationHelper configuration)
        {
            var driverOption = new AppiumOptions();
            driverOption.AddAdditionalCapability(MobileCapabilityType.PlatformName, configuration.PlatformName);
            driverOption.AddAdditionalCapability(MobileCapabilityType.DeviceName, configuration.DeviceName);
            driverOption.AddAdditionalCapability(MobileCapabilityType.App, configuration.app);

            WebDriver = new AndroidDriver<IWebElement>(new Uri(configuration.AppiumServer), driverOption);


            Wait = new OpenQA.Selenium.Support.UI.WebDriverWait(WebDriver, TimeSpan.FromSeconds(30));
        }

        public string ObterUrl()
        {
            return WebDriver.Url;
        }

        public void IrParaUrl(string url)
        {
            WebDriver.Navigate().GoToUrl(url);
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

        public void PreencherTextBoxPorId(string idCampo, string valorCampo)
        {
            var campo = Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(idCampo)));
            campo.SendKeys(valorCampo);
        }
        private bool ElementoExistente(By by)
        {
            try
            {
                WebDriver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool ValidarSeElementoExistePorIr(string id)
        {
            return ElementoExistente(By.Id(id));
        }

        public void Dispose()
        {
            WebDriver.Quit();
            WebDriver.Dispose();
        }
    }
}
