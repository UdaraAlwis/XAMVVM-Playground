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

        public DelegateCommand NewIdeaCommand { get; set; }

        public HomePageViewModel(INavigationService navigationService)
             : base(navigationService)
        {
            _navigationService = navigationService;
            Title = "Main Page";

            NewIdeaCommand = new DelegateCommand(NewIdea);

            Random rand = new Random();

            NoteList = new ObservableCollection<Idea>()
            {
                new Idea{ IdeaTitle = "Marketing situation of nottingham", IdeaText = "Local burned alive to the crisp out of nowhere Barnie the golden smith", NoteDateTime = DateTime.Now.AddMinutes(rand.Next(5,20)) },
                new Idea{ IdeaTitle = "Title 2", IdeaText = "Toast box in the tree build on top of the martin solving binge", NoteDateTime = DateTime.Now.AddMinutes(rand.Next(5,20)) },
                new Idea{ IdeaTitle = "Title 3", IdeaText = "This is a test note 3!", NoteDateTime = DateTime.Now.AddMinutes(rand.Next(5,20)) },
                new Idea{ IdeaTitle = "Title 4", IdeaText = "This is a test note 4!", NoteDateTime = DateTime.Now.AddMinutes(rand.Next(5,20)) },
                new Idea{ IdeaTitle = "Title 5", IdeaText = "This is a test note 5!", NoteDateTime = DateTime.Now.AddMinutes(rand.Next(5,20)) },
            };
        }

        private void NewIdea()
        {
            _navigationService.NavigateAsync(nameof(NewIdeaPage));
        }
    }
}
