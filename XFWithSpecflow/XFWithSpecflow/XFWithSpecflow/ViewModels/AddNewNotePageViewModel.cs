using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace XFWithSpecflow.ViewModels
{
    public class AddNewNotePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public AddNewNotePageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            this._navigationService = navigationService;

            Title = "Add New Note";
        }
    }
}
