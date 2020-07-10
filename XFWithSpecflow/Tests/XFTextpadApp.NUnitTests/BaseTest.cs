using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Xamarin.Forms;

namespace XFTextpadApp.NUnitTests
{
    /// <summary>
    /// Base class for Test classes
    /// </summary>
    public class BaseTest
    {
        /// <summary>
        /// Instance of the app
        /// </summary>
        public static TestApp App { get; private set; }

        [SetUp]
        public void Setup()
        {
            TestHooks.Setup();

            App = TestHooks.App;
        }

        /// <summary>
        /// Returns the active Page
        /// in the Navigation Stack
        /// </summary>
        /// <returns></returns>
        public static Page GetCurrentPage()
        {
            var navigationStack = ((NavigationPage)App.MainPage).Navigation.NavigationStack;
            return (Page)navigationStack.Last();
        }

        [TearDown]
        public async Task TearDown()
        {
            // Teardown steps

            // 1. Clear App data in memory
            Application.Current.Properties.Clear();
            await Application.Current.SavePropertiesAsync();

            // ...
        }
    }
}
