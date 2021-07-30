using System;
using System.Collections.Generic;
using System.Text;

namespace SpecFlowSimpleProject.Drivers
{
    using System.Reflection;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Edge;
    using OpenQA.Selenium.Firefox;
    using OpenQA.Selenium.IE;

    public class WebDriverSettings
    {

        public static ChromeOptions ChromeOptions()
        {
            var options = new ChromeOptions();
            options.AddAdditionalCapability("useAutomationExtension", false);
            options.AddExcludedArgument("enable-automation");
            options.AddArgument("--disable-save-password-bubble");
            options.AddArgument("ignore-certificate-errors");
            options.AddArgument("start-maximized");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--window-size=1920,1080");

            // Handle unsecured certificate
            options.AddArguments("--disable-web-security");
            options.AddArguments("--allow-running-insecure-content");
            options.AddArguments("--ignore-certificate-errors");


            return options;
        }
    }
}
