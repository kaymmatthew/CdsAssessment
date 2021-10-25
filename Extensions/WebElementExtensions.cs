using OpenQA.Selenium;
using System;
using CdsAssessment.Extensions;
using System.Collections.Generic;
using System.Text;

namespace CdsAssessment.Extensions
{
    public static class WebElementExtensions
    {
        public static IWebElement locatorToUse(IWebDriver driver, locatorType type, string locator) => type switch
        {
            locatorType.Id => driver.FindElement(By.Id(locator)),
            locatorType.Name => driver.FindElement(By.Name(locator)),
            locatorType.XPath => driver.FindElement(By.XPath(locator)),
            _ => throw new NotImplementedException("No such locator")
        };
    }
}
