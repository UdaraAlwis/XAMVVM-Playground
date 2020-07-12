using TechTalk.SpecFlow;
using Prism.Ioc;
using Shouldly;
using XFTextpadApp.ViewModels;

namespace XFTextpadApp.SpecFlowTests.Tests
{
    [Binding]
    public class HomePageSteps
    {
        private readonly ScenarioContext _context;
        public TestApp App => TestHooks.App;
        public HomePageSteps(ScenarioContext injectedContext)
        {
            _context = injectedContext;
        }

        [Then(@"I can see (.*) Items in Text List")]
        public void ThenICanSeeTextItemInListView(int itemCount)
        {
            App.Container.Resolve<HomePageViewModel>().TextList.Count.ShouldBe(itemCount);
        }

        [Then(@"I can see empty Text List indicating Label displayed")]
        public void ThenICanSeeEmptyListViewLabelDisplayed()
        {
            App.Container.Resolve<HomePageViewModel>().IsEmptyTextList.ShouldBe(true);
        }

        [Then(@"I Close and Reopen the app")]
        public void ThenICloseAndReopenTheApp()
        {
            // Mocking Relaunching of the app
            TestHooks hooks = new TestHooks();
            hooks.BeforeScenario();

            // App Relaunched
        }
    }
}
