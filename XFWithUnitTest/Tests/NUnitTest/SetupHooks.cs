using NUnit.Framework;
using NUnitTest;

namespace Tests
{
    public static class SetupHooks
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