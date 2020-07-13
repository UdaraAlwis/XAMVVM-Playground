using System.Linq;
using NUnit.Framework;
using Prism.Ioc;
using Shouldly;
using Xamarin.Forms;
using XFTextpadApp.Models;
using XFTextpadApp.ViewModels;

namespace XFTextpadApp.NUnitTests.Tests
{
    [TestFixture]
    public class NewTextPageTests : BaseTest
    {
        /// <summary>
        /// Navigating to the New Text Page from the 
        /// Home Page by clicking "New Text" button
        /// </summary>
        [Test]
        public void NavigatingToNewTextPageTest()
        {
            // Is the app running
            App.ShouldNotBeNull();

            // Am I in the Home page
            GetCurrentPage().BindingContext.GetType().Name.ShouldBe(nameof(HomePageViewModel));

            // Navigating to New Text page
            App.Container.Resolve<HomePageViewModel>().GoToNewTextPageCommand.Execute();

            // Am I in the New Text page
            GetCurrentPage().BindingContext.GetType().Name.ShouldBe(nameof(NewTextPageViewModel));
        }

        /// <summary>
        /// Creating a New Text Item
        /// and Saving it in the App
        /// </summary>
        [Test]
        public void CreatingNewTextItemTest()
        {
            // Is the app running
            App.ShouldNotBeNull();

            // Am I in the Home page
            GetCurrentPage().BindingContext.GetType().Name.ShouldBe(nameof(HomePageViewModel));

            // Navigating to New Text page
            App.Container.Resolve<HomePageViewModel>().GoToNewTextPageCommand.Execute();

            App.Container.Resolve<NewTextPageViewModel>().TextItem = new TextItem()
            {
                TextTitle = "Juis yuwe sjkl Tywe oiq aklsjd asqw al.",
                Text = "Binf yuw tyasas pwerq asyu tui nuiwe aske yrwn kashdihas asju ywte.",
            };

            // I click on "SaveText" Button
            App.Container.Resolve<NewTextPageViewModel>().SaveTextCommand.Execute();

            // Am I in the Home page
            GetCurrentPage().BindingContext.GetType().Name.ShouldBe(nameof(HomePageViewModel));

            // ListView should not be empty
            App.Container.Resolve<HomePageViewModel>().TextList.Count.ShouldBeGreaterThan(0);
        }

        /// <summary>
        /// Validating the Input data fields
        /// during creating a new Text Item
        /// </summary>
        [Test]
        public void ValidatingInputDataTest()
        {
            // Is the app running
            App.ShouldNotBeNull();

            var navigationStack = ((NavigationPage)App.MainPage).Navigation.NavigationStack;
            // Am I in the Home page
            navigationStack.Last().BindingContext.GetType().Name.ShouldBe(nameof(HomePageViewModel));

            // Navigating to New Text page
            App.Container.Resolve<HomePageViewModel>().GoToNewTextPageCommand.Execute();

            // Am I in the New Text page
            navigationStack.Last().BindingContext.GetType().Name.ShouldBe(nameof(NewTextPageViewModel));

            // Not adding any text and try to save empty
            // I click on "SaveText" Button
            App.Container.Resolve<NewTextPageViewModel>().SaveTextCommand.Execute();

            // Save should fail and not navigated back to Home Page

            // Am I in the New Text page
            navigationStack.Last().BindingContext.GetType().Name.ShouldBe(nameof(NewTextPageViewModel));

            // Filling up only Title text and try to save
            App.Container.Resolve<NewTextPageViewModel>().TextItem = new TextItem()
            {
                TextTitle = "Juis yuwe sjkl Tywe oiq aklsjd asqw al.",
            };

            // Save should fail and not navigated back to Home Page

            // Am I in the New Text page
            navigationStack.Last().BindingContext.GetType().Name.ShouldBe(nameof(NewTextPageViewModel));

            // I click on "SaveText" Button
            App.Container.Resolve<NewTextPageViewModel>().SaveTextCommand.Execute();

            // Save should fail and not navigated back to Home Page

            // Am I in the New Text page
            navigationStack.Last().BindingContext.GetType().Name.ShouldBe(nameof(NewTextPageViewModel));

            // Filling up only body Text and try to save
            App.Container.Resolve<NewTextPageViewModel>().TextItem = new TextItem()
            {
                Text = "Binf yuw tyasas pwerq asyu tui nuiwe aske yrwn kashdihas asju ywte.",
            };

            // I click on "SaveText" Button
            App.Container.Resolve<NewTextPageViewModel>().SaveTextCommand.Execute();

            // Save should fail and not navigated back to Home Page

            // Am I in the New Text page
            navigationStack.Last().BindingContext.GetType().Name.ShouldBe(nameof(NewTextPageViewModel));

            // Filling up Text Title and body Text and try to save
            App.Container.Resolve<NewTextPageViewModel>().TextItem = new TextItem()
            {
                TextTitle = "Juis yuwe sjkl Tywe oiq aklsjd asqw al.",
                Text = "Binf yuw tyasas pwerq asyu tui nuiwe aske yrwn kashdihas asju ywte.",
            };

            // I click on "SaveText" Button
            App.Container.Resolve<NewTextPageViewModel>().SaveTextCommand.Execute();

            // Save should succeed and I am Navigated back to Home Page
            navigationStack.Last().BindingContext.GetType().Name.ShouldBe(nameof(HomePageViewModel));
        }
    }
}
