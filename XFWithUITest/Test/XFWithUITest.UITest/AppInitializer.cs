using System;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace XFWithUITest.UITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android
                    .InstalledApp("com.udara.xfwithuitest")
                    .StartApp();
            }

            return ConfigureApp.iOS.StartApp();
        }
    }
}