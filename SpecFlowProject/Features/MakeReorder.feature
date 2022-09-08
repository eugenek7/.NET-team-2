Feature:MakeReorder

Possibility to make reorder from history and customize it 

#Background: 


@tag1
Scenario: Make reorder with same values from history
   Given I sign in as a client with '<email>' and '<password>'
	And I navigate to my profile
	And I navigate to order history
	And I click reorder
	When I click submit reorder
	And I navigate to current orders
	Then I check that order with '<price>' appears in waiting to confirm

	Examples: 
	| email               | password | price |
	| stevenhall@test.com | 1111     | 488.70        |

	@tag2

	Scenario: Make reorder with increased values of dishes
	Given I sign in as a client with '<email>' and '<password>'
	And I navigate to my profile
	And I navigate to order history
	And I click reorder	
	When I increase dish quantity 
	And I click submit reorder
	And I navigate to current orders
	Then I check that order with '<price>' appears in waiting to confirm

	Examples: 
	| email               | password | price  |
	| stevenhall@test.com | 1111     | 521.50 |

	@tag3
	
	Scenario: Make reorder with deleting some dish from list
	Given I sign in as a client with '<email>' and '<password>'
	Given I navigate to my profile
	And I navigate to order history
	And I click reorder
	When I remove from the order list
	And I click submit reorder
	And I navigate to current orders
	Then I check that order with '<price>' appears in waiting to confirm

	Examples: 
	| email               | password | price  |
	| stevenhall@test.com | 1111     | 455.90 |

	@tag4

	Scenario: Make reorder with changing values to -1
	Given I sign in as a client with '<email>' and '<password>'
	Given I navigate to my profile
	And I navigate to order history
	And I click reorder
	When I changing values to '<negativevalue>'
	Then I check that '<quantitypopup>' appears in popup
	

	Examples: 
	| email               | password | negativevalue | quantitypopup          |
	| stevenhall@test.com | 1111     | -1            | Quantity changed to 11 |
