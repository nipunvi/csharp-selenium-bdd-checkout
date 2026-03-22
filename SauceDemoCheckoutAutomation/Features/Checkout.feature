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