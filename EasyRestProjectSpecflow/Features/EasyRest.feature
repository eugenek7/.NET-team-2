Feature: EasyRest

@mytag
Scenario: SignIn
	Given a user is signed in with '<email>' and '<password>'

Examples: 
	| email                  | password   |
	| stevenhall@test.com    | 1111       |