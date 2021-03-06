﻿using NUnit.Framework;
using Prism.Ioc;
using System.Linq;
using Shouldly;
using XFTextpadApp.Models;
using XFTextpadApp.ViewModels;

namespace XFTextpadApp.NUnitTests.Tests
{
    [TestFixture]
    public class HomePageTests : BaseTest
    {
        /// <summary>
        /// Launching the app for the  first
        /// time and navigating in to Home page
        /// </summary>
        [Test]
        public void AppLaunchingFirstTimeTest()
        {
            // Is the app running
            App.ShouldNotBeNull();
            
            // Am I in the Home page
            GetCurrentPage().BindingContext.GetType().Name.ShouldBe(nameof(HomePageViewModel));

            // ListView should be empty
            App.Container.Resolve<HomePageViewModel>().TextList.Count.ShouldBe(0);

            // Empty ListView Label Displayed
            App.Container.Resolve<HomePageViewModel>().IsEmptyTextList.ShouldBe(true);
        }

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
        /// Adding an Item from the Text List and
        /// Deleting an Item from the Text List
        /// </summary>
        [Test]
        public void DeletingTextItemTest()
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

            // Check if we see new Text Item in the List
            App.Container.Resolve<HomePageViewModel>().TextList.Count.ShouldBe(1);

            // Delete the Text Item from the List
            var textListItem = App.Container.Resolve<HomePageViewModel>().TextList.First();
            App.Container.Resolve<HomePageViewModel>().DeleteTextCommand.Execute(textListItem);

            // ListView should be empty
            App.Container.Resolve<HomePageViewModel>().TextList.Count.ShouldBe(0);
        }

        /// <summary>
        /// Adding an Item from the Text List and
        /// Saving it in the App data cache
        /// </summary>
        [Test]
        public void DataPersistenceTest()
        {
            // Is the app running
            App.ShouldNotBeNull();

            // Am I in the Home page
            GetCurrentPage().BindingContext.GetType().Name.ShouldBe(nameof(HomePageViewModel));

            // Navigating to New Text page
            App.Container.Resolve<HomePageViewModel>().GoToNewTextPageCommand.Execute();

            // Crete a new Text Item
            App.Container.Resolve<NewTextPageViewModel>().TextItem = new TextItem()
            {
                TextTitle = "Juis yuwe sjkl Tywe oiq aklsjd asqw al.",
                Text = "Binf yuw tyasas pwerq asyu tui nuiwe aske yrwn kashdihas asju ywte.",
            };

            // I click on "SaveText" Button
            App.Container.Resolve<NewTextPageViewModel>().SaveTextCommand.Execute();

            // Am I in the Home page
            GetCurrentPage().BindingContext.GetType().Name.ShouldBe(nameof(HomePageViewModel));

            // Check if we see new Text Item in the List
            App.Container.Resolve<HomePageViewModel>().TextList.Count.ShouldBe(1);

            // Mocking Relaunching of the app
            base.Setup();

            // App Relaunched

            // Check if we still see new Text Item in the List
            App.Container.Resolve<HomePageViewModel>().TextList.Count.ShouldBe(1);
        }
    }
}
