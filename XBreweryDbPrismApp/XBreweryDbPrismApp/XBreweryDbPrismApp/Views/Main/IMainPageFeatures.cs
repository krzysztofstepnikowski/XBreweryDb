using System.Collections.Generic;
using XBreweryDbPrismApp.Models;

namespace XBreweryDbPrismApp.Views.Main
{
    public interface IMainPageFeatures
    {
        IEnumerable<BreweryViewModel> GetBreweries();
        void SetAsFavorite(string id);
        void RemoveFromFavorites(string id);

    }
}