using NUnit.Framework;
using Xamarin.Forms;

namespace NUnitTest
{
    public class BaseTest
    {
        /// <summary>
        /// Instance of the app
        /// </summary>
        public static TestApp App { get; private set; }

        /// <summary>
        /// Setting up the test
        /// env before execution
        /// </summary>
        [SetUp]
        public void Setup()
        {
            Xamarin.Forms.Mocks.MockForms.Init();

            App = new TestApp();
        }

        [Test]
        public void IsAppRunning()
        {
            Assert.NotNull(App);
        }

        /// <summary>
        /// Clear the app data
        /// </summary>
        public async void ClearData()
        {
            Xamarin.Forms.Mocks.MockForms.Init();

            Application.Current.Properties.Clear();
            await Application.Current.SavePropertiesAsync();

            App = new TestApp();
        }
    }
}
