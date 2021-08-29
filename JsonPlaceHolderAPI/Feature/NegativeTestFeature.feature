Feature: NegativeTestFeature
	Negative test
	Validate if this request - GET

@Automate
Scenario: Get Request
	Given I perform Request "Posts/idontexist" with "GET"
	And Execute API
	Then I can get status code 200
	