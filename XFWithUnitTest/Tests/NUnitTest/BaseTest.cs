using NUnit.Framework;

namespace NUnitTest
{
    public class BaseTest
    {
        public static TestApp App { get; private set; }

        [SetUp]
        public void Setup()
        {
            Xamarin.Forms.Mocks.MockForms.Init();

            App = new TestApp();
        }
    }
}
