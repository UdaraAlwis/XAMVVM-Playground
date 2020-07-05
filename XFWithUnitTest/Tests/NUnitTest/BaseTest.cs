using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Xamarin.Forms;
using XFWithUnitTest.ViewModels;

namespace NUnitTest
{
    // <summary>
    // Base class for Test classes
    // </summary>
    public class BaseTest
    {
        // <summary>
        // Instance of the app
        // </summary>
        public static TestApp App { get; private set; }

        [SetUp]
        public void Setup()
        {
            Xamarin.Forms.Mocks.MockForms.Init();

            App = new TestApp();
        }

        /// <summary>
        /// Returns the ViewModel of
        /// the current active Page
        /// in Navigation Stack
        /// </summary>
        /// <returns></returns>
        public Page GetCurrentPage()
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


        }
    }
}
