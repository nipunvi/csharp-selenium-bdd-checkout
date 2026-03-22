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
        private readonly By _cartLink = By.XPath("//div[@class='header_label']/following-sibling::div//a");
        private readonly By _cartBadge = By.XPath("//div[@class='header_label']/following-sibling::div//a/span");
         
        public override bool IsNavigated()
        { 
            return waitForElement(_productsPageTitle).Enabled;
        }

        public void AddProductToTheCart(List<string> products)
        {
            for (var i = 0; i < products.Count; i++) { 
                var productName = products[i];
                var addToCartButtonAtCurrentProduct = $"//div[@data-test='inventory-item-name' and text()='{productName}']/ancestor::div[@data-test='inventory-item-description']//button[text()='Add to cart']";
                By product = By.XPath(addToCartButtonAtCurrentProduct);
                
                IWebElement element = FluentWaitForElement(product);
                Thread.Sleep(1000);
                element.Click();
                Thread.Sleep(1000);
                
            }
            
        }

        public void RemoveAddedProductFromTheCart(string productName)
        {
            By removeBtn = By.XPath($"//div[@data-test='inventory-item-name' and text()='{productName}']/ancestor::div[@data-test='inventory-item-description']//button[text()='Remove']");
            FluentWaitForElement(removeBtn).Click();
        }

        public bool VerifyAddToCartButtonOfAProduct(string productName)
        {
            By addToCardtButton = By.XPath($"//div[@data-test='inventory-item-name' and text()='{productName}']/ancestor::div[@data-test='inventory-item-description']//button[text()='Add to cart']");
            return FluentWaitForElement(addToCardtButton).Enabled;
        }

        public int GetCurrentCartBadgeNumber()
        {

            string itemsNumberAtCartBadge = FluentWaitForElement(_cartBadge).GetAttribute("textContent")??"0";
            return int.Parse(itemsNumberAtCartBadge);
        }

        public void NavigateToTheCart()
        {
            IWebElement element = FluentWaitForElement(_cartLink);
            element.Click();
        }

    }
}
