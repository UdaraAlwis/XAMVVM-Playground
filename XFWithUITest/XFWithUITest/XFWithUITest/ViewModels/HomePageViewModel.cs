using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
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

        public DelegateCommand<Idea> DeleteIdeaCommand { get; set; }

        public HomePageViewModel(INavigationService navigationService)
             : base(navigationService)
        {
            this._navigationService = navigationService;

            NoteList = new ObservableCollection<Idea>();

            NewIdeaCommand = new DelegateCommand(NewIdea);

            DeleteIdeaCommand = new DelegateCommand<Idea>(DeleteIdea);
        }

        private async void DeleteIdea(Idea idea)
        {
            NoteList.Remove(idea);

            await SaveDataToDiskAsync();

            // update UI
            RaisePropertyChanged(nameof(NoteList));
            RaisePropertyChanged(nameof(IsEmptyNoteList));
        }

        private void NewIdea()
        {
            _navigationService.NavigateAsync(nameof(NewIdeaPage));
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.GetNavigationMode() == NavigationMode.Back)
            {
                if (parameters.ContainsKey(nameof(Idea)))
                {
                    NoteList.Add((Idea)parameters[nameof(Idea)]);

                    await SaveDataToDiskAsync();

                    // update UI
                    RaisePropertyChanged(nameof(NoteList));
                    RaisePropertyChanged(nameof(IsEmptyNoteList));
                }
            }
            else if (parameters.GetNavigationMode() == NavigationMode.New)
            {
                if (!Application.Current.Properties.ContainsKey($"{nameof(NoteList)}_STRING"))
                    return;

                var jsonValue = Application.Current.Properties[$"{nameof(NoteList)}_STRING"];
                if (jsonValue != null)
                {
                    NoteList = JsonConvert.DeserializeObject<ObservableCollection<Idea>>(jsonValue.ToString());
                    RaisePropertyChanged(nameof(NoteList));
                    RaisePropertyChanged(nameof(IsEmptyNoteList));
                }
            }
        }

        private async Task SaveDataToDiskAsync()
        {
            // Saving data to storage
            var jsonValueToSave = JsonConvert.SerializeObject(NoteList);
            Application.Current.Properties[$"{nameof(NoteList)}_STRING"] = jsonValueToSave;
            await Application.Current.SavePropertiesAsync();
        }
    }
}
