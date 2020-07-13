Feature: HomePage

Scenario: App Launching First Time Test
	Given I have launched the app
	Then I am in the "Home" Page
	And I can see 0 Items in Text List
	And I can see empty Text List indicating Label displayed

Scenario: Navigating to New Text Page Test
	Given I have launched the app
	Then I am in the "Home" Page
	When I click on "GoToNewTextPage" Button
	Then I am in the "NewText" Page

Scenario: Deleting Text Item Text
	Given I have launched the app
	Then I am in the "Home" Page
	When I click on "GoToNewTextPage" Button
	Then I am in the "NewText" Page
	And I add New "<TextTitle>" and "<TextText>"
	And I click on "SaveText" Button
	Then I am in the "Home" Page
	And I can see 1 Items in Text List 
	Then I Delete first item from Text List
	And I can see 0 Items in Text List 

Examples: 
	| TextTitle                               | TextText															 |
	| Juis yuwe sjkl Tywe oiq aklsjd asqw al. | Binf yuw tyasas pwerq asyu tui nuiwe aske yrwn kashdihas asju ywte.  |

Scenario: Data Persistence Test
	Given I have launched the app
	Then I am in the "Home" Page
	When I click on "GoToNewTextPage" Button
	Then I am in the "NewText" Page
	And I add New "<TextTitle>" and "<TextText>"
	And I click on "SaveText" Button
	Then I am in the "Home" Page
	And I can see 1 Items in Text List 
	Then I Close and Reopen the app
	Given I have launched the app
	Then I can see 1 Items in Text List 

Examples: 
	| TextTitle                               | TextText															 |
	| Juis yuwe sjkl Tywe oiq aklsjd asqw al. | Binf yuw tyasas pwerq asyu tui nuiwe aske yrwn kashdihas asju ywte.  |
