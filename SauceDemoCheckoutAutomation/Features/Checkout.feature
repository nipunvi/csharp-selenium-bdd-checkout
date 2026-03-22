Feature: Checkout Flow
  This feature tests the complete end to end checkout process 
  including adding products, entering user details, and confirming orders.

Scenario: Successful checkout with valid details
  Given I am logged in as a valid user
  When I add the following products to the cart
    | Product Name           |
    | Sauce Labs Backpack    |
  Then the cart badge should show correct number of items
  When I navigate to the cart
  Then the cart should reflect selected items accurately
  When I proceed to checkout
  And I enter valid checkout details and continue
  Then the total price should be accurate
  When I confirm the order
  Then the order should be placed successfully

Scenario: Successful Checkout with multiple selected products
  Given I am logged in as a valid user
  When I add the following products to the cart
    | Product Name           |
    | Sauce Labs Backpack    |
    | Sauce Labs Bike Light  |
  Then the cart badge should show correct number of items
  When I navigate to the cart
  Then the cart should reflect selected items accurately
  When I proceed to checkout
  And I enter valid checkout details and continue
  Then the total price should be accurate
  When I confirm the order
  Then the order should be placed successfully

Scenario: Cancel checkout before confirming order
  Given I am logged in as a valid user
  When I add the following products to the cart
    | Product Name           |
    | Sauce Labs Backpack    |
  Then the cart badge should show correct number of items
  When I navigate to the cart
  Then the cart should reflect selected items accurately
  When I proceed to checkout
  And I enter valid checkout details and continue
  And I Cancel the checkout at Overview
  Then I should be navigate back to the product page

Scenario: Checkout fails with missing required details
  Given I am logged in as a valid user
  When I add the following products to the cart
    | Product Name           |
    | Sauce Labs Backpack    |
  And I navigate to the cart
  And I proceed to checkout
  And I leave checkout details empty
  Then I should see an error message indicating required fields

Scenario: Remove product directly from product page
  Given I am logged in as a valid user
  When I add the following products to the cart
    | Product Name           |
    | Sauce Labs Backpack    |
    | Sauce Labs Bike Light  |
  Then the cart badge should show correct number of items
  When I remove "Sauce Labs Bike Light" from the cart
  Then the Add to cart button for "Sauce Labs Bike Light" should be enabled

Scenario: Login fails with invalid credentials
  Given I attempt to log in with invalid credentials
  Then I should see an error message preventing access

