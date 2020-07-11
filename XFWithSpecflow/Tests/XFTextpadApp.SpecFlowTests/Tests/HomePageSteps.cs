using TechTalk.SpecFlow;
using Prism.Ioc;
using Shouldly;
using XFTextpadApp.ViewModels;

namespace XFTextpadApp.SpecFlowTests.Tests
{
    [Binding]
    public class HomePageSteps
    {
        public TestApp App => TestHooks.App;
        
        [Then(@"I can see (.*) Text Items in ListView")]
        public void ThenICanSeeTextItemInListView(int itemCount)
        {
            App.Container.Resolve<HomePageViewModel>().TextList.Count.ShouldBe(itemCount);
        }

        [Then(@"I can see Empty ListView Label Displayed")]
        public void ThenICanSeeEmptyListViewLabelDisplayed()
        {
            App.Container.Resolve<HomePageViewModel>().IsEmptyTextList.ShouldBe(true);
        }
    }
}
