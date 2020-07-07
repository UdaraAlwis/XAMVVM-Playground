﻿using System;
using Prism;
using Prism.Ioc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFWithUnitTest.Services;
using XFWithUnitTest.ViewModels;
using XFWithUnitTest.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XFWithUnitTest
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/HomePage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
            containerRegistry.RegisterForNavigation<NewTextPage, NewTextPageViewModel>();
            containerRegistry.RegisterForNavigation<ViewTextPage, ViewTextPageViewModel>();

            containerRegistry.RegisterSingleton<ILocationService, LocationService>();
        }
    }
}
