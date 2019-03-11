using NUnit.Framework;

namespace NUnitTest
{
    public class TestHooks
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