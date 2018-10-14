using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using XFWithSpecflow.Views;

namespace XFWithSpecflow.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public ObservableCollection<string> ThoughtsList { get; set; }

        public DelegateCommand AddNewNoteCommand { get; set; }

        public HomePageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            this._navigationService = navigationService;

            Title = "Note Taking App";

            ThoughtsList = new ObservableCollection<string>() { };

            AddNewNoteCommand = new DelegateCommand(AddNewNote);
        }

        private void AddNewNote()
        {
            _navigationService.NavigateAsync(nameof(AddNewNotePage));
        }
    }
}
