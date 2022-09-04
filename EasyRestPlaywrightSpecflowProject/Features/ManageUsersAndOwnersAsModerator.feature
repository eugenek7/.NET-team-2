Feature: ManageUsersAndOwnersAsModerator
	As a moderator I want to check that possibility ban and unban users and owners is working correctly.

	Background:
	Given I go to Easy rest page

@(mu)PossibilityToManageUsersAsModerator
Scenario Outline: 1) Ban the first active user and check that user is banned.
	And I log in to my account with '<email>' and '<password>'
	And I go to Users tab
	And I go to Active tab
	When I ban first active user
	And I go to Banned tab
	Then I check that same user appears in banned tab

	Examples: 
	| email                      | password   | 
	| petermoderator@test.com    | 1          | 

@(mu)PossibilityToManageUsersAsModerator
Scenario Outline: 2) Unban the first banned user and check that the user is unbanned.
	And I log in to my account with '<email>' and '<password>'
	And I go to Users tab
	And I go to Banned tab
	When I unban first active user
	And I go to Active tab
	Then I check that same user appears in active tab

	Examples: 
	| email                      | password   | 
	| petermoderator@test.com    | 1          |

@(mo)PossibilityToManageOwnersAsModerator
Scenario Outline: 3) Ban the first active owner and check that owner is banned.
	And I log in to my account with '<email>' and '<password>'
	And I go to Owners tab
	And I go to Active tab
	When I ban first active owner
	And I go to Banned tab
	Then I check that same owner appears in banned tab

	Examples: 
	| email                      | password   | 
	| petermoderator@test.com    | 1          | 

@(mo)PossibilityToManageOwnersAsModerator
Scenario Outline: 4) Unban the first banned owner and check that the owner is unbanned.
	And I log in to my account with '<email>' and '<password>'
	And I go to Owners tab
	And I go to Banned tab
	When I unban first active owner
	And I go to Active tab
	Then I check that same owner appears in active tab

	Examples: 
	| email                      | password   | 
	| petermoderator@test.com    | 1          |
