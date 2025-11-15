Feature: Login with correct credentials


Scenario Outline: Try to login with Username and password using different browsers
	Given User is on login page using '<browser>'
	And username 'problem_user'
	And password 'secret_sauce'
	When the user enters their username and password
	And clicks the login button with valid credentials
	Then the user should be redirected to new page and see the dashboard title: "Swag Labs"


	Examples: 
	| browser |
	| Firefox |
	| Chrome  |
