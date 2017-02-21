using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Forms;
using XBreweryDbApp.Models;

namespace XBreweryDbApp.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private readonly IMainPageFeatures _mainPageFeatures;
        private readonly INavigationService _navigationService;

        #region Properties

        private ObservableCollection<BreweryViewModel> _breweries;

        public ObservableCollection<BreweryViewModel> Breweries
        {
            get { return _breweries; }

            set { SetProperty(ref _breweries, value); }
        }


        private bool _isFavorite;

        public bool IsFavorite
        {
            get { return _isFavorite; }
            set { SetProperty(ref _isFavorite, value); }
        }

        #endregion

        #region Commands

        private DelegateCommand<ItemTappedEventArgs> _goToDetailPage;

        public DelegateCommand<ItemTappedEventArgs> GoToDetailPage
        {
            get { return _goToDetailPage; }
        }

        private ICommand _favoriteCommand;


        #endregion

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
