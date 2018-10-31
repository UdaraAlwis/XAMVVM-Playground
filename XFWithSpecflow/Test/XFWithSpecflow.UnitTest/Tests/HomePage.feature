Feature: HomePageFeature

Scenario: Navigating to Home Page
	Given I have launched the app
	Then I am on the Home Page
	
Scenario: Navigating to New Text
	Given I have launched the app
	Then I am on the Home Page
	When I click on "New Text" Button
	Then I am on the New Text Page

Scenario: Creating to New Text Item
	Given I have launched the app
	Then I am on the Home Page
	When I click on "New Text" Button
	Then I am on the New Text Page
	And I add New TextTitle and TextText
	And I click on "Save" Button
	Then I am on the Home Page 
	And I can see 1 Text Item in ListView 