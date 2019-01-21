using NUnit.Framework;

namespace NUnitTest
{
    public class BastTest
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
