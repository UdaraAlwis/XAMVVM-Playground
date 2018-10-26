using System;
using System.IO;
using System.Linq;
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
        public void WelcomeTextIsDisplayed()
        {
            AppResult[] homePageExists = app.WaitForElement(c => c.Marked("HomePage"));

            Assert.IsTrue(homePageExists.Any());

            AppResult[] welcomeLabelExists = app.WaitForElement(c => c.Text("Hey there, Welcome!"));

            app.Screenshot("Welcome screen.");

            Assert.IsTrue(welcomeLabelExists.Any());
        }

        [Test]
        public void EmptyListDisplayed()
        {
            AppResult[] emptyListLabelExisits = app.WaitForElement(c => c.Text("Let's start by adding a new Idea..."));

            Assert.IsTrue(emptyListLabelExisits.Any());
        }
        
        [Test]
        public void CreateNewIdea()
        {
            AppResult[] newIdeaButtonExists = app.WaitForElement(c => c.Text("New Idea"));
            Assert.IsTrue(newIdeaButtonExists.Any());

            app.Tap(c => c.Button("New Idea"));
            
            AppResult[] newIdeaPageExists = app.WaitForElement(c => c.Marked("NewIdeaPage"));
            Assert.IsTrue(newIdeaPageExists.Any());
            
            AppResult[] ideaTitleEditorExists = app.WaitForElement(c => c.Marked("IdeaTitleEditor"));
            Assert.IsTrue(ideaTitleEditorExists.Any());
            
            app.EnterText(c => c.Marked("IdeaTitleEditor"), "This is the jumbo peanut mango tree");
            
            AppResult[] ideaTextEditorExists = app.WaitForElement(c => c.Marked("IdeaTextEditor"));
            Assert.IsTrue(ideaTextEditorExists.Any());

            app.EnterText(c => c.Marked("IdeaTextEditor"), "The first man on the pool gets the coconut filled with banana and peanuts while the monkey jumping around");
            
            AppResult[] saveIdeaButtonExists = app.WaitForElement(c => c.Text("Save"));
            Assert.IsTrue(saveIdeaButtonExists.Any());

            app.Tap(c => c.Button("Save"));

            AppResult[] homePageExists = app.WaitForElement(c => c.Marked("HomePage"));
            Assert.IsTrue(homePageExists.Any());
            
            app.WaitForNoElement(c => c.Text("Let's start by adding a new Idea..."));

            AppResult[] noteListViewExists = app.Query(c => c.Marked("NoteListView"));
            Assert.Greater(app.Query(c => c.Marked("NoteListView").Child()).Length, 1);
        }
    }
}
