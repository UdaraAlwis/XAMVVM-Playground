using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;
using Prism.Navigation;
using Unity;
using Xamarin.Forms;
using XFWithUnitTest.Models;
using XFWithUnitTest.Services;

namespace XFWithUnitTest.ViewModels
{
    public class NewTextPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly ILocationService _locationService;

        private bool _isTimerEnabled;

        public TextItem TextItem { get; set; }

        public DelegateCommand SaveTextCommand { get; set; }
        
        public NewTextPageViewModel(INavigationService navigationService, ILocationService locationService) : base(navigationService)
        {
            this._navigationService = navigationService;
            this._locationService = locationService;

            TextItem = new TextItem();

            SaveTextCommand = new DelegateCommand(async () => await SaveText());
        }

        private async Task SaveText()
        {
            if (string.IsNullOrEmpty(TextItem.TextTitle) || string.IsNullOrEmpty(TextItem.Text) ||
                string.IsNullOrWhiteSpace(TextItem.TextTitle) || string.IsNullOrWhiteSpace(TextItem.Text))
                return;

            TextItem.TextDateTime = DateTime.Now;
            var location = await _locationService.GetLocation();
            if (location != null)
                TextItem.LocationLatLong = $"Lat: {location.Latitude.ToString("###.0000")}, Long: {location.Longitude.ToString("###.0000")}";

            await _navigationService.GoBackAsync(new NavigationParameters()
            {
                { nameof(TextItem), TextItem }
            });
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            // Get Location
            var location = await _locationService.GetLocation();
            if (location != null)
                TextItem.LocationLatLong = $"Lat: {location.Latitude.ToString("###.0000")}, Long: {location.Longitude.ToString("###.0000")}";
        
            // Get Timer display
            _isTimerEnabled = true;
            // Timer started
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                TextItem.TextDateTime = DateTime.Now;

                if (_isTimerEnabled)
                    return true;
                else
                {
                    return false;
                }
            });
        }

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);

            _isTimerEnabled = false;
        }
    }
}
