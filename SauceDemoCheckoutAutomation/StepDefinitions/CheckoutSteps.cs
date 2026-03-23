using NUnit.Framework;
using SauceDemoCheckoutAutomation.Drivers;
using SauceDemoCheckoutAutomation.Pages;
using SauceDemoCheckoutAutomation.Utilities;
using SauceDemoCheckoutAutomation.Utilities.SauceDemoCheckoutAutomation.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SauceDemoCheckoutAutomation.StepDefinitions
{
    [Binding]
    public class CheckoutSteps(DriverContext driverContext, CheckoutPage checkoutPage)
    {
        private readonly DriverContext _driverContext = driverContext;
        private readonly CheckoutPage _checkoutPage = checkoutPage;
        private readonly CheckoutData _checkoutData = TestDataBuilder.LoadCheckoutData();

        [When(@"I enter valid checkout details and continue")]
        public void EnterValidCheckoutDetails()
        {
            _checkoutPage.SetFirstName(_checkoutData.FirstName);
            _checkoutPage.SetLasttName(_checkoutData.LastName);
            _checkoutPage.SetPostalCode(_checkoutData.PostalCode);
            _checkoutPage.ClickContinueButton();
            bool overviewScreen = _checkoutPage.VerifyOverviewScreen();
            Assert.IsTrue(overviewScreen,"Failed Overview header did not updated");
            
        }



        [When(@"I leave checkout details empty")]
        public void LeaveCheckoutDetailsEmpty() 
        {
            _checkoutPage.ClickContinueButton();
        }

        
        [Then(@"I should see an error message indicating required fields")]
        public void CheckoutPageAllFormValidation()
        {

            string firstNameEmptyError = "Error: First Name is required";
            Assert.IsTrue(_checkoutPage.WaitForAnErrorText(firstNameEmptyError));

            _checkoutPage.SetFirstName(_checkoutData.FirstName);
            _checkoutPage.ClickContinueButton();


            string lastNameEmptyError = "Error: Last Name is required";
            Assert.IsTrue(_checkoutPage.WaitForAnErrorText(lastNameEmptyError));

            _checkoutPage.SetLasttName(_checkoutData.LastName);
            _checkoutPage.ClickContinueButton();


            string postalCodeEmptyError = "Error: Postal Code is required";
            Assert.IsTrue(_checkoutPage.WaitForAnErrorText(postalCodeEmptyError));


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

        

        [When(@"I Cancel the checkout at Overview")]
        public void CancelTheCheckoutAtOverview()
        {
            _checkoutPage.ClickCancelButtonAtOverview();
        }




        [When(@"I confirm the order")]
        public void ConfirmTheOrder()
        {
            _checkoutPage.ConfirmOrder();
        }

        [Then(@"the order should be placed successfully")]
        public void ValidateSuccessfullOrder()
        {
            bool thankYouMessage = _checkoutPage.VerifyOrderCompletionMessage();
            Assert.IsTrue(thankYouMessage, "Failed : order Complete Message did not appear");
        }

        


    }
}
