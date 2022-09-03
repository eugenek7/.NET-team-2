Feature: ManageUsersAndOwnersAsModerator
	As a moderator I want to check that possibility ban and unban users and owners is working correctly.

@smoke
Scenario Outline: Ban of first active user and check that user is banned.
	Given I go to Easy rest page
	And I log in to my account with '<email>' and '<password>'
	And I go to Users tab
	And I go to Active tab
	When I ban first active user
	And I go to Banned tab
	Then I check that same user appears in banned tab

	Examples: 
	| email                      | password   | 
	| petermoderator@test.com    | 1          | 
