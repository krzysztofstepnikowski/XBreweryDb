using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using XBreweryDbPrismApp.Features.Details;

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
            set
            {
                SetProperty(ref _id, value); 
               
            }
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
            set
            {
                SetProperty(ref _favoriteButtonText, value); 
                //CheckIsFavoriteButtonChanged();
            }
        }

        private bool _isFavorite;

        public bool IsFavorite
        {
            get { return _isFavorite; }

            set
            {
                FavoriteButtonText = value ? "Delete from favorites" : "Add to favorites";
                SetProperty(ref _isFavorite, value);
            }
        }

        #endregion

        private ICommand _favoriteCommand;

        public ICommand FavoriteCommand
        {
            get
            {
                if (_favoriteCommand == null)
                {
                    _favoriteCommand = new DelegateCommand(() =>
                    {
                        _isFavorite = !_isFavorite;

                       

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

                return _favoriteCommand;
            }
        }

        public DetailPageViewModel(IDetailPageFeatures detailPageFeatures)
        {
            _detailPageFeatures = detailPageFeatures;
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