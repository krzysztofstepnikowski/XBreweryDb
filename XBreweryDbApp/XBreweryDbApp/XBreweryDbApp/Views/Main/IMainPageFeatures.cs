using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XBreweryDbApp
{
    public interface IMainPageFeatures
    {
        IEnumerable<Brewery> GetBreweries();
        void SetAsFavorite(string id);
        void RemoveFromFavorites(string id);
        Task ShowBreweryDetailsAsync(string id, INavigation navigation);
    }
}