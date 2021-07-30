namespace SpecFlowSimpleProject.Drivers
{
    using System;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    using WebDriverManager.DriverConfigs.Impl;

    public class BrowserDriver : IDisposable
    {
        private readonly Lazy<IWebDriver> _currentWebDriverLazy;

        private bool _isDisposed;

        public BrowserDriver()
        {
            this._currentWebDriverLazy = new Lazy<IWebDriver>(this.CreateWebDriver);
        }

        public IWebDriver Current => this._currentWebDriverLazy.Value;

        public void Dispose()
        {
            if (this._isDisposed) return;
            if (this._currentWebDriverLazy.IsValueCreated) this.Current.Quit();

            this._isDisposed = true;
        }

        private IWebDriver CreateWebDriver()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            var chromeDriver = new ChromeDriver(chromeDriverService, WebDriverSettings.ChromeOptions());
            chromeDriver.Manage().Window.Maximize();

            return chromeDriver;
        }
    }
}