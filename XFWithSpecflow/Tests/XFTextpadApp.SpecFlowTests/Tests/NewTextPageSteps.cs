using System;
using System.Linq;
using Prism.Ioc;
using TechTalk.SpecFlow;
using XFTextpadApp.ViewModels;

namespace XFTextpadApp.SpecFlowTests.Tests
{
    [Binding]
    public class NewTextPageSteps
    {
        private readonly ScenarioContext _context;
        public TestApp App => TestHooks.App;
        public NewTextPageSteps(ScenarioContext injectedContext)
        {
            _context = injectedContext;
        }

        [Then(@"I add New ""(.*)"" and ""(.*)""")]
        public void ThenIAddNewAnd(string textTitle, string text)
        {
            App.Container.Resolve<NewTextPageViewModel>().TextItem.TextTitle = textTitle;
            App.Container.Resolve<NewTextPageViewModel>().TextItem.Text = text;
            App.Container.Resolve<NewTextPageViewModel>().TextItem.TextDateTime = DateTime.Now;
        }


        [Then(@"I Delete first item from Text List")]
        public void ThenIDeleteFirstItemFromListView()
        {
           var firstTextItem = App.Container.Resolve<HomePageViewModel>().TextList.First();

           App.Container.Resolve<HomePageViewModel>().DeleteTextCommand.Execute(firstTextItem);
        }

    }
}
