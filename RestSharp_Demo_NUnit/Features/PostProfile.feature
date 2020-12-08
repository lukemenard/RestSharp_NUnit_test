Feature: PostProfile
	Test POST operation using Rest-assured library
	
@smoke
Scenario: Verify Post operation for Profile
	Given I Perform Post operation for "/posts/{profileNo}/profile" with body
		| name | profile |
		| Sams | 2		 |
	Then I should see the "name" name as "Sams"
