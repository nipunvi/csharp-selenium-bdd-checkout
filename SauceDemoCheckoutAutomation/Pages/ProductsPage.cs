using Io.Cucumber.Messages.Types;
using OpenQA.Selenium;
using SauceDemoCheckoutAutomation.Drivers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SauceDemoCheckoutAutomation.Pages
{
    public class ProductsPage(DriverContext driverContext):BasePage(driverContext)
    {
        private readonly By _productsPageTitle = By.XPath("//span[@class='title' and text()='Products']");
        private readonly By _cartLink = By.ClassName("shopping_cart_link");
        private readonly By _cartBadge = By.ClassName("shopping_cart_badge");
         
        public override bool IsNavigated()
        {
            return waitForElement(_productsPageTitle).Enabled;
        }

        public void AddProductToTheCart(List<string> products)
        {
            for (var i = 0; i < products.Count; i++) { 
                var productName = products[i];
                var addToCartButtonAtCurrentProduct = $"//div[@data-test='inventory-item-name' and text()='{productName}']/ancestor::div[@data-test='inventory-item-description']//button";
                By product = By.XPath(addToCartButtonAtCurrentProduct);
                IWebElement productWebelement = _driverContext.Driver.FindElement(product);
                ((IJavaScriptExecutor)_driverContext.Driver).ExecuteScript("arguments[0].scrollIntoView(true);", productWebelement);
                waitedClick(product);
                
            }
            
        }

        public void RemoveAddedProductFromTheCart(string productName)
        {
            By removeBtn = By.XPath($"//div[@data-test='inventory-item-name' and text()='{productName}']/ancestor::div[@data-test='inventory-item-description']//button[text()='Remove']");
            waitForElement(removeBtn).Click();
        }

        public bool VerifyAddToCartButtonOfAProduct(string productName)
        {
            By addToCardtButton = By.XPath($"//div[@data-test='inventory-item-name' and text()='{productName}']/ancestor::div[@data-test='inventory-item-description']//button[text()='Add to cart']");
            return waitForElement(addToCardtButton).Enabled;
        }

        public int GetCurrentCartBadgeNumber()
        {
            string itemsNumberAtCartBadge = waitForElement(_cartBadge).GetAttribute("textContent")??"0";
            return int.Parse(itemsNumberAtCartBadge);
        }

        public void NavigateToTheCart()
        {
            waitedClick(_cartLink);
        }

    }
}
