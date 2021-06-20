Feature: UserListsTests
	In order to save my time
	As an 'Amazon' user
	I want to be able to create lists to save my addresses and wishes

Scenario Outline: Check adding address to list
	Given User opens Amazon home page
	And User clicks 'Sign in' button
	When User logs in site as login: "amazonTestAcc1234@gmail.com" password: "qweasd"
	And User clicks on 'Deliver to' button
	And User clicks on 'Manage address book' button
	And User clicks on 'Add address' panel
	And User clicks on 'Country & Region' drop-down list button
	And User clicks on 'Ukraine' item into drop-down list
	And User enters his "<Name>", "<Street>", "<City>", "<ZipCode>" and "<Phone number>"
	And User clicks 'Add address' button
	And User checks that address is added to addressBook with "<Name>", "<Street>", "<City>", "<ZipCode>" and "<Phone number>"
	And User checks that name "<Name>" was added to addressBook correctly
	And User checks that street "<Street>" was added to addressBook correctly
	And User checks that city "<City>" was added to addressBook correctly
	And User checks that zipCode "<ZipCode>" was added to addressBook correctly
	And User checks that phone number "<Phone number>" was added to addressBook correctly
	Then User checks that country "Ukraine" was added to addressBook correctly

	Examples:
		| Name | Street             | City         | ZipCode | Phone number |
		| Ivan | Ross Gellar street | New Zhytomir | 09898   | 380690000000 |
		| Ivan | Ross Gellar street | New Zhytomir | 09898   | #$##$#$#$#$# |
		| Ivan | Ross Gellar street | New Zhytomir | 09898   | qweqweqweqww |
		| Ivan | Ross Gellar street | New Zhytomir | 09898   |              |
		| Ivan | Ross Gellar street | New Zhytomir |         | 380690000000 |
		| Ivan | Ross Gellar street |              | 09898   | 380690000000 |
		| Ivan |                    | New Zhytomir | 09898   | 380690000000 |
		|      | Ross Gellar street | New Zhytomir | 09898   | 380690000000 |

Scenario Outline: Check product adding to wish list
	Given User opens Amazon home page
	When User clicks 'Sign in' button
	And User logs in site as login: "amazonTestAcc1234@gmail.com" password: "qweasd"
	And User searches "<product name>" using search field
	And User clicks on first product
	When User clicks on 'Add to list' button
	And User enters list name - "<list name>"
	And User clicks on 'Create list' button
	And User clicks on 'View List' button
	Then User checks that "<product name>" is added to wish list

	Examples:
		| product name | list name |
		| Xerox        | #$@$      |
		| Apple        | 123123132 |