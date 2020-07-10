using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Ioc;
using Shouldly;
using TechTalk.SpecFlow;
using XFWithSpecflow.ViewModels;

namespace XFWithSpecflow.UnitTest.Tests
{
    [Binding]
    public class ViewTextPageSteps
    {
        public TestApp App => SetupHooks.App;

        [Then(@"I tap on first item in ListView")]
        public void ThenITapOnFirstItemInListView()
        {
            var firstTextItem = App.Container.Resolve<HomePageViewModel>().TextList.First();

            App.Container.Resolve<HomePageViewModel>().SelectedTextItem = firstTextItem;
        }

        [Then(@"I can see ""(.*)"" and ""(.*)""")]
        public void ThenICanSeeAnd(string textTitle, string text)
        {
            App.Container.Resolve<ViewTextPageViewModel>().TextItem.TextTitle.ShouldBe(textTitle);
            App.Container.Resolve<ViewTextPageViewModel>().TextItem.Text.ShouldBe(text);
        }
    }
}
