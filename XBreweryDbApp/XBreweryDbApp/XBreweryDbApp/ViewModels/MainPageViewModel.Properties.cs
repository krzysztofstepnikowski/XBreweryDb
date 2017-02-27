using System.Collections.ObjectModel;
using XBreweryDbApp.Models;

namespace XBreweryDbApp.ViewModels
{
    partial class MainPageViewModel
    {
        private ObservableCollection<BreweryViewModel> _breweries;

        public ObservableCollection<BreweryViewModel> Breweries
        {
            get { return _breweries; }

            set { SetProperty(ref _breweries, value); }
        }


        private bool _isFavorite;

        public bool IsFavorite
        {
            get { return _isFavorite; }
            set { SetProperty(ref _isFavorite, value); }
        }
    }
}
