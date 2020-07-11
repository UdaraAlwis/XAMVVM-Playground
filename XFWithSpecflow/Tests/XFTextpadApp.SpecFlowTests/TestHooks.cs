using TechTalk.SpecFlow;
using Xamarin.Forms;

namespace XFTextpadApp.SpecFlowTests
{
    [Binding]
    public class TestHooks
    {
        /// <summary>
        /// Instance of the app
        /// </summary>
        public static TestApp App { get; private set; }
        
        [BeforeScenario]
        public void BeforeScenario()
        {
            Xamarin.Forms.Mocks.MockForms.Init();

            App = new TestApp();
        }

        [AfterScenario]
        public async void AfterScenario()
        {
            // After Scenario steps

            // 1. Clear App data in memory
            Application.Current.Properties.Clear();
            await Application.Current.SavePropertiesAsync();

            // ...
        }
    }
}
