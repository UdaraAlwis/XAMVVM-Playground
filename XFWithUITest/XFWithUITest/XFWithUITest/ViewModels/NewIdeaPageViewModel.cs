using System;
using System.Collections.Generic;
using System.Text;
using Prism.Commands;
using Prism.Navigation;
using Unity;
using XFWithUITest.Models;

namespace XFWithUITest.ViewModels
{
    public class NewIdeaPageViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        private IUnityContainer _unityContainer;

        public Idea Idea { get; set; }

        public DelegateCommand SaveIdeaCommand { get; set; }

        public NewIdeaPageViewModel(INavigationService navigationService, IUnityContainer unityContainer) : base(navigationService)
        {
            this._navigationService = navigationService;
            this._unityContainer = unityContainer;

            Idea = new Idea();

            SaveIdeaCommand = new DelegateCommand(SaveIdea);
        }

        private void SaveIdea()
        {
            // Timer ended

            Idea.NoteDateTime = DateTime.Now;
            
            _navigationService.GoBackAsync(new NavigationParameters()
            {
                { nameof(Idea), Idea }
            });
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            // Timer started
        }
    }
}
