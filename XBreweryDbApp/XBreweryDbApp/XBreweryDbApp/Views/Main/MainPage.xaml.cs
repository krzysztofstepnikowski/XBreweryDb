using System;
using Xamarin.Forms;

namespace XBreweryDbApp
{
    public partial class MainPage : ContentPage
    {
        private IMainPageFeatures _features;

        public MainPage(IMainPageFeatures features)
        {
            _features = features;
            InitializeComponent();
            BreweryListView.ItemsSource = _features.GetBreweries();
            BreweryListView.ItemSelected += (sender, e) => BreweryListView.SelectedItem = null;
        }

        private void OnItemFavoriteTapped(object sender, EventArgs e)
        {
            var button = (sender as Button);
            var brewery = button.BindingContext as Brewery;
            brewery.IsFavorite = !brewery.IsFavorite;

            UpdateFavoriteImage(button, brewery);
            UpdateFavoriteStatus(brewery);
        }

        private void UpdateFavoriteStatus(Brewery brewery)
        {
            if (brewery.IsFavorite)
            {
                _features.SetAsFavorite(brewery.Id);
            }
            else
            {
                _features.RemoveFromFavorites(brewery.Id);
            }
        }

        private static void UpdateFavoriteImage(Button button, Brewery brewery)
        {
            button.Image.File = brewery.IsFavorite
                ? button.Image.File = "ic_favorite.png"
                : button.Image.File = "ic_favorite_border.png";
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var brewery = e.Item as Brewery;
            _features.ShowBreweryDetailsAsync(brewery.Id, Navigation);            
        }
    }
}
