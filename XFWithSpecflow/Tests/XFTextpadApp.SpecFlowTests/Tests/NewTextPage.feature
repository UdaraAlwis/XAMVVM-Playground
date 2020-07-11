Feature: NewTextPage

Scenario: Navigating to New Text
	Given I have launched the app
	Then I am on the "Home" Page
	When I click on "GoToNewTextPage" Button
	Then I am on the "NewText" Page

Scenario Outline: Creating to New Text Item
	Given I have launched the app
	Then I am on the "Home" Page
	When I click on "GoToNewTextPage" Button
	Then I am on the "NewText" Page
	And I add New "<TextTitle>" and "<TextText>"
	And I click on "SaveText" Button
	Then I am on the "Home" Page
	And I can see 1 Text Items in ListView 

Examples: 
	| TextTitle                               | TextText															 |
	| Juis yuwe sjkl Tywe oiq aklsjd asqw al. | Binf yuw tyasas pwerq asyu tui nuiwe aske yrwn kashdihas asju ywte.  |
	
Scenario: Deleting Text Item
	Given I have launched the app
	Then I am on the "Home" Page
	When I click on "GoToNewTextPage" Button
	Then I am on the "NewText" Page
	And I add New "<TextTitle>" and "<TextText>"
	And I click on "SaveText" Button
	Then I am on the "Home" Page
	And I can see 1 Text Items in ListView 
	Then I Delete first item from ListView

Examples: 
	| TextTitle                               | TextText															 |
	| Juis yuwe sjkl Tywe oiq aklsjd asqw al. | Binf yuw tyasas pwerq asyu tui nuiwe aske yrwn kashdihas asju ywte.  |