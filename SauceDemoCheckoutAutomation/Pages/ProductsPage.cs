using SauceDemoCheckoutAutomation.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SauceDemoCheckoutAutomation.Pages
{
    public class ProductsPage(DriverContext driverContext):BasePage(driverContext)
    {
        private readonly By _productsPageTitle = By.XPath("//span[@class='title' and text()='Products']");

        public override bool IsNavigated()
        {
            return waitForElement(_productsPageTitle).Enabled;
        }
    }
}
