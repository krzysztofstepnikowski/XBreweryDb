using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XBreweryDbPrismApp.Features.Features.Favorite
{
    public class FavoriteBreweryManager
    {
        private HashSet<string> _favoriteBrewerage;

        public FavoriteBreweryManager(HashSet<string> favoriteBrewerage)
        {
            _favoriteBrewerage = favoriteBrewerage;
        }

        public void SetAsFavorite(string id)
        {
            _favoriteBrewerage.Add(id);
        }

        public void RemoveFromFavorites(string id)
        {
            _favoriteBrewerage.Remove(id);
        }

        public bool IsFavorite(string id)
        {
            return _favoriteBrewerage.Contains(id);
        }
    }
}
