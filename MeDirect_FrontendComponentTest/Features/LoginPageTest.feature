Feature: LoginPageTest

- Tried to log-in with all user types by using given credentials
- 


### Positive Test Scenarios

@SU
Scenario Outline: Standart-user should be logged in with own valid credentials
	Given User goes login page
	And user enter credentials with <username> and <password>
	When user clicks login button
	Then user is on the "inventory" page
	And user should see "Products" title

Examples:
	| username      | password     |
	| standard_user | secret_sauce |


	 
@LOU
Scenario Outline: locked_out_user should not be logged in with own valid credentials
	Given User goes login page
	And user enter credentials with <username> and <password>
	When user clicks login button
	Then user should gets the <error_message>

Examples:
	| username        | password     | error_message                                       |
	| locked_out_user | secret_sauce | Epic sadface: Sorry, this user has been locked out. |


@PU
Scenario Outline: problem_user should be logged in with own valid credentials
	Given User goes login page
	And user enter credentials with <username> and <password>
	When user clicks login button
	Then user is on the "inventory" page
	And user should see "Products" title

Examples:
	| username     | password     |
	| problem_user | secret_sauce |



# here, time is more than previous logins user types due to performance
@PGU
Scenario Outline: performance_glitch_user should be logged in with own valid credentials
	Given User goes login page
	And user enter credentials with <username> and <password>
	When user clicks login button
	Then user is on the "inventory" page
	And user should see "Products" title

Examples:
	| username                | password     |
	| performance_glitch_user | secret_sauce |



### Negative Test Scenarios
@NEGATIVE
Scenario Outline: trying to login with invalid credentials
	Given User goes login page
	And user enter credentials with <username> and <password>
	When user clicks login button
	Then user should gets the <error_message>
	Examples:
	| username                | password     | error_message                                                             |
	| problem_user            | 12345        | Epic sadface: Username and password do not match any user in this service |
	|                         | secret_sauce | Epic sadface: Username is required                                        |
	| meDirect                | secret_sauce | Epic sadface: Username and password do not match any user in this service |
	| performance_glitch_user |              | Epic sadface: Password is required                                        |
	|                         |              | Epic sadface: Username is required                                        |