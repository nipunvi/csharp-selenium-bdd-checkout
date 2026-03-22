using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Text;

namespace SauceDemoCheckoutAutomation.Drivers
{
    public enum BrowserType
    {
        Chrome,
        Edge,
    }
    public class DriverContext
    {
        public IWebDriver Driver { get; private set; }

        public void InitDriver(BrowserType browser = BrowserType.Chrome)
        {
            if (Driver != null)
                return;


            switch (browser)
            {

                case BrowserType.Chrome:
                    var options = new ChromeOptions();
                    options.AddArgument("--headless");
                    options.AddArguments("--disable-gpu", "--no-sandbox");
                    options.AddArgument("--disable-dev-shm-usage");
                    Driver = new ChromeDriver(options);
                    break;

                case BrowserType.Edge:
                    Driver = new EdgeDriver();
                    break;

                default:
                    throw new ArgumentException($"Browser {browser} not supported");
            }

            Driver.Manage().Window.Maximize();

        }

        public void QuitDriver()
        {
            if( Driver != null)
            {
                Driver.Quit();
            }
        }
    }
}
