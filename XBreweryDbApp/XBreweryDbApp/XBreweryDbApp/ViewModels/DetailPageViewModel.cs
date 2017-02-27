using Prism.Mvvm;
using Prism.Navigation;
using Prism.Commands;
using XBreweryDbApp.Views.Details;
using Xamarin.Forms;
using System.Windows.Input;

namespace XBreweryDbApp.ViewModels
{
    public partial class DetailPageViewModel : BindableBase, INavigationAware
    {
        private readonly IDetailPageFeatures _detailPageFeatures;


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
