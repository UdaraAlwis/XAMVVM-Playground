using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Shouldly;
using TechTalk.SpecFlow;
using Xamarin.Forms;
using XFWithSpecflow.ViewModels;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Navigation;

namespace XFWithSpecflow.UnitTest
{
    [Binding]
    public class HomePageSteps
    {
        public TestApp App => SetupHooks.App;

        [Given(@"I have launched the app")]
        public void GivenIHaveLaunchedApp()
        {
            App.ShouldNotBeNull();
        }

        [Then(@"I am on the Home Page")]
        public void ThenIAmOnHomePage()
        {
            var navigationStack = ((NavigationPage)App.MainPage).Navigation.NavigationStack;

            // Am I in the HomePage ?
            navigationStack.Last().BindingContext.ShouldBeOfType<HomePageViewModel>();
        }

        [When(@"I click on ""(.*)"" Button")]
        public void WhenIClickOnButton(string p0)
        {
            App.Container.Resolve<HomePageViewModel>().NewTextCommand.Execute();
        }

        [Then(@"I am on the New Text Page")]
        public void ThenIAmOnTheNewTextPage()
        {
            var navigationStack = ((NavigationPage)App.MainPage).Navigation.NavigationStack;

            // Am I in the NewText Page ?
            navigationStack.Last().BindingContext.ShouldBeOfType<NewTextPageViewModel>();
        }

        [Then(@"I add New TextTitle and TextText")]
        public void ThenIAddNewTextTitleAndTextText()
        {
            App.Container.Resolve<NewTextPageViewModel>().TextItem.TextTitle = "Hello bellow title";
            App.Container.Resolve<NewTextPageViewModel>().TextItem.Text = "Hello bellow asjd asdkl alsdkajs asd as as ";
            App.Container.Resolve<NewTextPageViewModel>().TextItem.TextDateTime = DateTime.Now;
        }

        [Then(@"I click on ""(.*)"" Button")]
        public void ThenIClickOnButton(string p0)
        {
            App.Container.Resolve<NewTextPageViewModel>().SaveTextCommand.Execute();
        }

        [Then(@"I can see (.*) Text Item in ListView")]
        public void ThenICanSeeTextItemInListView(int itemCount)
        {
            App.Container.Resolve<HomePageViewModel>().TextList.Count.ShouldBe(itemCount);
        }


    }
}
