using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;
using XFWithSpecflow.UnitTest;

namespace XFWithSpecflow
{
    [Binding]
    public class SetupHooks
    {
        public static TestApp App { get; private set; }

        /// <summary>
        ///     The before scenario.
        /// </summary>
        [BeforeScenario]
        public void BeforeScenario()
        {
            Xamarin.Forms.Mocks.MockForms.Init();

            App = new TestApp();
        }
    }
}
