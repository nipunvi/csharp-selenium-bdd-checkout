using Io.Cucumber.Messages.Types;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Emulation;
using SauceDemoCheckoutAutomation.Drivers;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SauceDemoCheckoutAutomation.Pages
{
    public class CheckoutPage(DriverContext driverContext):BasePage(driverContext)
    {

        private readonly By _checkoutPageTitle = By.XPath("//span[@class='title' and starts-with(text(),'Checkout:')]");
        private readonly By _firstNameInput = By.Name("firstName");
        private readonly By _lastNameInput = By.Name("lastName");
        private readonly By _postalCodeInput = By.Name("postalCode");
        private readonly By _continueButton = By.Name("continue");
        private readonly By _cancelButton = By.Name("cancel");
        private readonly By _OverviewHeading = By.XPath("//span[@class='title' and contains(text(),'Overview')]");
        private readonly By _finishButton = By.Id("finish");
        private readonly By _thankYouMessage = By.XPath("//h2[text()='Thank you for your order!']");
        private readonly By _completedHeading = By.XPath("//span[@class='title' and contains(text(),'Complete!')]");
        private readonly By _itemPrices = By.ClassName("inventory_item_price");
        private readonly By _displayedTotal = By.ClassName("summary_subtotal_label");
        private readonly By _formValidationErrorText = By.XPath("//h3[@data-test='error']");
        private readonly By _cancelCheckoutAtOverview = By.Id("cancel");

        public override bool IsNavigated()
        {
            return waitForElement(_checkoutPageTitle).Enabled;
        }

        public void SetFirstName(string firstName) {
            IWebElement element = waitForElement(_firstNameInput);
            element.SendKeys(firstName);
        }

        public void SetLasttName(string lastName)
        {
            IWebElement element = waitForElement(_lastNameInput);
            element.SendKeys(lastName);
        }

        public void SetPostalCode(string postalcode)
        {
            IWebElement element = waitForElement(_postalCodeInput);
            element.SendKeys(postalcode);
        }

        public void ClickContinueButton()
        {
            IWebElement element = waitForElement(_continueButton);
            element.Click();    
        }

        public void ClickCancelButton() 
        {
            IWebElement element = waitForElement(_cancelButton);
            element.Click();
        }

        public bool VerifyOverviewScreen()
        {
            return FluentWaitForElement(_OverviewHeading).Enabled;
        }

        public void ConfirmOrder()
        {
            IWebElement element = FluentWaitForElement(_finishButton);
            element.Click();
        }

        public bool VerifyOrderCompletionHeader()
        {
            return waitForElement(_completedHeading).Enabled;
        }

        public bool VerifyOrderCompletionMessage()
        {
            return FluentWaitForElement(_thankYouMessage).Enabled;
        }

        public List<string> CalculateItemTotal()
        {
            IList<IWebElement> items = waitAndGetAllElements(_itemPrices);
            List<string> itemPricesList = new List<string>();
            if(items != null)
            {
                foreach(var item in items)
                {
                    itemPricesList.Add(item.GetAttribute("textContent")?.Substring(1)?? "0.00");
                }
            }
            return itemPricesList;
        }

        public double GetDisplayedTotal()
        {
            string total = FluentWaitForElement(_displayedTotal).GetAttribute("textContent")?.Split("$")[1]??"null";
            return total != null && total != "null"? double.Parse(total) : 0.00;
        }

       
        
        public string GetCurrentError()
        {
            string errotext = waitForElement(_formValidationErrorText)?.GetAttribute("textContent")??"No Error";
            return errotext;
        }

        public bool WaitForAnErrorText(string errorText)
        {
            bool iserror = waitForElement(_formValidationErrorText).Enabled;
            return iserror;
        }

        public void ClickCancelButtonAtOverview()
        {
            IWebElement element = waitForElement(_cancelCheckoutAtOverview);
            element.Click();
        }


    }
}
