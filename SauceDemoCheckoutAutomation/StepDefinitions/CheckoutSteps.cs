using NUnit.Framework;
using SauceDemoCheckoutAutomation.Drivers;
using SauceDemoCheckoutAutomation.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SauceDemoCheckoutAutomation.StepDefinitions
{
    [Binding]
    public class CheckoutSteps(DriverContext driverContext, CheckoutPage checkoutPage)
    {
        private readonly DriverContext _driverContext = driverContext;
        private readonly CheckoutPage _checkoutPage = checkoutPage;

        [When(@"I enter valid checkout details and continue")]
        public void EnterValidCheckoutDetails()
        {
            _checkoutPage.SetFirstName("Nipun");
            _checkoutPage.SetLasttName("Adhikari");
            _checkoutPage.SetPostalCode("1234");
            _checkoutPage.ClickContinueButton();
            bool overviewScreen = _checkoutPage.VerifyOverviewScreen();
            Assert.IsTrue(overviewScreen,"Failed Overview header did not updated");
            
        }

        [Then(@"the total price should be accurate")]
        public void ValidateTotalPrice()
        {
            double totalProice = 0.00;
            List<string> values = _checkoutPage.CalculateItemTotal();
            foreach (string value in values) 
            {
                totalProice += double.Parse(value);
            }
            double displayedTotal = _checkoutPage.GetDisplayedTotal();
            Console.WriteLine($"Actual total is {totalProice} and Displayed total is {displayedTotal}");
            Assert.AreEqual(totalProice, displayedTotal);


        }

        [When(@"I confirm the order")]
        public void ConfirmTheOrder()
        {
            _checkoutPage.ConfirmOrder();
        }

        [Then(@"the order should be placed successfully")]
        public void ValidateSuccessfullOrder()
        {
            bool completedHeader = _checkoutPage.VerifyOrderCompletionHeader();
            Assert.IsTrue(completedHeader, "Failed : order Complete header did not appear");

            bool thankYouMessage = _checkoutPage.VerifyOrderCompletionMessage();
            Assert.IsTrue(thankYouMessage, "Failed : order Complete Message did not appear");
        }

        


    }
}
