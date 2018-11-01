using System;
using System.IO;
using System.Linq;
using Bogus;
using Bogus.DataSets;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace XFWithUITest.UITest
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class Tests
    { 
        private IApp _app;
        private readonly Platform _platform;

        public Tests(Platform platform)
        {
            this._platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            _app = AppInitializer.StartApp(_platform, true);
        }

        [Test]
        public void WelcomeTextIsDisplayedTest()
        {
            AppResult[] homePageExists = _app.WaitForElement(c => c.Marked("HomePage"));
            Assert.IsTrue(homePageExists.Any());

            AppResult[] welcomeLabelExists = _app.WaitForElement(c => c.Text("Hey there, Welcome!"));
            _app.Screenshot("Welcome screen.");

            Assert.IsTrue(welcomeLabelExists.Any());
        }

        [Test]
        public void EmptyListDisplayedTest()
        {
            AppResult[] emptyListLabelExists = _app.WaitForElement(c => c.Text("Let's start by adding a new Text..."));
            Assert.IsTrue(emptyListLabelExists.Any());
        }
        
        [Test]
        public void CreateNewTextTest()
        {
            // Wait for "New Text" Button
            AppResult[] newTextButtonExists = _app.WaitForElement(c => c.Text("New Text"));
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
            Assert.Greater(_app.Query(c => c.Marked("TextListView").Child()).Length, 0);
            
            // get the first item in ListView
            var firstCellInListView = GetFirstItemInListView();

            // tap the first item in ListView
            _app.Tap(firstCellInListView);

            // viewing the item
            AppResult[] viewTextPageExists = _app.WaitForElement(c => c.Marked("ViewTextPage"));
            Assert.IsTrue(viewTextPageExists.Any());

            // Click on "Done" Button
            _app.Tap(c => c.Button("Done"));
        }

        [Test]
        public void DataPersistenceTest()
        {
            // create a new Text item
            CreateNewTextSteps();
            AfterCreateNewTextSteps();

            // restarting app, persisting state
            _app = AppInitializer.StartApp(_platform, false);

            // check if data persists
            Assert.Greater(_app.Query(c => c.Marked("TextListView").Child()).Length, 0);
        }

        [Test]
        public void DeleteItemTest()
        {
            // create a new Text item
            CreateNewTextSteps();
            AfterCreateNewTextSteps();
            
            // check if data persists
            Assert.Greater(_app.Query(c => c.Marked("TextListView").Child()).Length, 0);

            // get the first item in ListView
            var firstCellInListView = GetFirstItemInListView();

            // pop up the Context menu in ListView item
            if (_platform == Platform.Android)
                _app.TouchAndHold(firstCellInListView);
            else if (_platform == Platform.iOS)
                _app.SwipeRightToLeft(firstCellInListView);

            // delete item
            _app.Tap(c => c.Text("Delete"));
        }
        
        public Func<AppQuery, AppQuery> GetFirstItemInListView(int timeoutInSeconds = 20)
        {
            Func<AppQuery, AppQuery> firstItemInListView = null;

            if (_platform == Platform.Android)
                firstItemInListView = x => x.Class("ViewCellRenderer_ViewCellContainer").Index(0);
            else if (_platform == Platform.iOS)
                firstItemInListView = x => x.Marked("TextListViewItem").Index(0);

            _app.WaitForElement(firstItemInListView, "Timed our waiting for the first user to appear", TimeSpan.FromSeconds(timeoutInSeconds));

            return firstItemInListView;
        }

        private void CreateNewTextSteps()
        {
            // Click on "New Text" Button
            _app.Tap(c => c.Button("New Text"));

            // Wait for "New Text" Page
            AppResult[] newTextPageExists = _app.WaitForElement(c => c.Marked("NewTextPage"));
            Assert.IsTrue(newTextPageExists.Any());

            // Wait for "Text Title" Editor
            AppResult[] textTitleEditorExists = _app.WaitForElement(c => c.Marked("TextTitleEditor"));
            Assert.IsTrue(textTitleEditorExists.Any());

            // Wait for "Text Text" Editor
            AppResult[] textTextEditorExists = _app.WaitForElement(c => c.Marked("TextTextEditor"));
            Assert.IsTrue(textTextEditorExists.Any());

            // Wait for "Save" Button
            AppResult[] saveTextButtonExists = _app.WaitForElement(c => c.Text("Save"));
            Assert.IsTrue(saveTextButtonExists.Any());

            // Generate fake text
            var faker = new Faker("en");
            var random = new Random();
            var sentence = faker.Lorem.Sentence(4, random.Next(12));
            var paragraph = faker.Lorem.Paragraph(1);

            // Enter text into "Text Title" Editor
            _app.EnterText(c => c.Marked("TextTitleEditor"),
                sentence);

            // Enter text into "Text Text" Editor
            _app.EnterText(c => c.Marked("TextTextEditor"),
                paragraph);

            // Hide the keyboard
            _app.DismissKeyboard();

            // Click on "Save" Button
            _app.Tap(c => c.Button("Save"));
        }

        private void AfterCreateNewTextSteps()
        {
            // Wait for "Home" Page
            AppResult[] homePageExists = _app.WaitForElement(c => c.Marked("HomePage"));
            Assert.IsTrue(homePageExists.Any());

            // Wait for Empty ListView Label to disappear
            _app.WaitForNoElement(c => c.Text("Let's start by adding a new Text..."));

            // Wait for "Home" Page
            Assert.Greater(_app.Query(c => c.Marked("TextListView").Child()).Length, 0);
        }
    }
}
