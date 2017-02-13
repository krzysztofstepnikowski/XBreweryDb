using System.Collections.Generic;

namespace XBreweryDbApp.Features.Favorite
{
    class FavoriteBreweryManager
    {
        private HashSet<string> _favoriteBrewerage = new HashSet<string>();

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
