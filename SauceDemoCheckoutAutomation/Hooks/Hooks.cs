using SauceDemoCheckoutAutomation.Drivers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SauceDemoCheckoutAutomation.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly DriverContext _driverContext;
        Hooks(DriverContext driverContext)
        {
            _driverContext = driverContext;
        }
        [BeforeScenario]
        public void BeforeScenario() {
            _driverContext.InitDriver(Enum.Parse<BrowserType>("Chrome",true));
            _driverContext.Driver.Navigate().GoToUrl("https://www.saucedemo.com/");

        }

        [AfterScenario]
        public void AfterScenario() { 
            _driverContext.QuitDriver();
        }
    }
}
