Feature: NewTextPage

Scenario: Navigating to New Text
	Given I have launched the app
	Then I am on the "Home" Page
	When I click on "NewText" Button
	Then I am on the "NewText" Page

Scenario: Creating to New Text Item
	Given I have launched the app
	Then I am on the "Home" Page
	When I click on "NewText" Button
	Then I am on the "NewText" Page
	And I add New TextTitle and TextText
	And I click on "SaveText" Button
	Then I am on the "Home" Page
	And I can see 1 Text Items in ListView 
	
@cleardata
Scenario: Deleting Text Item
	Given I have launched the app
	Then I am on the "Home" Page
	When I click on "NewText" Button
	Then I am on the "NewText" Page
	And I add New TextTitle and TextText
	And I click on "SaveText" Button
	Then I am on the "Home" Page
	And I can see 1 Text Items in ListView 
	Then I Delete first item from ListView