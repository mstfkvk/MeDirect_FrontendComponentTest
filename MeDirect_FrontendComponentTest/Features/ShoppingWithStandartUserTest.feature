Feature: ShoppingTest with standart-user or performance_glitch_user

Here will be tried all possible scenarios with correct user type --> standard_user 
									 and  with problem user type --> problem_user
After logged-in successfully we'll check functionality of buttons

Background: already logged-in
	When user logs in inventory page as "standard_user" and "secret_sauce"
    #When user logs in inventory page as "performance_glitch_user" and "secret_sauce"


@threeproduct
Scenario: standart-user adds randomly 3 products to the shopping chart then control with 2 verifications
	Given user chooses 3 products randomly
	When user clicks add to chart for added products
	Then user should see changing number of the cart
	And user goes to cart page
	Then user should see the product which added
	When user comes back inventory page
	And user removes randomly one product in inventory page
	And user goes to cart page
	And user removes randomly one product in cart
	And user clicks checkout button
	Then user should see "Checkout: Your Information" title
	And user gives credentials with "mustafa", "kavak" and 35600
	And user clicks continue button
	Then user should see "Checkout: Overview" title
	When user clicks finish button
	Then user should see "Checkout: Complete!" title
	And user should get thanks message for order
	And user clicks back home button
	And user logs out succesfully

#bug - shopping with 0 product
@zeroproduct
Scenario Outline: standart-user adds randomly one products to the shopping chart then control with 2 verifications
	Given user goes to cart page
	And user removes all items, if there is an item
	And user clicks checkout button
	#Then user should see "Checkout: Your Information" title
	And user gives credentials with <firstname>, <lastname> and <zipcode>
	And user clicks continue button
	#Then user should see "Checkout: Overview" title
	When user clicks finish button
	#Then user should see "Checkout: Complete!" title
	And user should get thanks message for order
	And user clicks back home button
	And user gives up to logs out
	Then user should see "Products" title
Examples:
	| firstname | lastname | zipcode |
	| mustafa   | kavak    | 35600   |


#bug - it accepts space also
@invalidinfo
Scenario Outline: after adding one product user enter invalid credentials
	Given user chooses 1 products randomly
	And user goes to cart page
	And user clicks checkout button
	And user gives credentials with <firstname>, <lastname> and <zipcode>
	And user clicks continue button
	Then user should not see "Checkout: Overview" title
Examples:
	| firstname | lastname | zipcode |
	| mustafa   | 11       | mk      |
	| 99        | 00       | mk      |
	| .         | .        | .       |
	| " "       | " "      | " "     |

@noinfo
Scenario Outline: after adding one product user enter with missing valid credentials
	Given user chooses 1 products randomly
	And user goes to cart page
	And user clicks checkout button
	And user gives credentials with <firstname>, <lastname> and <zipcode>
	And user clicks continue button
	Then user should get the <error_message>
Examples:
	| firstname | lastname | zipcode | error_message                  |
	|           | aaa      | 35600   | Error: First Name is required  |
	| aaa       |          | 35600   | Error: Last Name is required   |
	| aaa       | aaa      |         | Error: Postal Code is required |
	| aaa       |          |         | Error: Last Name is required   |
	|           | aaa      |         | Error: First Name is required  |
	|           |          | 35600   | Error: First Name is required  |
	|           |          |         | Error: First Name is required  |

@filter
Scenario Outline: user filters according to name or price

for name  -->  az , za 
for price --> lohi , holi

	Given user selects filter with <type> and <value>
	Then user should see filtering <type> and <value>

Examples:
	| type         | value |
	| number       | lohi  |
	| number       | hilo  |
	| alphabetical | az    |
	| alphabetical | za    |



@social
Scenario: user goes to social media
	Given user clicks <social> button
	Then user goes <social> website in a new tab
Examples:
	| social   |
	| linkedin |
	| facebook |
	| twitter  |