Feature: JsonAPIFeature
	I can Create, Read, Update and Delete 
	a post using valid test inputs.

@Automate
Scenario: Create Request
	Given I perform Request "Posts" with "POST"
	And I perform operatio with following value
	| userId | title | body |
	| 20     | aaaaa | aaaa |
	And Execute API
	And Deserialize the api content
	Then I can get status code 201
	Then I should the get title values "aaaaa"

@Automate
Scenario: Get Request
	Given I perform Request "Posts/1" with "GET"
	And Execute API
	And Deserialize the api content
	Then I can get status code 200
	Then I should the get values "1"

@Automate
Scenario: Update Request
	Given I perform Request "Posts/1" with "PUT"
	And I perform operatio with following value
	| userId | title | body |
	| 21     | bbbbb | bbbbb |
	And Execute API
	And Deserialize the api content
	Then I can get status code 200
	Then I should the get title values "bbbbb"
	
@Automate
Scenario: Delete Request
	Given I perform Request "Posts/1" with "DELETE"
	And Execute API
	Then I can get status code 200
	
	
	

