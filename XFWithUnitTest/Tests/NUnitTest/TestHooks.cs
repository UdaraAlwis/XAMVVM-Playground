using System.Linq;
using NUnit.Framework;
using Xamarin.Forms;

namespace NUnitTest
{
    /// <summary>
    /// Contains Test Hooks that are
    /// helpful for the test environment
    /// </summary>
    public static class TestHooks
    {
        public static TestApp App { get; private set; }

        [SetUp]
        public static void Setup()
        {
            Xamarin.Forms.Mocks.MockForms.Init();

            App = new TestApp();
        }

        [Test]
        public static void IsAppRunning()
        {
            Assert.NotNull(App);
        }
    }
}