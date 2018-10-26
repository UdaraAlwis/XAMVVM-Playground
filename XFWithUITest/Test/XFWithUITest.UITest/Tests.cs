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
            app = AppInitializer.StartApp(platform);
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
            AppResult[] newTextButtonExists = app.WaitForElement(c => c.Text("New Text"));
            Assert.IsTrue(newTextButtonExists.Any());

            for (int i = 0; i < 5; i++)
            {
                CreateNewTextSteps();
                AfterCreateNewTextSteps();
            }
        }

        private void CreateNewTextSteps()
        {
            app.Tap(c => c.Button("New Text"));

            AppResult[] newTextPageExists = app.WaitForElement(c => c.Marked("NewTextPage"));
            Assert.IsTrue(newTextPageExists.Any());

            AppResult[] textTitleEditorExists = app.WaitForElement(c => c.Marked("TextTitleEditor"));
            Assert.IsTrue(textTitleEditorExists.Any());
            
            var faker = new Faker("en");
            var random = new Random();
            var sentence = faker.Lorem.Sentence(4, random.Next(12));
            var paragraph = faker.Lorem.Paragraph(1);

            app.EnterText(c => c.Marked("TextTitleEditor"),
                sentence);

            AppResult[] textTextEditorExists = app.WaitForElement(c => c.Marked("TextTextEditor"));
            Assert.IsTrue(textTextEditorExists.Any());

            app.EnterText(c => c.Marked("TextTextEditor"),
                paragraph);

            AppResult[] saveTextButtonExists = app.WaitForElement(c => c.Text("Save"));
            Assert.IsTrue(saveTextButtonExists.Any());

            app.Tap(c => c.Button("Save"));
        }

        private void AfterCreateNewTextSteps()
        {
            AppResult[] homePageExists = app.WaitForElement(c => c.Marked("HomePage"));
            Assert.IsTrue(homePageExists.Any());

            app.WaitForNoElement(c => c.Text("Let's start by adding a new Text..."));
            
            Assert.Greater(app.Query(c => c.Marked("TextListView").Child()).Length, 0);
        }
    }
}
