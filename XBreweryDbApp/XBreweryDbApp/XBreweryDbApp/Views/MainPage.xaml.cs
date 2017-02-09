using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace XBreweryDbApp
{
    public partial class MainPage : ContentPage
    {
        private ObservableCollection<Brewery> _breweries;

        public ObservableCollection<Brewery> Breweries
        {
            get { return _breweries; }
            set
            {
                if (_breweries == null) return;
                _breweries = value;
                OnPropertyChanged();
            }
        }

        public MainPage()
        {
           
            InitializeComponent();
            GetItems();
            BreweryListView.ItemSelected += (sender, e) => BreweryListView.SelectedItem = null;
            BindingContext = this;
        }

        private ObservableCollection<Brewery> GetItems()
        {
            _breweries = new ObservableCollection<Brewery>();
            for (var i = 1; i <= 20; i++)
                _breweries.Add(new Brewery {Name = "Brewery " + i});

            return _breweries;
        }

        private void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new DetailPage());
        }
    }
}
