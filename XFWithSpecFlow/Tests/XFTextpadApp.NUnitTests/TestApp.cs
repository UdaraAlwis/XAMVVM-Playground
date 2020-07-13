using System.Threading.Tasks;
using Prism;
using Prism.Ioc;
using Prism.Navigation;
using Prism.Unity;
using Unity;
using Xamarin.Essentials;
using Xamarin.Forms;
using XFTextpadApp.Services;
using XFTextpadApp.ViewModels;
using XFTextpadApp.Views;

namespace XFTextpadApp.NUnitTests
{
    public class TestApp : PrismApplication
    {
        public TestApp() : this(null) { }

        public TestApp(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            Container.GetContainer().RegisterInstance<INavigationService>(NavigationService, new Unity.Lifetime.SingletonLifetimeManager());

            await NavigationService.NavigateAsync("NavigationPage/HomePage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<HomePage>();
            containerRegistry.RegisterForNavigation<NewTextPage>();
            containerRegistry.RegisterForNavigation<ViewTextPage>();

            containerRegistry.GetContainer().RegisterType<HomePageViewModel>(new Unity.Lifetime.ContainerControlledLifetimeManager());
            containerRegistry.GetContainer().RegisterType<NewTextPageViewModel>(new Unity.Lifetime.ContainerControlledLifetimeManager());
            containerRegistry.GetContainer().RegisterType<ViewTextPageViewModel>(new Unity.Lifetime.ContainerControlledLifetimeManager());

            containerRegistry.RegisterSingleton<ILocationService, MockLocationService>();
        }
    }

    /// <summary>
    /// Mocked Location Service
    /// </summary>
    public class MockLocationService : ILocationService
    {
        public Task<Location> GetLocation()
        {
            // Mock location data
            return Task.FromResult(new Location(0.11111, 0.22222));
        }
    }
}
