using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBreweryDbPrismApp.Features.Features.BreweryDescription;
using XBreweryDbPrismApp.Features.Features.Favorite;

namespace XBreweryDbPrismApp.Features.Details
{
    public class DetailPageFeature : IDetailPageFeatures
    {
        private readonly BreweryDescriptionProvider _breweryDescriptionProvider;
        private readonly FavoriteBreweryManager _favoriteBreweryManager;

        public DetailPageFeature(BreweryDescriptionProvider breweryDescriptionProvider, FavoriteBreweryManager favoriteBreweryManager)
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
