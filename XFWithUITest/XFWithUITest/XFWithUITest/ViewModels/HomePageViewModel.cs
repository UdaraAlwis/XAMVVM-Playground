using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using XFWithUITest.Models;

namespace XFWithUITest.ViewModels
{
	public class HomePageViewModel : ViewModelBase
    {
        public ObservableCollection<Note> NoteList { get; set; }

        public DelegateCommand AddNewCommand { get; set; }

        public HomePageViewModel(INavigationService navigationService)
             : base(navigationService)
        {
            Title = "Main Page";

            AddNewCommand = new DelegateCommand(AddNew);

            Random rand = new Random();

            NoteList = new ObservableCollection<Note>()
            {
                new Note{ NoteTitle = "Title 1", NoteString = "This is a test note 1!", NoteDateTime = DateTime.Now.AddMinutes(rand.Next(5,20)) },
                new Note{ NoteTitle = "Title 2", NoteString = "This is a test note 2!", NoteDateTime = DateTime.Now.AddMinutes(rand.Next(5,20)) },
                new Note{ NoteTitle = "Title 3", NoteString = "This is a test note 3!", NoteDateTime = DateTime.Now.AddMinutes(rand.Next(5,20)) },
                new Note{ NoteTitle = "Title 4", NoteString = "This is a test note 4!", NoteDateTime = DateTime.Now.AddMinutes(rand.Next(5,20)) },
                new Note{ NoteTitle = "Title 5", NoteString = "This is a test note 5!", NoteDateTime = DateTime.Now.AddMinutes(rand.Next(5,20)) },
            };
        }

        private void AddNew()
        {

        }
    }
}
