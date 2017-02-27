using System.Collections.Generic;
using System.Linq;
using XBreweryDbApp.Features.BreweryList;
using XBreweryDbApp.Features.Favorite;
using XBreweryDbApp.Models;

namespace XBreweryDbApp.Adapters.Features
{
    class MainPageFeatureFacade : IMainPageFeatures
    {
        private readonly FavoriteBreweryManager _favoriteBreweryManager;
        private readonly BreweryListProvider _breweryListProvider;
      

        public MainPageFeatureFacade(FavoriteBreweryManager favoriteBreweryManager,
            BreweryListProvider breweryListProvider)
        {
            _favoriteBreweryManager = favoriteBreweryManager;
            _breweryListProvider = breweryListProvider;
          
        }

        public IEnumerable<BreweryViewModel> GetBreweries()
        {
            return _breweryListProvider.GetBreweries().Select(brewery => new BreweryViewModel()
            {
                Id = brewery.Id,
                Name = brewery.Name,
                IsFavorite = brewery.IsFavorite
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
