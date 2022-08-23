Feature: EasyRest
#![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
#Simple calculator for adding **two** numbers
#
#Link to a feature: [Calculator](EasyRestSpecFlow/Features/Calculator.feature)
#***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
Scenario: SignIn
	Given I click Sign in
	And I enter my '<email>'
	And I enter my password '<password>'
	And I click Sign In Button

Examples: 
	| email                  | password   |
	| stevenhall@test.com    | 1111       |