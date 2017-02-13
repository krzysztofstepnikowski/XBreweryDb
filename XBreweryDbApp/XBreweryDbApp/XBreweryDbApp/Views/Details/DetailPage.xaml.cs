using Xamarin.Forms;
using XBreweryDbApp.Views.Details;

namespace XBreweryDbApp
{
    public partial class DetailPage : ContentPage
    {
        private readonly string _breweryId;
        private readonly IDetailPageFeatures _features;
        private bool _isBreweryFavorite;

        public DetailPage(string breweryId, IDetailPageFeatures features)
        {
            _breweryId = breweryId;
            _features = features;
            InitializeComponent();
            _isBreweryFavorite = _features.IsBreweryFavorite(_breweryId);
            DescriptionLabel.Text = _features.GetBreweryDescription(_breweryId);
            FavoriteButton.Clicked += OnFavoriteButtonClick;
            UpdateButtonStyle(FavoriteButton);
        }

        private void OnFavoriteButtonClick(object sender, System.EventArgs e)
        {
            _isBreweryFavorite = !_isBreweryFavorite;

            var button = sender as Button;
            UpdateButtonStyle(button);

            if (_isBreweryFavorite)
            {
                _features.SetAsFavorite(_breweryId);
            }
            else
            {
                _features.RemoveFromFavorites(_breweryId);
            }
        }

        private void UpdateButtonStyle(Button button)
        {
            button.BackgroundColor = _isBreweryFavorite ? Color.Green : Color.Red;
            button.Text = _isBreweryFavorite
                ? button.Text = "Delete from favorites"
                : button.Text = "Add to favorites";
        }
    }
}
