using NUnit.Framework;
using SauceDemoCheckoutAutomation.Drivers;
using SauceDemoCheckoutAutomation.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SauceDemoCheckoutAutomation.StepDefinitions
{
    [Binding]
    public class LoginSteps(DriverContext driverContext, LoginPage loginPage, ProductsPage productsPage)
    {
        private readonly DriverContext _driverContext = driverContext;
        private readonly LoginPage _loginPage = loginPage;
        private readonly ProductsPage _productsPage = productsPage;

        [Given(@"I am logged in as a valid user")]
        public void LoginAsAValidUser()
        {
            if (!_loginPage.IsNavigated())
            {
                throw new Exception("Login page did not load");
            }
            _loginPage.SetUserName("standard_user");
            _loginPage.SetPassword("secret_sauce");
            _loginPage.ClickLogin();
            bool isNavigated = _productsPage.IsNavigated();
            Assert.IsTrue(isNavigated, "Login failed: User was not navigated to Products page.");
        }


    }
}
