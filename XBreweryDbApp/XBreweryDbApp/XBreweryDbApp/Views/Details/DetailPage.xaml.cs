using Xamarin.Forms;
using XBreweryDbApp.Views.Details;

namespace XBreweryDbApp
{
    public partial class DetailPage : ContentPage
    {
       
        public DetailPage(string breweryId, IDetailPageFeatures features)
        {
            InitializeComponent();
        }
    }
}
