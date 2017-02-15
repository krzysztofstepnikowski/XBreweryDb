using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using XBreweryDbPrismApp.Features.Main;
using XBreweryDbPrismApp.Models;

namespace XBreweryDbPrismApp.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private readonly IMainPageFeatures _mainPageFeatures;
        private readonly INavigationService _navigationService;


        private ObservableCollection<Brewery> _breweries;

        public ObservableCollection<Brewery> Breweries
        {
            get { return _breweries; }

            set { SetProperty(ref _breweries, value); }
        }

        private ICommand _navigateCommand;

        public ICommand NavigateCommand => _navigateCommand ?? (_navigateCommand = new DelegateCommand(Navigate));


        public MainPageViewModel(IMainPageFeatures mainPageFeatures, INavigationService navigationService)
        {
            _mainPageFeatures = mainPageFeatures;
            _navigationService = navigationService;
            OnResume();
        }


        public void OnResume()
        {
            try
            {
                Breweries = new ObservableCollection<Brewery>();

                var breweries = _mainPageFeatures.GetBreweries();

                foreach (var brewery in breweries)
                {
                    Breweries.Add(new Brewery() {Id = brewery.Id, IsFavorite = brewery.IsFavorite, Name = brewery.Name});
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public void Navigate()
        {
            var navigationParameter = new NavigationParameters {{"id", _mainPageFeatures.GetBreweries().GetEnumerator().Current.Id}};
            _navigationService.NavigateAsync("DetailPage", navigationParameter);
        }
    }
}
