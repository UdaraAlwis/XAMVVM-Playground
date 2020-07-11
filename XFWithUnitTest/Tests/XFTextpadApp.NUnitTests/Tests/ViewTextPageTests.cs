using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Prism.Ioc;
using Shouldly;
using Xamarin.Forms;
using XFTextpadApp.Models;
using XFTextpadApp.ViewModels;
using XFTextpadApp.Views;

namespace XFTextpadApp.NUnitTests.Tests
{
    [TestFixture]
    public class ViewTextPageTests : BaseTest
    {
        /// <summary>
        /// Navigating to the View Text Page from the Home
        /// Page by selecting a Text item from the Text List
        /// </summary>
        [Test]
        public void NavigatingToViewTextPageTest()
        {
            // Is the app running
            App.ShouldNotBeNull();

            // Am I in the Home page
            GetCurrentPage().BindingContext.GetType().Name.ShouldBe(nameof(HomePageViewModel));

            // Navigating to New Text page
            App.Container.Resolve<HomePageViewModel>().GoToNewTextPageCommand.Execute();

            // Create a new Text item
            var newTextItem = App.Container.Resolve<NewTextPageViewModel>().TextItem = CreateSampleTextItem();

            // I click on "SaveText" Button
            App.Container.Resolve<NewTextPageViewModel>().SaveTextCommand.Execute();

            // Am I in the Home page
            GetCurrentPage().BindingContext.GetType().Name.ShouldBe(nameof(HomePageViewModel));

            // Check if we see new Text Item in the List
            App.Container.Resolve<HomePageViewModel>().TextList.Count.ShouldBe(1);

            // Select a Text item from the Text List
            App.Container.Resolve<HomePageViewModel>().SelectedTextItem =
                App.Container.Resolve<HomePageViewModel>().TextList.First();

            // Am I in the View Text page
            GetCurrentPage().BindingContext.GetType().Name.ShouldBe(nameof(ViewTextPageViewModel));

            // Check the viewing Text item details
            var viewingTextItem = App.Container.Resolve<ViewTextPageViewModel>().TextItem;
            viewingTextItem.TextTitle.ShouldBe(newTextItem.TextTitle);
            viewingTextItem.Text.ShouldBe(newTextItem.Text);
            viewingTextItem.TextDateTime.ShouldBe(newTextItem.TextDateTime);
            viewingTextItem.LocationLatLong.ShouldBe(newTextItem.LocationLatLong);
        }

        /// <summary>
        /// Navigating to the View Text Page from the Home
        /// Page by selecting a Text item from the Text List
        /// and Going back to the Home Page
        /// </summary>
        [Test]
        public async Task ViewTextDetailsAndGoBackTest()
        {
            // Is the app running
            App.ShouldNotBeNull();

            // Am I in the Home page
            GetCurrentPage().BindingContext.GetType().Name.ShouldBe(nameof(HomePageViewModel));

            // Navigating to New Text page
            App.Container.Resolve<HomePageViewModel>().GoToNewTextPageCommand.Execute();

            // Create a new Text item
            var newTextItem = App.Container.Resolve<NewTextPageViewModel>().TextItem = CreateSampleTextItem();

            // I click on "SaveText" Button
            App.Container.Resolve<NewTextPageViewModel>().SaveTextCommand.Execute();

            // Am I in the Home page
            GetCurrentPage().BindingContext.GetType().Name.ShouldBe(nameof(HomePageViewModel));

            // Check if we see new Text Item in the List
            App.Container.Resolve<HomePageViewModel>().TextList.Count.ShouldBe(1);

            // Select a Text item from the Text List
            App.Container.Resolve<HomePageViewModel>().SelectedTextItem =
                App.Container.Resolve<HomePageViewModel>().TextList.First();

            // Am I in the View Text page
            GetCurrentPage().BindingContext.GetType().Name.ShouldBe(nameof(ViewTextPageViewModel));

            // Check the viewing Text item details
            var viewingTextItem = App.Container.Resolve<ViewTextPageViewModel>().TextItem;
            viewingTextItem.TextTitle.ShouldBe(newTextItem.TextTitle);
            viewingTextItem.Text.ShouldBe(newTextItem.Text);
            viewingTextItem.TextDateTime.ShouldBe(newTextItem.TextDateTime);
            viewingTextItem.LocationLatLong.ShouldBe(newTextItem.LocationLatLong);

            var textTitleLabel = ((Label)((Grid)((ViewTextPage)GetCurrentPage()).Content).Children.First());
            textTitleLabel.Text.ShouldBe(newTextItem.TextTitle);

            // Click "Done" button and navigate backwards
            App.Container.Resolve<ViewTextPageViewModel>().DoneCommand.Execute();

            // Performing UI backward navigation
            await ((NavigationPage) App.MainPage).Navigation.PopAsync();

            // Am I in the Home page
            GetCurrentPage().BindingContext.GetType().Name.ShouldBe(nameof(HomePageViewModel));

            // Check if we still see new Text Item in the List
            App.Container.Resolve<HomePageViewModel>().TextList.Count.ShouldBe(1);
        }

        public TextItem CreateSampleTextItem()
        {
            // Create a new Text item
            var textItem = new TextItem()
            {
                TextTitle = "Juis yuwe sjkl Tywe oiq aklsjd asqw al.",
                Text = "Binf yuw tyasas pwerq asyu tui nuiwe aske yrwn kashdihas asju ywte.",
            };

            return textItem;
        }
    }
}
