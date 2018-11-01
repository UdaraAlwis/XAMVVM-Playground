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

namespace XFWithSpecflow.UnitTest.Tests
{
    [Binding]
    public class HomePageSteps
    {
        public TestApp App => SetupHooks.App;
        
        [Then(@"I can see (.*) Text Items in ListView")]
        public void ThenICanSeeTextItemInListView(int itemCount)
        {
            App.Container.Resolve<HomePageViewModel>().TextList.Count.ShouldBe(itemCount);
        }
    }
}
