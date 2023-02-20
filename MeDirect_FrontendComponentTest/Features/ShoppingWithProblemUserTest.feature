Feature: ShoppingWithProblemUserTest

- Tried to written whole bugs with problem_user type
- All scenarios include BUGS

Background: already logged-in
	When user logs in inventory page as "problem_user" and "secret_sauce"


@picture
Scenario: all items picture are same and when user looks inventory-item it doesn't match with before clicked
	Given user looks one image of item first enterance
	And user clicks the image
	Then images should be different
	And user clicks go to products button
	And user clicks second item name
	Then user notices names are different


Scenario Outline: user tries to add some item and then remove
specific numbers: 1,2,5
	Given user can click only specific number to add to cart
	And user tries to remove one of specific number items
	Then user can't remove
	* user goes to cart page
	* user removes randomly one product in cart
	* user clicks to checkout button
	Then user should see "Checkout: Your Information" title
	When user writes its firstname
	Then user should see in the firstname textarea
	When user writes its lastname
	But user sees the only one letter of the lastname in the firstname textarea
	When user clicks continue button
	Then user should get the Error: Last Name is required
	


Scenario: Filter doesn't work anyway
	
for name  -->  az , za 
for price --> lohi , holi

	Given user selects filter with <type> and <value>
	Then user can't see any filtering <type> and <value>

Examples:
	| type         | value |
	| number       | lohi  |
	| number       | hilo  |
	| alphabetical | az    |
	| alphabetical | za    |


Scenario: User wants to go ABOUT page but not found
	When user clicks menu button
	And user clicks about button
	Then user gets "404" page not found message
