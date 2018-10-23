using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;
using Prism.Navigation;

namespace XFWithUITest.ViewModels
{
    public class NewIdeaPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public DelegateCommand SaveIdeaCommand { get; set; }

        public NewIdeaPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            this._navigationService = navigationService;

            SaveIdeaCommand = new DelegateCommand(SaveIdea);
        }

        private void SaveIdea()
        {
            // Timer ended
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            // Timer started
        }
    }
}
