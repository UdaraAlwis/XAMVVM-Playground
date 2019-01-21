using System.Linq;
using NUnit.Framework;
using NUnitTest;
using Prism.Ioc;
using Xamarin.Forms;
using XFWithUnitTest.ViewModels;

namespace Tests
{
    public class SetupHooks
    {
        public static TestApp App { get; private set; }

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
    }
}