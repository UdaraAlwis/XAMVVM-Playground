using NUnit.Framework;

namespace NUnitTest
{
    /// <summary>
    /// Contains Test Hooks that are
    /// helpful for the test environment
    /// </summary>
    public class TestHooks
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