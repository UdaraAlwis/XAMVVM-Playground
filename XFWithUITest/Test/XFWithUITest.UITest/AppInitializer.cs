using System;
using Xamarin.UITest;
using Xamarin.UITest.Configuration;
using Xamarin.UITest.Queries;

namespace XFWithUITest.UITest
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform, bool clearData)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp.Android
                    .InstalledApp("com.udara.xfwithuitest")
                    .StartApp(
                        clearData ? 
                        AppDataMode.Clear : AppDataMode.DoNotClear);
            }

            return ConfigureApp.iOS
                    .InstalledApp("com.udara.xfwithuitest")
                    .StartApp(
                    clearData ?
                        AppDataMode.Clear : AppDataMode.DoNotClear);
        }
    }
}