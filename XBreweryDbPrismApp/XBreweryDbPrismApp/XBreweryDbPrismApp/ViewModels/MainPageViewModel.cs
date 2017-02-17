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

namespace XBreweryDbPrismApp.ViewModels
{
    public class MainPageViewModel : BindableBase, INavigationAware
    {
        private readonly IMainPageFeatures _mainPageFeatures;
        private readonly INavigationService _navigationService;

        #region Properties

        private ObservableCollection<Brewery> _breweries;

        public ObservableCollection<Brewery> Breweries
        {
            get { return _breweries; }

            set { SetProperty(ref _breweries, value); }
        }

        private FileImageSource _fileImageSource;

        public FileImageSource FileImageSource
        {
            get { return _fileImageSource.File; }
            set
            {
                var storage = _fileImageSource.File;
                SetProperty(ref storage, value);
            }
        }

        private bool _isFavorite;

        public bool IsFavorite
        {
            get { return _isFavorite; }
            set
            {
                FileImageSource = value ? "ic_favorite_border.png" : "ic_favorite.png";
                SetProperty(ref _isFavorite, value);
            }
        }

        #endregion

        #region Commands

        private DelegateCommand<ItemTappedEventArgs> _goToDetailPage;

        public DelegateCommand<ItemTappedEventArgs> GoToDetailPage
        {
            get { return _goToDetailPage; }
        }

        private ICommand _favoriteCommand;

        public ICommand FavoriteCommand
        {
            get { return _favoriteCommand; }
        }

        #endregion

        public MainPageViewModel(IMainPageFeatures mainPageFeatures, INavigationService navigationService)
        {
            _mainPageFeatures = mainPageFeatures;
            _navigationService = navigationService;
          

            _goToDetailPage = new DelegateCommand<ItemTappedEventArgs>(async selected =>
            {
                NavigationParameters parameters = new NavigationParameters();
                parameters.Add("id", (selected.Item as Brewery).Id);
                await _navigationService.NavigateAsync("DetailPage", parameters);
            });

            _favoriteCommand = new DelegateCommand<Brewery>(brewery =>
            {
                IsFavorite = !IsFavorite;

                var id = brewery.Id;


                if (IsFavorite)
                {
                    _mainPageFeatures.SetAsFavorite(id);
                  
                }

                else
                {
                    _mainPageFeatures.RemoveFromFavorites(id);
                }

                CheckIsFavoriteButtonChanged();
            });

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

        public void OnNavigatingTo(NavigationParameters parameters)
        {
        }

        private void CheckIsFavoriteButtonChanged()
        {
            IsFavorite = Breweries.GetEnumerator().Current.IsFavorite;
        }
    }
}
