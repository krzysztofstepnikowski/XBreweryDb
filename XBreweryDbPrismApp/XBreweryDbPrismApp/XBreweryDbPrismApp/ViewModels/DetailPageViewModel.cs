using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Xamarin.Forms;
using XBreweryDbPrismApp.Features.Details;
using XBreweryDbPrismApp.Views.Details;

namespace XBreweryDbPrismApp.ViewModels
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

        private string _favoriteButtonText;

        public string FavoriteButtonText
        {
            get { return _favoriteButtonText; }
            set { SetProperty(ref _favoriteButtonText, value); }
        }

        private Color _favoriteButtonBackgroundColor;

        public Color FavoriteButtonBackgroundColor
        {
            get { return _favoriteButtonBackgroundColor; }
            set { SetProperty(ref _favoriteButtonBackgroundColor, value); }
        }

        private bool _isFavorite;

        public bool IsFavorite
        {
            get { return _isFavorite; }

            set
            {
                FavoriteButtonText = value ? "Delete from favorites" : "Add to favorites";
                FavoriteButtonBackgroundColor = value ? Color.Green : Color.Red;
                SetProperty(ref _isFavorite, value);
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
            Id = (string) parameters["id"];
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