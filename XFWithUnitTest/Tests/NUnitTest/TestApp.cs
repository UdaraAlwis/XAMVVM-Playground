using Prism;
using Prism.Ioc;
using Prism.Navigation;
using Prism.Unity;
using Unity;
using Xamarin.Forms;
using XFWithUnitTest.ViewModels;
using XFWithUnitTest.Views;

namespace NUnitTest
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
        }
    }
}
