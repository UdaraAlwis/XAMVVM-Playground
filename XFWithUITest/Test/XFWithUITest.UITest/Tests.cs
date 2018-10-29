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
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform, true);
        }

        [Test]
        public void WelcomeTextIsDisplayedTest()
        {
            AppResult[] homePageExists = app.WaitForElement(c => c.Marked("HomePage"));

            Assert.IsTrue(homePageExists.Any());

            AppResult[] welcomeLabelExists = app.WaitForElement(c => c.Text("Hey there, Welcome!"));

            app.Screenshot("Welcome screen.");

            Assert.IsTrue(welcomeLabelExists.Any());
        }

        [Test]
        public void EmptyListDisplayedTest()
        {
            AppResult[] emptyListLabelExists = app.WaitForElement(c => c.Text("Let's start by adding a new Text..."));

            Assert.IsTrue(emptyListLabelExists.Any());
        }
        
        [Test]
        public void CreateNewTextTest()
        {
            // Wait for "New Text" Button
            AppResult[] newTextButtonExists = app.WaitForElement(c => c.Text("New Text"));
            Assert.IsTrue(newTextButtonExists.Any());

            for (int i = 0; i < 5; i++)
            {
                CreateNewTextSteps();
                AfterCreateNewTextSteps();
            }
        }

        [Test]
        public void DataPersistenceTest()
        {
            // create a new Text item
            CreateNewTextSteps();
            AfterCreateNewTextSteps();

            // restarting app, persisting state
            app = AppInitializer.StartApp(platform, false);

            // check if data persists
            Assert.Greater(app.Query(c => c.Marked("TextListView").Child()).Length, 0);
        }

        [Test]
        public void DeleteItemTest()
        {
            // create a new Text item
            CreateNewTextSteps();
            AfterCreateNewTextSteps();
            
            // check if data persists
            Assert.Greater(app.Query(c => c.Marked("TextListView").Child()).Length, 0);

            SelectFirstCellInList();
            
            app.Tap(c => c.Text("Delete"));
        }

        public void SelectFirstCellInList(int timeoutInSeconds = 20)
        {
            Func<AppQuery, AppQuery> firstCellInList = null;

            if (platform == Platform.Android)
                firstCellInList = x => x.Class("ViewCellRenderer_ViewCellContainer").Index(0);
            else if (platform == Platform.iOS)
                firstCellInList = x => x.Marked("{AutomationId of ViewCell}").Index(0);

            app.WaitForElement(firstCellInList, "Timed our waiting for the first user to appear", TimeSpan.FromSeconds(timeoutInSeconds));
            
            app.TouchAndHold(firstCellInList);
        }

        private void CreateNewTextSteps()
        {
            // Click on "New Text" Button
            app.Tap(c => c.Button("New Text"));

            // Wait for "New Text" Page
            AppResult[] newTextPageExists = app.WaitForElement(c => c.Marked("NewTextPage"));
            Assert.IsTrue(newTextPageExists.Any());

            // Wait for "Text Title" Editor
            AppResult[] textTitleEditorExists = app.WaitForElement(c => c.Marked("TextTitleEditor"));
            Assert.IsTrue(textTitleEditorExists.Any());

            // Wait for "Text Text" Editor
            AppResult[] textTextEditorExists = app.WaitForElement(c => c.Marked("TextTextEditor"));
            Assert.IsTrue(textTextEditorExists.Any());

            // Wait for "Save" Button
            AppResult[] saveTextButtonExists = app.WaitForElement(c => c.Text("Save"));
            Assert.IsTrue(saveTextButtonExists.Any());

            // Generate fake text
            var faker = new Faker("en");
            var random = new Random();
            var sentence = faker.Lorem.Sentence(4, random.Next(12));
            var paragraph = faker.Lorem.Paragraph(1);

            // Enter text into "Text Title" Editor
            app.EnterText(c => c.Marked("TextTitleEditor"),
                sentence);

            // Enter text into "Text Text" Editor
            app.EnterText(c => c.Marked("TextTextEditor"),
                paragraph);

            // Click on "Save" Button
            app.Tap(c => c.Button("Save"));
        }

        private void AfterCreateNewTextSteps()
        {
            // Wait for "Home" Page
            AppResult[] homePageExists = app.WaitForElement(c => c.Marked("HomePage"));
            Assert.IsTrue(homePageExists.Any());

            // Wait for Empty ListView Label to disappear
            app.WaitForNoElement(c => c.Text("Let's start by adding a new Text..."));

            // Wait for "Home" Page
            Assert.Greater(app.Query(c => c.Marked("TextListView").Child()).Length, 0);
        }
    }
}
