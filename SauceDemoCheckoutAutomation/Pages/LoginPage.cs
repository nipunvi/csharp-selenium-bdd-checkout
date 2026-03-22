using SauceDemoCheckoutAutomation.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SauceDemoCheckoutAutomation.Pages
{
    public class LoginPage(DriverContext driverContext) :BasePage(driverContext)
    {
        //Login page locators 
        private readonly By _usernameInput = By.Id("user-name");
        private readonly By _passwordInput = By.Id("password");
        private readonly By _loginButton = By.Id("login-button");

        

        public override bool IsNavigated()
        {
            return waitForElement(_loginButton).Enabled;
        }  
        public void SetUserName(string username)
        {
            waitedSendKeys(_usernameInput, username);
        }

        public void SetPassword(string password) {
            waitedSendKeys(_passwordInput, password);
        }

        public void ClickLogin() {
            waitedClick(_loginButton);
        }

        public bool loginErrorValidation()
        {
            By loginError = By.XPath($"//h3[@data-test='error' and text()='Epic sadface: Sorry, this user has been locked out.']");
            return waitForElement(loginError).Enabled;
        }
    }
}
