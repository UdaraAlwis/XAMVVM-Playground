Feature: NewTextPage

Scenario: Navigating to New Text Page Test
	Given I have launched the app
	Then I am in the "Home" Page
	When I click on "GoToNewTextPage" Button
	Then I am in the "NewText" Page

Scenario Outline: Creating new Text Item Test
	Given I have launched the app
	Then I am in the "Home" Page
	When I click on "GoToNewTextPage" Button
	Then I am in the "NewText" Page
	And I add New "<TextTitle>" and "<Text>"
	And I click on "SaveText" Button
	Then I am in the "Home" Page
	And I can see 1 Items in Text List

Examples: 
	| TextTitle                                 | Text																   |
	| Juis yuwe sjkl Tywe oiq aklsjd asqw al.   | Binf yuw tyasas pwerq asyu tui nuiwe aske yrwn kashdihas asju ywte.  |
	| Xlkasd j iwu eqowi ja skdiwe asld qp.		| Nj ahsdu aw ie uasdj ue asn dbnz xcq pwoe asdgoyxgy envow xad lw .   |
	| Oqu sw hbasnwiu jsad yer bjkasqix bai.	| Zbcvwo er ysof dt gskdfl shd bx vciwgery uw erppuyj s dfb jhb msja.  |
	
Scenario: Validating Input Data Test
	Given I have launched the app
	Then I am in the "Home" Page
	When I click on "GoToNewTextPage" Button
	Then I am in the "NewText" Page
	And I add New "<EmptyTextTitle>" and "<EmptyText>"
	Then I am in the "NewText" Page
	And I add New "<TextTitle>" and "<EmptyText>"
	Then I am in the "NewText" Page
	And I add New "<EmptyTextTitle>" and "<Text>"
	And I click on "SaveText" Button
	And I add New "<TextTitle>" and "<Text>"
	And I click on "SaveText" Button
	Then I am in the "Home" Page
	And I can see 1 Items in Text List

Examples: 
	| TextTitle                               | Text                                                                | EmptyTextTitle | EmptyText |
	| Juis yuwe sjkl Tywe oiq aklsjd asqw al. | Binf yuw tyasas pwerq asyu tui nuiwe aske yrwn kashdihas asju ywte. |                |           |