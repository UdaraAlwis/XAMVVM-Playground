using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace XFWithUITest.UITest.Tests
{
    [TestFixture(Platform.Android)]
    //[TestFixture(Platform.iOS)]
    public class HomePageTests : BaseTests
    {
        public HomePageTests(Platform platform) : base(platform)
        {

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
    }
}
