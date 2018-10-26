using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;
using Prism.Navigation;
using Unity;
using Xamarin.Forms;
using XFWithUITest.Models;

namespace XFWithUITest.ViewModels
{
    public class NewIdeaPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        
        private bool _isTimerEnabled;

        public Idea Idea { get; set; }

        public DelegateCommand SaveIdeaCommand { get; set; }

        public DateTime StartTime { get; set; }

        public NewIdeaPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            this._navigationService = navigationService;

            Idea = new Idea();

            SaveIdeaCommand = new DelegateCommand(SaveIdea);
        }

        private void SaveIdea()
        {
            if (string.IsNullOrEmpty(Idea.IdeaTitle) || string.IsNullOrEmpty(Idea.IdeaText) ||
                string.IsNullOrWhiteSpace(Idea.IdeaTitle) || string.IsNullOrWhiteSpace(Idea.IdeaText))
                return;

            // Timer ended
            _isTimerEnabled = false;
            
            Idea.IdeaDateTime = DateTime.Now;

            Idea.IdeaTimeSpan = Idea.IdeaDateTime.Subtract(StartTime);

            _navigationService.GoBackAsync(new NavigationParameters()
            {
                { nameof(Idea), Idea }
            });
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            _isTimerEnabled = true;

            StartTime = DateTime.Now;

            // Timer started
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                Idea.IdeaDateTime = DateTime.Now;
                
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
