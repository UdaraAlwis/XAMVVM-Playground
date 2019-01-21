using NUnit.Framework;
using Prism.Ioc;
using System.Linq;
using Xamarin.Forms;
using XFWithUnitTest.ViewModels;

namespace NUnitTest.Tests
{
    public class HomePageTests : BastTest
    {
        [Test]
        public void NavigatingToHomePage()
        {
            // is the app running
            Assert.NotNull(App);
            
            var navigationStack = ((NavigationPage)App.MainPage).Navigation.NavigationStack;
            // Am I in the Home page
            Assert.AreEqual(navigationStack.Last().BindingContext.GetType().Name, nameof(HomePageViewModel));

            // ListView should be empty
            Assert.AreEqual(App.Container.Resolve<HomePageViewModel>().TextList.Count, 0);
        }
    }
}
