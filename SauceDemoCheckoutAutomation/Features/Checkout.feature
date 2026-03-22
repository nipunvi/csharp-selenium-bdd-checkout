Feature: Checkout Flow
  This feature tests the complete end to end checkout process 
  including adding products, entering user details, and confirming orders.

Scenario: Successful checkout with valid details
  Given I am logged in as a valid user
  When I add a product to the cart
  And I proceed to checkout
  And I enter valid checkout details
  And I confirm the order
  Then the order should be placed successfully

Scenario: Successful Checkout with multiple products
  Given I am logged in as a valid user
  When I add multiple products to the cart
  And I proceed to checkout
  And I enter valid checkout details
  And I confirm the order
  Then all selected products should be in the order summary