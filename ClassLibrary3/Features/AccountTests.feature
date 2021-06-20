Feature: AccountTests
	In order to using 'Amazon' web-site safety
	As an 'Amazon' user
	I want to be able to authorize and to change my user account's data

Scenario Outline: Check user authorization
	Given User opens Amazon home page
	When User clicks 'Sign in' button
	And User enter "<login>" to 'Enter email or phone number' input field
	And User clicks on 'Continue authorization' button
	And User enter "<password>" to 'Enter password' input field
	And User clicks on 'Continue authorization' button
	Then User checks that user is authorized as "<user name>" "<password>"

	Examples:
		| login                       | password | user name  |
		| amazonTestAcc1234@gmail.com | qweasd   | Selindzher |
		| testAmazon1235@gmail.com    | qwea     | amazonTest |
		| testAmazon1235@gmail.com    |          | amazonTest |
		|                             | qweasd   | amazonTest |
		| testAmazon1235@gmail.com    | @#$@#$   | amTest     |

Scenario Outline: Check changing password
	Given User opens Amazon home page
	And User clicks 'Sign in' button
	When User logs in site as login: "amazonTestAcc1234@gmail.com" password: "<current password>"
	And User clicks 'Sign in' button
	And User clicks 'Login and security' button
	And User clicks on 'Edit password' button
	And User enter "<current password>" as 'Current password'
	And User enter "<new password>" to 'New password' input field
	And User enter "<new password>" to 'Reenter new password' input field
	And User clicks on 'Save changes' button
	Then User checks that information box about password changing is "<password change status>"

	Examples:
		| current password | new password | password change status |
		| qweasd           |              | false                  |
		| qweasd           | qweasd       | true                   |
		| qweasd           | qwert        | false                  |

Scenario Outline: Check account switching
	Given User opens Amazon home page
	And User clicks 'Sign in' button
	When User enter "amazonTestAcc1234@gmail.com" to 'Enter email or phone number' input field
	And User clicks on 'Continue authorization' button
	And User enter "qweasd" to 'Enter password' input field
	And User clicks on 'Continue authorization' button
	And User hovers on 'Sign In' button
	And User clicks 'Switch accounts' button
	And User clicks on 'Add account' button
	And User enter "<login>" to 'Enter email or phone number' input field
	And User clicks on 'Continue authorization' button
	And User waits for three seconds to make web-site sure that user is a real person
	And User enter "<password>" to 'Enter password' input field
	And User clicks on 'Continue authorization' button
	Then User checks that account is switched to "<account name>"

	Examples:
		| login                    | password | account name |
		| testAmazon1235@gmail.com | qweasd   | amazonTest   |