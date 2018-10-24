using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using XFWithUITest.Models;
using XFWithUITest.Views;

namespace XFWithUITest.ViewModels
{
	public class HomePageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public ObservableCollection<Idea> NoteList { get; set; }

        public bool IsEmptyNoteList => NoteList == null || NoteList.Count == 0;

        public DelegateCommand NewIdeaCommand { get; set; }

        public HomePageViewModel(INavigationService navigationService)
             : base(navigationService)
        {
            this._navigationService = navigationService;

            NoteList = new ObservableCollection<Idea>();

            NewIdeaCommand = new DelegateCommand(NewIdea);
        }

        private void NewIdea()
        {
            _navigationService.NavigateAsync(nameof(NewIdeaPage));
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.GetNavigationMode() == NavigationMode.Back)
            {
                if (parameters.ContainsKey(nameof(Idea)))
                {
                   NoteList.Add((Idea)parameters[nameof(Idea)]);

                    RaisePropertyChanged(nameof(NoteList));
                    RaisePropertyChanged(nameof(IsEmptyNoteList));
                }
            }
        }
    }
}
