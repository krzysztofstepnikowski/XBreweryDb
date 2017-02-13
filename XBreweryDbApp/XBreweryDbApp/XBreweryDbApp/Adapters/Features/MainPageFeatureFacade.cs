using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using XBreweryDbApp.Features.BreweryList;
using XBreweryDbApp.Features.Favorite;
using XBreweryDbApp.Views.Details;

namespace XBreweryDbApp.Adapters.Features
{
    class MainPageFeatureFacade : IMainPageFeatures
    {
        private readonly FavoriteBreweryManager _favoriteBreweryManager;
        private readonly BreweryListProvider _breweryListProvider;
        private readonly IDetailPageFeatures _detailPageFeatures;

        public MainPageFeatureFacade(FavoriteBreweryManager favoriteBreweryManager,
            BreweryListProvider breweryListProvider,
            IDetailPageFeatures detailPageFeatures)
        {
            _favoriteBreweryManager = favoriteBreweryManager;
            _breweryListProvider = breweryListProvider;
            _detailPageFeatures = detailPageFeatures;
        }

        public IEnumerable<Brewery> GetBreweries()
        {
            return _breweryListProvider.GetBreweries();
        }

        public void SetAsFavorite(string id)
        {
            _favoriteBreweryManager.SetAsFavorite(id);
        }

        public void RemoveFromFavorites(string id)
        {
            _favoriteBreweryManager.RemoveFromFavorites(id);
        }

        public async Task ShowBreweryDetailsAsync(string id, INavigation navigation)
        {
            await navigation.PushAsync(new DetailPage(id, _detailPageFeatures));
        }
    }
}
