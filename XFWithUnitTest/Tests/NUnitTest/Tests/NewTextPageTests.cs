using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Prism.Ioc;
using Shouldly;
using Xamarin.Forms;
using XFWithUnitTest.Models;
using XFWithUnitTest.ViewModels;

namespace NUnitTest.Tests
{
    public class NewTextPageTests : BaseTest
    {
        [Test]
        public void NavigatingToNewTextPage()
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
        }

        [Test]
        public void CreatingNewTextItem()
        {
            // Is the app running
            App.ShouldNotBeNull();

            var navigationStack = ((NavigationPage)App.MainPage).Navigation.NavigationStack;
            // Am I in the Home page
            navigationStack.Last().BindingContext.GetType().Name.ShouldBe(nameof(HomePageViewModel));

            // Navigating to New Text page
            App.Container.Resolve<HomePageViewModel>().NewTextCommand.Execute();

            App.Container.Resolve<NewTextPageViewModel>().TextItem = new TextItem()
            {
                TextTitle = "Juis yuwe sjkl Tywe oiq aklsjd asqw al.",
                Text = "Binf yuw tyasas pwerq asyu tui nuiwe aske yrwn kashdihas asju ywte.",
                TextDateTime = DateTime.Now
            };

            // I click on "SaveText" Button
            App.Container.Resolve<NewTextPageViewModel>().SaveTextCommand.Execute();

            // Am I in the Home page
            navigationStack.Last().BindingContext.GetType().Name.ShouldBe(nameof(HomePageViewModel));

            // ListView should not be empty
            App.Container.Resolve<HomePageViewModel>().TextList.Count.ShouldBeGreaterThan(0);
        }
    }
}
