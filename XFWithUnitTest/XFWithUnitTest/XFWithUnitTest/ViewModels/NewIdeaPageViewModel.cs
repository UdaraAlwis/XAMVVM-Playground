using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;
using Prism.Navigation;
using Unity;
using Xamarin.Forms;
using XFWithUnitTest.Models;

namespace XFWithUnitTest.ViewModels
{
    public class NewTextPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        
        private bool _isTimerEnabled;

        public TextItem TextItem { get; set; }

        public DelegateCommand SaveTextCommand { get; set; }
        
        public NewTextPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            this._navigationService = navigationService;

            TextItem = new TextItem();

            SaveTextCommand = new DelegateCommand(SaveText);
        }

        private void SaveText()
        {
            if (string.IsNullOrEmpty(TextItem.TextTitle) || string.IsNullOrEmpty(TextItem.Text) ||
                string.IsNullOrWhiteSpace(TextItem.TextTitle) || string.IsNullOrWhiteSpace(TextItem.Text))
                return;

            // Timer ended
            _isTimerEnabled = false;
            
            TextItem.TextDateTime = DateTime.Now;
            
            _navigationService.GoBackAsync(new NavigationParameters()
            {
                { nameof(TextItem), TextItem }
            });
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

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
