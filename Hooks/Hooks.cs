using BoDi;
using CdsAssessment.Drivers;
using CdsAssessment.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace CdsAssessment.Hooks
{
    [Binding]
    public sealed class Hooks : DriverHelper
    {
        IObjectContainer objectContainer;
        public Hooks(IObjectContainer objectContainer) => this.objectContainer = objectContainer;
       

        private IWebDriver RunBrowserType(BrowserType BrowserName) => BrowserName switch
        {
            BrowserType.Chrome => new ChromeDriver(),
            BrowserType.Firefox => new FirefoxDriver(),
            _ => throw new NotImplementedException("driver not available")
        };

        [BeforeScenario]
        public void BeforeScenario()
        {
            browser = RunBrowserType(BrowserType.Chrome);
            browser.Manage().Window.Maximize();
            new DriverManager().SetUpDriver(new ChromeConfig());
            objectContainer.RegisterInstanceAs(browser);
            browser.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(20);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            browser?.Quit(); browser = null;
        }
    }
}
