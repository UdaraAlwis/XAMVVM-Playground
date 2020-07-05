﻿using NUnit.Framework;
using Xamarin.Forms;

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
        /// Clear the app data
        /// </summary>
        public async void ClearData()
        {
            //Application.Current.Properties.Clear();
            //await Application.Current.SavePropertiesAsync();

            //TestHooks.Setup();
            //App = TestHooks.App;
        }
    }
}
