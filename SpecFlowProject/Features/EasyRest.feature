Feature: EasyRest


Scenario: SignIn
	Given a user is signed in with '<email>' and '<password>'

Examples: 
	| email                  | password   |
	| stevenhall@test.com    | 1111       | 

	Scenario: Sign in as a client 
	Given I sign in as a client with '<email>' and '<password>'

Examples: 
	| email                  | password   |
	| stevenhall@test.com    | 1111       | 
	
	