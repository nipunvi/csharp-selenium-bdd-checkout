using NUnit.Framework;
using SauceDemoCheckoutAutomation.Drivers;
using SauceDemoCheckoutAutomation.Pages;
using SauceDemoCheckoutAutomation.Utilities;
using SauceDemoCheckoutAutomation.Utilities.SauceDemoCheckoutAutomation.Models;
using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SauceDemoCheckoutAutomation.StepDefinitions
{
    [Binding]
    public class LoginSteps(DriverContext driverContext, LoginPage loginPage, ProductsPage productsPage)
    {
        private readonly DriverContext _driverContext = driverContext;
        private readonly LoginPage _loginPage = loginPage;
        private readonly ProductsPage _productsPage = productsPage;
        private readonly Config _config = TestDataBuilder.LoadConfig();

        [Given(@"I am logged in as a valid user")]
        public void LoginAsAValidUser()
        {
            if (!_loginPage.IsNavigated())
            {
                throw new Exception("Login page did not load");
            }
            _loginPage.SetUserName(_config.Username);
            _loginPage.SetPassword(_config.Password);
            _loginPage.ClickLogin();
            bool isNavigated = _productsPage.IsNavigated();
            Assert.IsTrue(isNavigated, "Login failed: User was not navigated to Products page.");
        }
        
        [Given(@"I attempt to log in with invalid credentials")]
        public void LoginAsLockedOutUser()
        {
            if (!_loginPage.IsNavigated())
            {
                throw new Exception("Login page did not load");
            }
            _loginPage.SetUserName(_config.lockedOutUser);
            _loginPage.SetPassword(_config.Password);
            _loginPage.ClickLogin();
            

        }


        [Then(@"I should see an error message preventing access")]
        public void ValidateLockedOutErrorMesssage() 
        {
            Assert.IsTrue(_loginPage.loginErrorValidation());
        }



    }
}
