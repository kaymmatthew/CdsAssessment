using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace CdsAssessment.CustomMethods
{
    public class CustomHelpers
    {
        IWebDriver browser;
        public CustomHelpers(IObjectContainer objectContainer)
        {
            this.browser = objectContainer.Resolve<IWebDriver>(); ;
        }

        string path(string Screenshotname) =>
            @$"C:\Users\joeea\source\repos\TestProjectNunit\ScreenShot\{Screenshotname}";

        public void TakeElementScreenShot(IWebElement element, string ScreenShotName)
        {
            (element as ITakesScreenshot).GetScreenshot()
                .SaveAsFile(path($"{ScreenShotName}." + ScreenshotImageFormat.Png));
        }

        public void MoveToelementViaJS(IWebElement element, IWebDriver browser)
        {
            ((IJavaScriptExecutor)browser)
                .ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }

        public void HighLightElementViaJS(IWebElement element, IWebDriver browser)
        {
            ((IJavaScriptExecutor)browser)
                .ExecuteScript("arguments[0].style.border = '3px dotted blue'", element);
        }

        public void MoveToelementViaJSAndClick(IWebElement element)
        {
            ((IJavaScriptExecutor)browser)
                .ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.Click();
        }

        public void MoveToelementViaJSAndEnterText(
            IWebElement element, IWebDriver browser, string valueEnterText)
        {

            ((IJavaScriptExecutor)browser)
                .ExecuteScript("arguments[0].scrollIntoView(true);", element);
            element.SendKeys(valueEnterText);
        }

        public void TakePageScreenShot(IWebDriver browser, String ScrenShotName)
        {
            ((ITakesScreenshot)browser).GetScreenshot()
            .SaveAsFile(path(ScrenShotName) + "." + ScreenshotImageFormat.Png);
        }

        public void WaitFor(IWebDriver browser, By by)
        {
            var wait = new WebDriverWait(browser, TimeSpan.FromSeconds(30));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));
            wait.Until(x => x.FindElement(by));
        }
    }
}
