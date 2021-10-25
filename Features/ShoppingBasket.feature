Feature: ShoppingBasket
	As a user I want to be able to test the functionalities on the automation practice website.

@Regression
Scenario: Add item to basket and get count
   Given I navite to automationpractice.com
    When I hover mouse on the Item
     And I add an Item to basket 
    Then I have 1 Item in the basket 

@Regression
Scenario: Remove item from the basket
   Given I navite to automationpractice.com
    When I hover mouse on the Item
     And I add an Item to basket 
     And I remove Item from the basket 
    Then basket is empty 

@Regression
Scenario: Search result has one item count
   Given I navite to automationpractice.com
    When I search item with name 'blouse' 
    Then I search result has a key word 'BLOUSE'
     And search result has 1 item count

@Regression
Scenario: Item name matches the item added to the basket 
   Given I navite to automationpractice.com
    When I hover mouse on the Item
     And I add an Item to basket 
    Then I have 1 Item in the basket
     And I have 1 Item in checkout
     And the item name matches the item added to the basket 

@Regression
Scenario: Proceed to checkout and validation summary of the Item
   Given I navite to automationpractice.com
    When I hover mouse on the Item
     And I add an Item to basket 
    Then the summary of the product is as follows:
   | Total products | Total shipping | Total | Tax   | Total  |
   | $16.51         | $2.00          | $18.51| $0.00 | $18.51 |  