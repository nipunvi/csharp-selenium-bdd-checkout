using Io.Cucumber.Messages.Types;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SauceDemoCheckoutAutomation.Drivers;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SauceDemoCheckoutAutomation.Pages
{
    public abstract class BasePage
    {
        public readonly DriverContext _driverContext;

        public BasePage(DriverContext driverContext)
        {
            _driverContext = driverContext;
        }

        public abstract bool IsNavigated();


        public IWebElement waitForElement(By locator,int timeout = 30)
        {
            WebDriverWait wait = new WebDriverWait(_driverContext.Driver, TimeSpan.FromSeconds(timeout));
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }
        public IList<IWebElement> waitAndGetAllElements(By loactor)
        {
            WebDriverWait wait = new WebDriverWait(_driverContext.Driver, TimeSpan.FromSeconds(30));
            return wait.Until(driver =>
            {
                var elements = driver.FindElements(loactor);
                return elements.Count > 0 ? elements : null;

            });
        }


    }
}
