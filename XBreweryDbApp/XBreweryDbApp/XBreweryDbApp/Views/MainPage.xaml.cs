using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace XBreweryDbApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BreweryListView.ItemsSource = GetItems();
        }

        private ObservableCollection<Brewery> GetItems()
        {
            var breweries = new ObservableCollection<Brewery>();
            for (var i = 1; i <= 20; i++)
            {
                breweries.Add(new Brewery {Name = "Brewery " + i});
            }

            return breweries;
        }
    }
}
