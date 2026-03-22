using NUnit.Framework;
using SauceDemoCheckoutAutomation.Drivers;
using SauceDemoCheckoutAutomation.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SauceDemoCheckoutAutomation.StepDefinitions
{
    [Binding]
    public class CartSteps(DriverContext driverContext, ProductsPage productsPage, CartPage cartPage, ScenarioContext scenarioContext,CheckoutPage checkoutPage)
    {
        private readonly ScenarioContext _scenarioContext = scenarioContext;
        private readonly DriverContext _driverContext = driverContext;
        private readonly ProductsPage _productsPage = productsPage;
        private readonly CartPage _cartPage = cartPage;
        private readonly CheckoutPage _checkoutPage = checkoutPage;


        [When(@"I add the following products to the cart")]
        public void AddProductsToTheCart(Table table)
        {
            List<string> products = new List<string>();
            foreach(var row in table.Rows)
            {
                products.Add(row["Product Name"].ToString());
            }
            
            _productsPage.AddProductToTheCart(products);
            _scenarioContext["AddedProducts"] = products;
        }


        

        [Then(@"the cart badge should show correct number of items")]
        public void ItemNumberAtTheCartBadgeShouldbeCorrect()
        {
            var addedProducts = (List<string>)_scenarioContext["AddedProducts"];
            int itemsNumberAtCartBadge = _productsPage.GetCurrentCartBadgeNumber();

            Assert.AreEqual(addedProducts.Count, itemsNumberAtCartBadge);

        }

        [When(@"I navigate to the cart")]
        public void NavigateTotheCart()
        {
            _productsPage.NavigateToTheCart();
            bool isNavigatedCart = _cartPage.IsNavigated();
            Assert.IsTrue(isNavigatedCart, "Navigation failed: User was not navigated to the Cart");

            List<string> actualItemNames = _cartPage.GetItemNamesInCart();
            _scenarioContext["ActualProducts"] = actualItemNames;
        }

        [Then(@"the cart should reflect selected items accurately")]
        public void ItemsAtCartShouldbeCorrect()
        {
            var addedProducts = (List<string>)_scenarioContext["AddedProducts"];
            var actualItemNames = (List<string>)_scenarioContext["ActualProducts"];

            Assert.AreEqual(addedProducts.Count, actualItemNames.Count);
            foreach (var addedProduct in addedProducts)
            {
                Assert.Contains(addedProduct, actualItemNames);
            }

        }


        [When(@"I proceed to checkout")]
        public void ProceedToCheckout()
        {
            _cartPage.clickCheckoutButton();
            bool isNavigatedCheckout = _checkoutPage.IsNavigated();
            Assert.IsTrue(isNavigatedCheckout, "Navigation failed: User was not navigated to the Checkout");

        }

        
        [Then(@"I should be navigate back to the product page")]
        public void VerifyProductPageNavigation()
        {
            _productsPage.IsNavigated();
        }

        [When(@"I remove ""(.*)"" from the cart")]
        public void RemoveAAddedProductFromTheList(string productName)
        {
            _productsPage.RemoveAddedProductFromTheCart(productName);
        }

        [Then(@"the Add to cart button for ""(.*)"" should be enabled")]
        public void VerifyAdtoCardtButtonOfAProduct(string productName)
        {
            Assert.IsTrue(_productsPage.VerifyAddToCartButtonOfAProduct(productName));
        }
    }
}
