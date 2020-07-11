using System.Linq;
using System.Threading.Tasks;
using Prism.Ioc;
using Shouldly;
using TechTalk.SpecFlow;
using Xamarin.Forms;
using XFTextpadApp.ViewModels;

namespace XFTextpadApp.SpecFlowTests.Tests
{
    [Binding]
    public class ViewTextPageSteps
    {
        public TestApp App => TestHooks.App;

        [Then(@"I tap on first item in ListView")]
        public void ThenITapOnFirstItemInListView()
        {
            var firstTextItem = App.Container.Resolve<HomePageViewModel>().TextList.First();

            App.Container.Resolve<HomePageViewModel>().SelectedTextItem = firstTextItem;
        }

        [Then(@"I can see Text Title ""(.*)"" and Text ""(.*)""")]
        public void ThenICanSeeAnd(string textTitle, string text)
        {
            App.Container.Resolve<ViewTextPageViewModel>().TextItem.TextTitle.ShouldBe(textTitle);
            App.Container.Resolve<ViewTextPageViewModel>().TextItem.Text.ShouldBe(text);
        }

        [When(@"I am navigating Backwards")]
        public async Task WhenIAmNavigatingBackwards()
        {
            await ((NavigationPage) App.MainPage).Navigation.PopAsync();
        }

    }
}
