using System.Windows.Input;
using Xamarin.Forms;

namespace XBreweryDbPrismApp.Models
{
    public class Brewery
    {
        public string Id { get; set; }
        public bool IsFavorite { get; set; }
        public string Name { get; set; }

        public FileImageSource FileImageSource { get; set; }

        public ICommand FavoriteCommand { get; set; }

        public Brewery()
        {
        }

        public Brewery(string id, bool isFavorite, string name, FileImageSource fileImageSource)
        {
            Id = id;
            IsFavorite = isFavorite;
            Name = name;
            FileImageSource = fileImageSource;
        }
    }
}
