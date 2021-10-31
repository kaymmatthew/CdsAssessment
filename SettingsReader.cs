using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CdsAssessment
{
    public class SettingsReader
    {
        private static IConfigurationRoot config { get; set; }

        private static IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Settings.json");

            config = builder.Build();

            return config;
        }

        public static Uri automationPracticeUrl = new Uri(
            GetConfiguration().GetSection("Url:AutomationPractice").Value);

        public static By HoverMouseOnImage => 
            By.XPath(GetConfiguration().GetSection("Locators:HoverMouseonImage").Value);
        public static By HoverMounseAddTocart => 
            By.XPath(GetConfiguration().GetSection("Locators:HoverMounseAddTocart").Value);
        public static By ViewShoppingcart =>
            By.XPath(GetConfiguration().GetSection("Locators:viewShoppingcart").Value);
        public static By RemoveLink =>
            By.XPath(GetConfiguration().GetSection("Locators:Removelink").Value);
        public static By CheckoutProductSummary =>
           By.XPath(GetConfiguration().GetSection("Locators:CheckoutProductSummary").Value);
        public static By SearchResult =>
            By.XPath(GetConfiguration().GetSection("Locators:SearchResult").Value);
        public static By SearchField =>
           By.Name(GetConfiguration().GetSection("Locators:SearchField").Value);
        public static By CartCount =>
           By.XPath(GetConfiguration().GetSection("Locators:CartCount").Value);
    }
}
