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
                    .EnableLocalScreenshots()
                    .StartApp(
                        clearData ?
                            AppDataMode.Clear : AppDataMode.DoNotClear);
            }

            return ConfigureApp.iOS
                // iPhone 6s Plus
                .DeviceIdentifier("F6B5A914-467D-461B-B561-09254F35B665")
                .InstalledApp("com.udara.xfwithuitest")
                .EnableLocalScreenshots()
                .StartApp(
                    clearData ?
                        AppDataMode.Clear : AppDataMode.DoNotClear);
        }
    }
}