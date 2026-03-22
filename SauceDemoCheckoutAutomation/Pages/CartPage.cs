using SauceDemoCheckoutAutomation.Drivers;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace SauceDemoCheckoutAutomation.Pages
{
    public class CartPage(DriverContext driverContext):BasePage(driverContext)
    {
        private readonly By _itemsAddedToCart = By.XPath("//div[@class='cart_item']//div[@class='cart_item_label']/a/div");
        private readonly By _checkoutButton = By.Id("checkout");
        public override bool IsNavigated()
        {
            return waitForElement(_checkoutButton).Enabled;
        }

        public List<string> GetItemNamesInCart()
        {
            List<string> itemTexts =new List<string>();
            IList<IWebElement> items = waitAndGetAllElements(_itemsAddedToCart);

            if (items != null) {
                foreach (var item in items)
                {
                    itemTexts.Add(item.GetAttribute("textContent")!);
                }
            }
            return itemTexts;
        }

        public void clickCheckoutButton()
        {
            IWebElement element = waitForElement(_checkoutButton);
            element.Click();

        }
    }
}
