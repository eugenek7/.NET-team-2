Feature: ActionsWithUsersAsAdmin

Scenario: 01 Ban user
    Given a user is signed in with '<email>' and '<password>'
	And navigate to active users tab
	When click the ban button on first user
	And navigate to banned users tab
	Then first user appears in banned users tab

Examples: 
	| email               | password |
	| steveadmin@test.com | 1        |

Scenario: 02 Activate user
	Given a user is signed in with '<email>' and '<password>'
	And navigate to banned users tab
	When click the activate button on first user
	And navigate to active users tab
	Then first user appears in active users tab

Examples: 
	| email               | password |
	| steveadmin@test.com | 1        |