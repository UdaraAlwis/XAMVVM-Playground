using NUnit.Framework;
using Prism.Ioc;
using System.Linq;
using Tests;
using Unity;
using Xamarin.Forms;
using XFWithUnitTest.ViewModels;

namespace NUnitTest.Tests
{
    public class HomePageTests
    {
        public TestApp App => SetupHooks.App;
        
        [Test]
        public void NavigatingToHomePage()
        {
            Assert.NotNull(App);
            Assert.AreSame(App.Container.Resolve<HomePageViewModel>().TextList.Count, 0);
            
            var navigationStack = ((NavigationPage)App.MainPage).Navigation.NavigationStack;
            // Am I in the page
            Assert.AreSame(navigationStack.Last().BindingContext.GetType().Name, nameof(HomePageViewModel));
        }
    }
}
