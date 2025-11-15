Feature: Login with only Username


Scenario Outline: Try to login with Username using different browsers
	Given User is on login page using '<browser>'
	And username 'John'
	And password 'AAAAAA'
	When the user enters their username and password
	And clears the password field
	And clicks the login button
	Then the user should see error message: "Password is required"


	Examples: 
	| browser |
	| Firefox |
	| Chrome  |
