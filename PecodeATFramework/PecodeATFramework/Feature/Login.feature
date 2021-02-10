Feature: Login
	Login to Pecode Software application

@smoke
Scenario: Perform Unsuccessful Login of Pecode Software site
	Given I launch to application
	And I enter the following details
		| UserName | Password |
		| user     | password |
	And I click login button
	Then I should get error message