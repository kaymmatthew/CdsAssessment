using Microsoft.Extensions.Configuration;
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
    }
}
