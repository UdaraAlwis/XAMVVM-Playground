using NUnit.Framework;
using Prism.Ioc;
using System.Linq;
using Shouldly;
using Xamarin.Forms;
using XFWithUnitTest.Models;
using XFWithUnitTest.ViewModels;

namespace NUnitTest.Tests
{
    [TestFixture]
    public class HomePageTests : BaseTest
    {
        /// <summary>
        /// Launching the app for the  first
        /// time and navigating in to Home page
        /// </summary>
        [Test]
        public void NavigatingToHomePage()
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
        /// Adding an Item from the Text List and
        /// Deleting an Item from the Text List
        /// </summary>
        [Test]
        public void DeletingTextItem()
        {
            // Is the app running
            App.ShouldNotBeNull();

            // Am I in the Home page
            GetCurrentPage().BindingContext.GetType().Name.ShouldBe(nameof(HomePageViewModel));

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
        /// Deleting an Item from the Text List
        /// </summary>
        [Test]
        public void DataPersistenceTest()
        {
            // Is the app running
            App.ShouldNotBeNull();

            // Am I in the Home page
            GetCurrentPage().BindingContext.GetType().Name.ShouldBe(nameof(HomePageViewModel));

            // Navigating to New Text page
            App.Container.Resolve<HomePageViewModel>().NewTextCommand.Execute();

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

            // Mocking relaunching of the app
            base.Setup();

            // App relaunched

            // ListView should be empty
            App.Container.Resolve<HomePageViewModel>().TextList.Count.ShouldBe(1);
        }
    }
}
