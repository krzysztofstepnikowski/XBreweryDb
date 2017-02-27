using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;
using XBreweryDbApp.Models;

namespace XBreweryDbApp.ViewModels
{
    public partial class MainPageViewModel : BindableBase, INavigationAware
    {
        private readonly IMainPageFeatures _mainPageFeatures;
        private readonly INavigationService _navigationService;

      
        public MainPageViewModel(IMainPageFeatures mainPageFeatures, INavigationService navigationService)
        {
            _mainPageFeatures = mainPageFeatures;
            _navigationService = navigationService;


            _goToDetailPage = new DelegateCommand<ItemTappedEventArgs>(async selected =>
            {
                NavigationParameters parameters = new NavigationParameters();
                parameters.Add("id", (selected.Item as BreweryViewModel).Id);
                await _navigationService.NavigateAsync("DetailPage", parameters);
            });

            _favoriteCommand = new DelegateCommand<BreweryViewModel>(brewery =>
            {
                brewery.IsFavorite = !brewery.IsFavorite;


                var id = brewery.Id;


                if (brewery.IsFavorite)
                {
                    _mainPageFeatures.SetAsFavorite(id);
                }

                else
                {
                    _mainPageFeatures.RemoveFromFavorites(id);
                }
            });

            OnResume();
        }


        public void OnResume()
        {
            try
            {

                var breweries = _mainPageFeatures.GetBreweries();

                foreach (var item in breweries)
                {
                    item.FavoriteCommand = _favoriteCommand;
                }

                Breweries = new ObservableCollection<BreweryViewModel>(breweries);
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

        public void OnNavigatingTo(NavigationParameters parameters)
        {
        }
    }
}
