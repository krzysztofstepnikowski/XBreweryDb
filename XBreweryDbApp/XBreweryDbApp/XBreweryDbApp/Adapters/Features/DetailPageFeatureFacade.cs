using XBreweryDbApp.Features.BreweryDescription;
using XBreweryDbApp.Features.Favorite;
using XBreweryDbApp.Views.Details;

namespace XBreweryDbApp.Adapters.Features
{
    public class DetailPageFeatureFacade : IDetailPageFeatures
    {
        private readonly BreweryDescriptionProvider _breweryDescriptionProvider;
        private readonly FavoriteBreweryManager _favoriteBreweryManager;

        public DetailPageFeatureFacade(BreweryDescriptionProvider breweryDescriptionProvider, FavoriteBreweryManager favoriteBreweryManager)
        {
            _breweryDescriptionProvider = breweryDescriptionProvider;
            _favoriteBreweryManager = favoriteBreweryManager;
        }

        public string GetBreweryDescription(string breweryId)
        {
            return _breweryDescriptionProvider.GetBreweryDescription(breweryId);
        }

        public bool IsBreweryFavorite(string breweryId)
        {
            return _favoriteBreweryManager.IsFavorite(breweryId);
        }

        public void RemoveFromFavorites(string breweryId)
        {
            _favoriteBreweryManager.RemoveFromFavorites(breweryId);
        }

        public void SetAsFavorite(string breweryId)
        {
            _favoriteBreweryManager.SetAsFavorite(breweryId);
        }
    }
}
