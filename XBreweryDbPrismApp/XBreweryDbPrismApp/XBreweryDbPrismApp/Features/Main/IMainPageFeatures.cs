using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using XBreweryDbPrismApp.Models;

namespace XBreweryDbPrismApp.Features.Main
{
    public interface IMainPageFeatures
    {
        IEnumerable<BreweryViewModel> GetBreweries();
        void SetAsFavorite(string id);
        void RemoveFromFavorites(string id);

    }
}