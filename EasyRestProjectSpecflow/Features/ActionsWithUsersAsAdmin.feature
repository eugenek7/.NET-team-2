Feature: ActionsWithUsersAsAdmin

Background:
	Given a user is signed in with '<email>' and '<password>'

Scenario: Ban user
	And navigate to active users tab
	When click the ban button on first user
	And navigate to banned users tab
	Then first user appears in banned users tab

Scenario: Activate user
	And navigate to banned users tab
	When click the activate button on first user
	And navigate to active users tab
	Then first user appears in active users tab

Examples: 
	| email               | password |
	| steveadmin@test.com | 1        |