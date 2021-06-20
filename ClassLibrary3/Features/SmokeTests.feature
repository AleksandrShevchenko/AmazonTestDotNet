Feature: SmokeTests
	In order to purchase products
	As an 'Amazon' user
	I want to be able to filter, choose and purchase products from web-market


Scenario Outline: Check product cart
	Given User opens Amazon home page
	When User searches "QNAP TS-451D2-4G" using search field
	And User clicks on first product
	And User clicks on 'Add to cart' button
	And User clicks on 'Cart' button
	Then User checks amount of products into the cart
	When User clicks on 'Quantity' button
	And User clicks on 'More then ten' dropdown list item
	And User enters "<amount of products>" to 'Quantity input field'
	And User clicks 'Update' button
	Then User checks that total price is changed accordingly to <amount of products> or existence of error
	When User clicks on 'Delete' button
	Then User checks that cart is empty

	Examples:
		| amount of products |
		| 999                |
		| 0                  |
		| 10                 |
		| -5                 |

Scenario: Check product purchasing
	Given User opens Amazon home page
	When User clicks 'Sign in' button
	And User logs in site as login: "amazonTestAcc1234@gmail.com" password: "qweasd"
	And User searches "Samsung Galaxy A51 Factory Unlocked Cell Phone" using search field
	And User clicks on first product
	And User clicks on 'Buy now' button
	And User clicks on 'Country & Region' drop-down list button
	And User clicks on 'Ukraine' item into drop-down list
	And User enters his "Ivan", "Boost red street", "Dnipro", "09898" and "380690000000"
	And User clicks 'Use this address' button
	And User clicks on 'Continue' button
	And User checks that 'Add credit cart' button is visible
	And User checks that 'Enter a gift card, voucher or promotional code' link is visible
	And User checks that 'Learn more' link in the 'Amazon store card' block is visible
	Then User checks that 'Add a personal checking account' button is visible

Scenario: Check product filter
	Given User opens Amazon home page
	And User clicks 'Catalogue' button
	And User clicks 'Computer' menu item
	And User clicks 'Data storage' menu item
	When User clicks 'External Hard Drives' button
	And User clicks '4 stars & up' button
	And User clicks 'Toshiba' button
	And User clicks 'Price from fifty to one hunded' button
	And User clicks 'Portable' button
	And User clicks 'PC' button for 'Platform support'
	And User clicks '4TB & Above' for 'Hard Drive Size' filter
	And User clicks 'Tablet' button as 'Compatible Devices'
	And User clicks on first 'Toshiba' product
	And User checks that product is external hard drive
	And User checks that product has rate '4 stars' or higher
	And User checks that product is manufactured by 'Toshiba'
	And User checks that product's price is between fifty and one hundred dollars
	And User checks that product is portable
	And User checks that product supports "PC" platform
	And User checks that product's capacity is 4TB or above
	Then User checks that product comparable with "Tablet"

Scenario Outline: Check products sorting
	Given User opens Amazon home page
	When User searches "Nesquik" using search field
	And User clicks 'Sorting type' drop-down list button
	And User chooses "<sorting type>" and click this sorting type dropdown list item
	Then User checks that products are sorted by "<sorting type>"

	Examples:
		| sorting type |
		| asc          |
		| desc         |