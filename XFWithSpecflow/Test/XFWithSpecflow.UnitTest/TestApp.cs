using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism;
using Prism.Ioc;
using Prism.Navigation;
using Prism.Unity;
using Unity;
using Xamarin.Forms;
using XFWithSpecflow.ViewModels;
using XFWithSpecflow.Views;

namespace XFWithSpecflow.UnitTest
{

    /// <summary>
    /// Initializing test environment for the app
    /// </summary>
    public partial class TestApp : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public TestApp() : this(null) { }

        public TestApp(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            Xamarin.Forms.Mocks.MockForms.Init();
         
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
