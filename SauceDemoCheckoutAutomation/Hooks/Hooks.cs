using SauceDemoCheckoutAutomation.Drivers;
using SauceDemoCheckoutAutomation.Utilities;
using SauceDemoCheckoutAutomation.Utilities.SauceDemoCheckoutAutomation.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace SauceDemoCheckoutAutomation.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly DriverContext _driverContext;
        private readonly Config _config;
        Hooks(DriverContext driverContext)
        {
            _driverContext = driverContext;
            _config = TestDataBuilder.LoadConfig();
        }
        [BeforeScenario]
        public void BeforeScenario() {
            

            _driverContext.InitDriver(Enum.Parse<BrowserType>(_config.Browser, true));
            _driverContext.Driver.Navigate().GoToUrl(_config.BaseUrl);

        }

        [AfterScenario]
        public void AfterScenario() { 
            _driverContext.QuitDriver();
        }
    }
    

}
