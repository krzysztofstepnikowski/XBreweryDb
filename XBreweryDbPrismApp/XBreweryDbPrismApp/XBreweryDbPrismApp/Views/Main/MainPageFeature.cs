using System.Collections.Generic;
using System.Linq;
using XBreweryDbPrismApp.Features.BreweryList;
using XBreweryDbPrismApp.Features.Favorite;
using XBreweryDbPrismApp.Models;
using XBreweryDbPrismApp.Views.Main;

namespace XBreweryDbPrismApp.Features.Main
{
    public class MainPageFeature : IMainPageFeatures
    {
        private readonly FavoriteBreweryManager _favoriteBreweryManager;
        private readonly BreweryListProvider _breweryListProvider;


        public MainPageFeature(FavoriteBreweryManager favoriteBreweryManager, BreweryListProvider breweryListProvider)
        {
            _favoriteBreweryManager = favoriteBreweryManager;
            _breweryListProvider = breweryListProvider;
        }

        public IEnumerable<BreweryViewModel> GetBreweries()
        {
            return _breweryListProvider.GetBreweries().Select(brewery => new BreweryViewModel()
            {
                Id=brewery.Id,
                Name=brewery.Name,
                IsFavorite=brewery.IsFavorite
            }
            ).ToList();
        }

        public void SetAsFavorite(string id)
        {
            _favoriteBreweryManager.SetAsFavorite(id);
        }

        public void RemoveFromFavorites(string id)
        {
            _favoriteBreweryManager.RemoveFromFavorites(id);
        }
    }
}
