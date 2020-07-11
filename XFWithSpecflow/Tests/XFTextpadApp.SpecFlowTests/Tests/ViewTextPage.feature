Feature: ViewTextPage

Scenario: Navigating to View Text Page Test
	Given I have launched the app
	Then I am in the "Home" Page
	When I click on "GoToNewTextPage" Button
	Then I am in the "NewText" Page
	And I add New "<TextTitle>" and "<TextText>"
	And I click on "SaveText" Button
	Then I am in the "Home" Page
	And I can see 1 Items in Text List 
	Then I tap on first item in ListView
	Then I am in the "ViewText" Page
	And I can see Text Title "<TextTitle>" and Text "<TextText>"
	
Examples: 
	| TextTitle                               | TextText															 |
	| Juis yuwe sjkl Tywe oiq aklsjd asqw al. | Binf yuw tyasas pwerq asyu tui nuiwe aske yrwn kashdihas asju ywte.  |

Scenario: View Text Details and go back Test
	Given I have launched the app
	Then I am in the "Home" Page
	When I click on "GoToNewTextPage" Button
	Then I am in the "NewText" Page
	And I add New "<TextTitle>" and "<TextText>"
	And I click on "SaveText" Button
	Then I am in the "Home" Page
	And I can see 1 Items in Text List
	Then I tap on first item in ListView
	Then I am in the "ViewText" Page
	And I can see Text Title "<TextTitle>" and Text "<TextText>"
	When I click on "Done" Button
	And I am navigating Backwards
	Then I am in the "Home" Page
	And I can see 1 Items in Text List
	
Examples: 
	| TextTitle                               | TextText															 |
	| Juis yuwe sjkl Tywe oiq aklsjd asqw al. | Binf yuw tyasas pwerq asyu tui nuiwe aske yrwn kashdihas asju ywte.  |
