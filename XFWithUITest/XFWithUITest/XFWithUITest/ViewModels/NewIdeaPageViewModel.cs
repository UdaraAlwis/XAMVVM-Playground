using System;
using System.Collections.Generic;
using System.Text;
using Prism.Navigation;

namespace XFWithUITest.ViewModels
{
    public class NewIdeaPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public NewIdeaPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            this._navigationService = navigationService;
        }
    }
}
