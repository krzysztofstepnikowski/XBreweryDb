using System.Collections.Generic;
using XBreweryDbApp.Models;

namespace XBreweryDbApp
{
    public interface IMainPageFeatures
    {
        IEnumerable<BreweryViewModel> GetBreweries();
        void SetAsFavorite(string id);
        void RemoveFromFavorites(string id);
     
    }
}