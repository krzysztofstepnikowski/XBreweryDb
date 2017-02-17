using System.Collections.Generic;
using System.Linq;
using XBreweryDbPrismApp.Models;

namespace XBreweryDbPrismApp.Features.Features.BreweryList
{
    public class BreweryListProvider
    {
        private HashSet<string> _favorites;

        public IEnumerable<Brewery> GetBreweries()
        {
            return Enumerable.Range(0, 20)
                .Select(i => new Brewery
                {
                    Id = i.ToString(),
                    IsFavorite = _favorites.Contains(i.ToString()),
                    Name = "Brewery " + i,
                    FileImageSource = "ic_favorite.png"
                })
                .ToList();
        }

        public BreweryListProvider(HashSet<string> favorites)
        {
            _favorites = favorites;
        }
    }
}
