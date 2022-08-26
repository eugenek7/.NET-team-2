Feature:MakeReorder

Possibility to make reorder from history and customize it 

#Background: 


@tag1
Scenario: Make reorder with same values from history
    Given a user is signed in with '<email>' and '<password>'
	And I navigate to my profile
	And I navigate to order history
	And I click reorder
	When I click submit reorder
	And I navigate to current orders
	Then I check that order appears in waiting to confirm
	Examples: 
	| email                  | password   |
	| stevenhall@test.com    | 1111       | 

	@tag2

	Scenario: Make reorder with increased values of dishes
	Given a user is signed in with '<email>' and '<password>'
	And I navigate to my profile
	And I navigate to order history
	And I click reorder	
	When I increase dish quantity 
	And I click submit reorder
	And I navigate to current orders
	Then I check that order appears in waiting to confirm
	Examples: 
	| email               | password | order id |
	| stevenhall@test.com | 1111     | №151     |

	@tag3
	
	Scenario: Make reorder with deleting some dish from list
	Given a user is signed in with '<email>' and '<password>'
	Given I navigate to my profile
	And I navigate to order history
	And I click reorder
	When I remove from the order list
	And I click submit reorder
	And I navigate to current orders
	Then I check that order appears in waiting to confirm
	Examples: 
	| email                  | password   |
	| stevenhall@test.com    | 1111       | 

	@tag4

	Scenario: Make reorder with changing values to -1
	Given a user is signed in with '<email>' and '<password>'
	Given I navigate to my profile
	And I navigate to order history
	And I click reorder
	When I changing values to '<negativevalue>'
	Then I check that quantity of dish remained in the amount of one
	

	Examples: 
	| email               | password | negativevalue |
	| stevenhall@test.com | 1111     | -1            |
