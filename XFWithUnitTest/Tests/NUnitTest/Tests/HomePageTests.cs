using NUnit.Framework;
using Prism.Ioc;
using System.Linq;
using Shouldly;
using Xamarin.Forms;
using XFWithUnitTest.ViewModels;

namespace NUnitTest.Tests
{
    public class HomePageTests : BaseTest
    {
        /// <summary>
        /// Navigating first time in to Home page
        /// Sees empty List view and
        /// empty data indication label
        /// </summary>
        [Test]
        public void NavigatingToHomePage()
        {
            // Is the app running
            App.ShouldNotBeNull();
            
            var navigationStack = ((NavigationPage)App.MainPage).Navigation.NavigationStack;
            // Am I in the Home page
            navigationStack.Last().BindingContext.GetType().Name.ShouldBe(nameof(HomePageViewModel));

            // ListView should be empty
            App.Container.Resolve<HomePageViewModel>().TextList.Count.ShouldBe(0);

            //Empty ListView Label Displayed
            App.Container.Resolve<HomePageViewModel>().IsEmptyTextList.ShouldBe(true);
        }
    }
}
