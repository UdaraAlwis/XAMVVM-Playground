using System;
using System.IO;
using System.Linq;
using Bogus;
using Bogus.DataSets;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace XFWithUITest.UITest.Tests
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class AppTests
    { 
        public AppTests(Platform platform)
        {
            SetupHooks.Platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            SetupHooks.App = AppInitializer.StartApp(SetupHooks.Platform, true);
        }

        [Test]
        public void WelcomeTextIsDisplayedTest()
        {
            AppResult[] homePageExists = SetupHooks.App.WaitForElement(c => c.Marked("HomePage"));
            Assert.IsTrue(homePageExists.Any());

            AppResult[] welcomeLabelExists = SetupHooks.App.WaitForElement(c => c.Text("Hey there, Welcome!"));
            SetupHooks.App.Screenshot("Welcome screen.");

            Assert.IsTrue(welcomeLabelExists.Any());
        }

        [Test]
        public void EmptyListDisplayedTest()
        {
            AppResult[] emptyListLabelExists = SetupHooks.App.WaitForElement(c => c.Text("Let's start by adding a new Text..."));
            Assert.IsTrue(emptyListLabelExists.Any());
        }
        
        [Test]
        public void CreateNewTextTest()
        {
            // Wait for "New Text" Button
            AppResult[] newTextButtonExists = SetupHooks.App.WaitForElement(c => c.Text("New Text"));
            Assert.IsTrue(newTextButtonExists.Any());

            for (int i = 0; i < 5; i++)
            {
                CreateNewTextSteps();
                AfterCreateNewTextSteps();
            }
        }
        
        [Test]
        public void CreateAndViewTextItemTest()
        {
            // create a new Text item
            CreateNewTextSteps();
            AfterCreateNewTextSteps();

            // check if new item was added
            Assert.Greater(SetupHooks.App.Query(c => c.Marked("TextListView").Child()).Length, 0);
            
            // get the first item in ListView
            var firstCellInListView = GetFirstItemInListView();

            // tap the first item in ListView
            SetupHooks.App.Tap(firstCellInListView);

            // viewing the item
            AppResult[] viewTextPageExists = SetupHooks.App.WaitForElement(c => c.Marked("ViewTextPage"));
            Assert.IsTrue(viewTextPageExists.Any());

            // Click on "Done" Button
            SetupHooks.App.Tap(c => c.Button("Done"));
        }

        [Test]
        public void DataPersistenceTest()
        {
            // create a new Text item
            CreateNewTextSteps();
            AfterCreateNewTextSteps();

            // restarting app, persisting state
            SetupHooks.App = AppInitializer.StartApp(SetupHooks.Platform, false);

            // check if data persists
            Assert.Greater(SetupHooks.App.Query(c => c.Marked("TextListView").Child()).Length, 0);
        }

        [Test]
        public void DeleteItemTest()
        {
            // create a new Text item
            CreateNewTextSteps();
            AfterCreateNewTextSteps();
            
            // check if data persists
            Assert.Greater(SetupHooks.App.Query(c => c.Marked("TextListView").Child()).Length, 0);

            // get the first item in ListView
            var firstCellInListView = GetFirstItemInListView();

            // pop up the Context menu in ListView item
            if (SetupHooks.Platform == Platform.Android)
                SetupHooks.App.TouchAndHold(firstCellInListView);
            else if (SetupHooks.Platform == Platform.iOS)
                SetupHooks.App.SwipeRightToLeft(firstCellInListView);

            // delete item
            SetupHooks.App.Tap(c => c.Text("Delete"));
        }
        
        public Func<AppQuery, AppQuery> GetFirstItemInListView(int timeoutInSeconds = 20)
        {
            Func<AppQuery, AppQuery> firstItemInListView = null;

            if (SetupHooks.Platform == Platform.Android)
                firstItemInListView = x => x.Class("ViewCellRenderer_ViewCellContainer").Index(0);
            else if (SetupHooks.Platform == Platform.iOS)
                firstItemInListView = x => x.Marked("TextListViewItem").Index(0);

            SetupHooks.App.WaitForElement(firstItemInListView, "Timed our waiting for the first user to appear", TimeSpan.FromSeconds(timeoutInSeconds));

            return firstItemInListView;
        }

        private void CreateNewTextSteps()
        {
            // Click on "New Text" Button
            SetupHooks.App.Tap(c => c.Button("New Text"));

            // Wait for "New Text" Page
            AppResult[] newTextPageExists = SetupHooks.App.WaitForElement(c => c.Marked("NewTextPage"));
            Assert.IsTrue(newTextPageExists.Any());

            // Wait for "Text Title" Editor
            AppResult[] textTitleEditorExists = SetupHooks.App.WaitForElement(c => c.Marked("TextTitleEditor"));
            Assert.IsTrue(textTitleEditorExists.Any());

            // Wait for "Text Text" Editor
            AppResult[] textTextEditorExists = SetupHooks.App.WaitForElement(c => c.Marked("TextTextEditor"));
            Assert.IsTrue(textTextEditorExists.Any());

            // Wait for "Save" Button
            AppResult[] saveTextButtonExists = SetupHooks.App.WaitForElement(c => c.Text("Save"));
            Assert.IsTrue(saveTextButtonExists.Any());

            // Generate fake text
            var faker = new Faker("en");
            var random = new Random();
            var sentence = faker.Lorem.Sentence(4, random.Next(12));
            var paragraph = faker.Lorem.Paragraph(1);

            // Enter text into "Text Title" Editor
            SetupHooks.App.EnterText(c => c.Marked("TextTitleEditor"),
                sentence);

            // Enter text into "Text Text" Editor
            SetupHooks.App.EnterText(c => c.Marked("TextTextEditor"),
                paragraph);

            // Hide the keyboard
            SetupHooks.App.DismissKeyboard();

            // Click on "Save" Button
            SetupHooks.App.Tap(c => c.Button("Save"));
        }

        private void AfterCreateNewTextSteps()
        {
            // Wait for "Home" Page
            AppResult[] homePageExists = SetupHooks.App.WaitForElement(c => c.Marked("HomePage"));
            Assert.IsTrue(homePageExists.Any());

            // Wait for Empty ListView Label to disappear
            SetupHooks.App.WaitForNoElement(c => c.Text("Let's start by adding a new Text..."));

            // Wait for "Home" Page
            Assert.Greater(SetupHooks.App.Query(c => c.Marked("TextListView").Child()).Length, 0);
        }
    }
}
