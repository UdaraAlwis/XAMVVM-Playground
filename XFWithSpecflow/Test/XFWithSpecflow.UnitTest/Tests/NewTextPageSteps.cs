using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Prism.Commands;
using Prism.Ioc;
using Shouldly;
using TechTalk.SpecFlow;
using Xamarin.Forms;
using XFWithSpecflow.ViewModels;
using XFWithSpecflow.Views;

namespace XFWithSpecflow.UnitTest.Tests
{
    [Binding]
    public class NewTextPageSteps
    {
        public TestApp App => SetupHooks.App;
        
        [Then(@"I add New TextTitle and TextText")]
        public void ThenIAddNewTextTitleAndTextText()
        {
            App.Container.Resolve<NewTextPageViewModel>().TextItem.TextTitle = "Hello bellow title";
            App.Container.Resolve<NewTextPageViewModel>().TextItem.Text = "Hello bellow asjd asdkl alsdkajs asd as as ";
            App.Container.Resolve<NewTextPageViewModel>().TextItem.TextDateTime = DateTime.Now;
        }

        [Then(@"I Delete first item from ListView")]
        public void ThenIDeleteFirstItemFromListView()
        {
           var firstTextItem = App.Container.Resolve<HomePageViewModel>().TextList.First();

           App.Container.Resolve<HomePageViewModel>().DeleteTextCommand.Execute(firstTextItem);
        }

    }
}
