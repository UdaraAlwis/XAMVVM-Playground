using NUnit.Framework;

namespace NUnitTest
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