using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using XFWithSpecflow.UnitTest;

namespace XFWithSpecflow.UnitTest
{
    [Binding]
    public class SetupHooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        public static TestApp App { get; private set; }
        
        [BeforeScenario]
        public void BeforeScenario()
        {
            Xamarin.Forms.Mocks.MockForms.Init();

            App = new TestApp();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
        }
    }
}
