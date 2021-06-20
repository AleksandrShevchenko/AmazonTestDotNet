Feature: AmazonPrimeTests
	In order to have feedback from 'Amazon' web-site
	As an 'Amazon Prime Video' user
	I want to be  shown a message if 'Amazon Prime' video is restricted for my country

Scenario: Check Amazon Prime videos restriction to Ukraine
	Given User opens Amazon home page
	And User clicks 'Sign in' button
	When User logs in site as login: "amazonTestAcc1234@gmail.com" password: "qweasd"
	And User hovers on 'Sign In' button
	And User clicks 'Watchlist' button
	And User searches 'The boys' using search field
	And User clicks 'The boys' series block
	And User clicks 'Watch Trailer' button
	Then User checks 'Service Area Restriction' popup visibility