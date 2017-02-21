using Prism.Mvvm;
using System.Windows.Input;

namespace XBreweryDbApp.Models
{
    public class BreweryViewModel : BindableBase
    {
        public string Id { get; set; }
        private bool _isFavorite;
        public bool IsFavorite
        {
            get
            {
                return _isFavorite;
            }
            set
            {

                SetProperty(ref _isFavorite, value);
                OnPropertyChanged(() => FileImagePath);
            }
        }
        public string Name { get; set; }

        public string FileImagePath => IsFavorite ? "ic_favorite.png" : "ic_favorite_border.png";

        public ICommand FavoriteCommand { get; set; }

        public BreweryViewModel()
        {
        }

        public BreweryViewModel(string id, bool isFavorite, string name)
        {
            Id = id;
            IsFavorite = isFavorite;
            Name = name;

        }
    }
}
