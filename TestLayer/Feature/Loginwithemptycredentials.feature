Feature: Login with empty credentials


Scenario Outline: Try to login with empty credentials using different browsers
	Given User is on login page using '<browser>'
	And username 'John'
	And password 'AAAAAA'
	When the user enters their username and password
	And clears the fields
	And clicks the login button
	Then the user should see error message: "Username is required"


	Examples: 
	| browser |
	| Firefox |
	| Chrome  |