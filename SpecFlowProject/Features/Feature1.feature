Feature:Feature1

#Background: 
#Given ResetSystem

@smoke
Scenario: SignInAndGoTyMyProfile
	#Given I Navigate to easyrest
	Given I click Sign in
	And I enter my email
	And I enter my password
	And I click Sign In Button
	When I navigate to my profile	
	Then I check my email in personal info
