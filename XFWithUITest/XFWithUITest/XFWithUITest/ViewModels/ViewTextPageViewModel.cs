using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;
using XFWithUITest.Models;

namespace XFWithUITest.ViewModels
{
    public class ViewTextPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
       
        public TextItem TextItem { get; set; }

        public DelegateCommand DoneCommand { get; set; }

        public ViewTextPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;

            DoneCommand = new DelegateCommand(Done);
        }

        private void Done()
        {
            _navigationService.GoBackAsync();
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            if (parameters.ContainsKey(nameof(TextItem)))
            {
                TextItem = (TextItem)parameters[nameof(Models.TextItem)];

                RaisePropertyChanged(nameof(TextItem));
            }
        }
    }
}
