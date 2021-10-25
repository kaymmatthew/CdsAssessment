using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace CdsAssessment.Extensions
{
    public enum locatorType
    {
        Id,
        Name,
        XPath
    }
    public static class WebDriverExtensions
    {
        /// <summary>
        /// WebDriver extension to find element and click
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="type"></param>
        /// <param name="locator"></param>
        public static IWebElement FindThisElementandClick(this IWebDriver driver, locatorType type, string locator)
        {
            return WebElementExtensions.locatorToUse(driver, type, locator);
        }

        /// <summary>
        /// WebDriver extension to find element and enter text
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="type"></param>
        /// <param name="locator"></param>
        /// <param name="value"></param>
        public static IWebElement FindThisElementandEnterText(this IWebDriver driver, locatorType type, string locator)
        {
            return WebElementExtensions.locatorToUse(driver, type, locator);
        }
    }
}
