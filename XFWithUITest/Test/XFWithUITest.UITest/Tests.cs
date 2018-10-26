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
            AppResult[] emptyListLabelExisits = app.WaitForElement(c => c.Text("Let's start by adding a new Idea..."));

            Assert.IsTrue(emptyListLabelExisits.Any());
        }
        
        [Test]
        public void CreateNewIdeaTest()
        {
            AppResult[] newIdeaButtonExists = app.WaitForElement(c => c.Text("New Idea"));
            Assert.IsTrue(newIdeaButtonExists.Any());

            for (int i = 0; i < 5; i++)
            {
                CreateNewIdeaSteps();
                AfterCreateNewIdeaSteps();
            }
        }

        private void CreateNewIdeaSteps()
        {
            app.Tap(c => c.Button("New Idea"));

            AppResult[] newIdeaPageExists = app.WaitForElement(c => c.Marked("NewIdeaPage"));
            Assert.IsTrue(newIdeaPageExists.Any());

            AppResult[] ideaTitleEditorExists = app.WaitForElement(c => c.Marked("IdeaTitleEditor"));
            Assert.IsTrue(ideaTitleEditorExists.Any());
            
            var faker = new Faker("en");
            var random = new Random();
            var sentence = faker.Lorem.Sentence(2, random.Next(10));
            var paragraph = faker.Lorem.Paragraph(1);

            app.EnterText(c => c.Marked("IdeaTitleEditor"),
                sentence);

            AppResult[] ideaTextEditorExists = app.WaitForElement(c => c.Marked("IdeaTextEditor"));
            Assert.IsTrue(ideaTextEditorExists.Any());

            app.EnterText(c => c.Marked("IdeaTextEditor"),
                paragraph);

            AppResult[] saveIdeaButtonExists = app.WaitForElement(c => c.Text("Save"));
            Assert.IsTrue(saveIdeaButtonExists.Any());

            app.Tap(c => c.Button("Save"));
        }

        private void AfterCreateNewIdeaSteps()
        {
            AppResult[] homePageExists = app.WaitForElement(c => c.Marked("HomePage"));
            Assert.IsTrue(homePageExists.Any());

            app.WaitForNoElement(c => c.Text("Let's start by adding a new Idea..."));
            
            Assert.Greater(app.Query(c => c.Marked("NoteListView").Child()).Length, 0);
        }
    }
}
