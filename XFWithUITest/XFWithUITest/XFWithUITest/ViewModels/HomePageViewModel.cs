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

        public ObservableCollection<TextItem> TextList { get; set; }

        public bool IsEmptyTextList => TextList == null || TextList.Count == 0;

        public DelegateCommand NewTextCommand { get; set; }

        public DelegateCommand<TextItem> DeleteTextCommand { get; set; }

        public HomePageViewModel(INavigationService navigationService)
             : base(navigationService)
        {
            this._navigationService = navigationService;

            TextList = new ObservableCollection<TextItem>();

            NewTextCommand = new DelegateCommand(NewText);

            DeleteTextCommand = new DelegateCommand<TextItem>(DeleteText);
        }

        private async void DeleteText(TextItem textItem)
        {
            TextList.Remove(textItem);

            await SaveDataToDiskAsync();

            // update UI
            RaisePropertyChanged(nameof(TextList));
            RaisePropertyChanged(nameof(IsEmptyTextList));
        }

        private void NewText()
        {
            _navigationService.NavigateAsync(nameof(NewTextPage));
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.GetNavigationMode() == NavigationMode.Back)
            {
                if (parameters.ContainsKey(nameof(TextItem)))
                {
                    TextList.Add((TextItem)parameters[nameof(TextItem)]);

                    await SaveDataToDiskAsync();

                    // update UI
                    RaisePropertyChanged(nameof(TextList));
                    RaisePropertyChanged(nameof(IsEmptyTextList));
                }
            }
            else if (parameters.GetNavigationMode() == NavigationMode.New)
            {
                if (!Application.Current.Properties.ContainsKey($"{nameof(TextList)}_STRING"))
                    return;

                var jsonValue = Application.Current.Properties[$"{nameof(TextList)}_STRING"];
                if (jsonValue != null)
                {
                    TextList = JsonConvert.DeserializeObject<ObservableCollection<TextItem>>(jsonValue.ToString());
                    RaisePropertyChanged(nameof(TextList));
                    RaisePropertyChanged(nameof(IsEmptyTextList));
                }
            }
        }

        private async Task SaveDataToDiskAsync()
        {
            // Saving data to storage
            var jsonValueToSave = JsonConvert.SerializeObject(TextList);
            Application.Current.Properties[$"{nameof(TextList)}_STRING"] = jsonValueToSave;
            await Application.Current.SavePropertiesAsync();
        }
    }
}
