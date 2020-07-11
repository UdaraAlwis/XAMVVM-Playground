Feature: ViewTextPage

Scenario: Creating to New Text Item and Viewing it
	Given I have launched the app
	Then I am on the "Home" Page
	When I click on "GoToNewTextPage" Button
	Then I am on the "NewText" Page
	And I add New "<TextTitle>" and "<TextText>"
	And I click on "SaveText" Button
	Then I am on the "Home" Page
	And I can see 1 Text Items in ListView 
	Then I tap on first item in ListView
	Then I am on the "ViewText" Page
	And I can see "<TextTitle>" and "<TextText>"
	
Examples: 
	| TextTitle                               | TextText															 |
	| Juis yuwe sjkl Tywe oiq aklsjd asqw al. | Binf yuw tyasas pwerq asyu tui nuiwe aske yrwn kashdihas asju ywte.  |
