using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;
using XBreweryDbPrismApp.Features.Main;
using XBreweryDbPrismApp.Models;
using XBreweryDbPrismApp.Views;

namespace XBreweryDbPrismApp.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private readonly IMainPageFeatures _mainPageFeatures;
        private readonly INavigationService _navigationService;


        private ObservableCollection<Brewery> _breweries;

        public ObservableCollection<Brewery> Breweries
        {
            get { return _breweries; }

            set { SetProperty(ref _breweries, value); }
        }

        private DelegateCommand<ItemTappedEventArgs> _goToDetailPage;

        public DelegateCommand<ItemTappedEventArgs> GoToDetailPage
        {
            get
            {
                if (_goToDetailPage == null)
                {
                    _goToDetailPage = new DelegateCommand<ItemTappedEventArgs>(async selected =>
                    {
                        NavigationParameters parameters = new NavigationParameters();
                        //parameters.Add("id",(selected.Item as Brewery).Id);
                        await _navigationService.NavigateAsync("DetailPage",null);
                    });
                }

                return _goToDetailPage;
            }
        }


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

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            
        }
    }
}
