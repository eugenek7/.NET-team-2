Feature:Feature1



Scenario: Add two numbers
	Given I Navigate to easyrest
	And I click sign in
	And I enter my email
	And I enter my password
	And I click Sign In
	When I navigate to my profile	
	Then I check my email in personal info
