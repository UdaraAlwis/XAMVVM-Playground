using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Prism.Ioc;
using Shouldly;
using Xamarin.Forms;
using XFWithUnitTest.Models;
using XFWithUnitTest.ViewModels;

namespace NUnitTest.Tests
{
    [TestFixture]
    public class NewTextPageTests : BaseTest
    {
        /// <summary>
        /// Navigating first time in to Home page
        /// Sees empty List view and
        /// empty data indication label
        /// </summary>
        [Test]
        public void NavigatingToNewTextPage()
        {
            // Is the app running
            App.ShouldNotBeNull();

            var navigationStack = ((NavigationPage) App.MainPage).Navigation.NavigationStack;

            // Am I in the Home page
            navigationStack.Last().BindingContext.GetType().Name.ShouldBe(nameof(HomePageViewModel));

            // Navigating to New Text page
            App.Container.Resolve<HomePageViewModel>().NewTextCommand.Execute();

            // await Task.Delay(500);

            // Am I in the New Text page
            navigationStack.Last().BindingContext.GetType().Name.ShouldBe(nameof(NewTextPageViewModel));
        }

        [Test]
        public void CreatingNewTextItem()
        {
            // Is the app running
            App.ShouldNotBeNull();

            var navigationStack = ((NavigationPage) App.MainPage).Navigation.NavigationStack;
            // Am I in the Home page
            navigationStack.Last().BindingContext.GetType().Name.ShouldBe(nameof(HomePageViewModel));

            // Navigating to New Text page
            App.Container.Resolve<HomePageViewModel>().NewTextCommand.Execute();

            App.Container.Resolve<NewTextPageViewModel>().TextItem = new TextItem()
            {
                TextTitle = "Juis yuwe sjkl Tywe oiq aklsjd asqw al.",
                Text = "Binf yuw tyasas pwerq asyu tui nuiwe aske yrwn kashdihas asju ywte.",
            };

            // I click on "SaveText" Button
            App.Container.Resolve<NewTextPageViewModel>().SaveTextCommand.Execute();

            // Am I in the Home page
            navigationStack.Last().BindingContext.GetType().Name.ShouldBe(nameof(HomePageViewModel));

            // ListView should not be empty
            App.Container.Resolve<HomePageViewModel>().TextList.Count.ShouldBeGreaterThan(0);
        }


        [Test]
        public void InputDataValidation()
        {
            // Is the app running
            App.ShouldNotBeNull();

            var navigationStack = ((NavigationPage)App.MainPage).Navigation.NavigationStack;
            // Am I in the Home page
            navigationStack.Last().BindingContext.GetType().Name.ShouldBe(nameof(HomePageViewModel));

            // Navigating to New Text page
            App.Container.Resolve<HomePageViewModel>().NewTextCommand.Execute();

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
