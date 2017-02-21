using Prism.Mvvm;
using Prism.Navigation;
using Prism.Commands;
using XBreweryDbApp.Views.Details;
using Xamarin.Forms;
using System.Windows.Input;

namespace XBreweryDbApp.ViewModels
{
    public class DetailPageViewModel : BindableBase, INavigationAware
    {
        private readonly IDetailPageFeatures _detailPageFeatures;

        #region Properties

        private string _id;

        public string Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _description;

        public string Description
        {
            get { return _description; }

            set { SetProperty(ref _description, value); }
        }



        public string FavoriteButtonText => IsFavorite ? "Delete from favorites" : "Add to favorites";

        public Color FavoriteButtonBackgroundColor => IsFavorite ? Color.Green : Color.Red;


        private bool _isFavorite;

        public bool IsFavorite
        {
            get { return _isFavorite; }

            set
            {
                SetProperty(ref _isFavorite, value);
                OnPropertyChanged(() => FavoriteButtonText);
                OnPropertyChanged(() => FavoriteButtonBackgroundColor);
            }
        }

        #endregion

        private ICommand _favoriteCommand;

        public ICommand FavoriteCommand
        {
            get { return _favoriteCommand; }
        }

        public DetailPageViewModel(IDetailPageFeatures detailPageFeatures)
        {
            _detailPageFeatures = detailPageFeatures;

            _favoriteCommand = new DelegateCommand(() =>
            {
                IsFavorite = !IsFavorite;


                if (IsFavorite)
                {
                    _detailPageFeatures.SetAsFavorite(Id);
                }

                else
                {
                    _detailPageFeatures.RemoveFromFavorites(Id);
                }

                CheckIsFavoriteButtonChanged();
            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            Id = (string)parameters["id"];
            Description = _detailPageFeatures.GetBreweryDescription(Id);
            IsFavorite = _detailPageFeatures.IsBreweryFavorite(Id);
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
        }

        private void CheckIsFavoriteButtonChanged()
        {
            IsFavorite = _detailPageFeatures.IsBreweryFavorite(Id);
        }
    }
}
