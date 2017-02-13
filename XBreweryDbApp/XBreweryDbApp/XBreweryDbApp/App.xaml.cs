using System.Collections.Generic;
using Xamarin.Forms;
using XBreweryDbApp.Adapters.Features;
using XBreweryDbApp.Features.BreweryDescription;
using XBreweryDbApp.Features.BreweryList;
using XBreweryDbApp.Features.Favorite;

namespace XBreweryDbApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var favoriteBrewerage = new HashSet<string>();
            var favoriteManager = new FavoriteBreweryManager(favoriteBrewerage);
            var detailPageFacade = new DetailPageFeatureFacade(favoriteManager, new BreweryDescriptionProvider());
            var mainPageFacade = new MainPageFeatureFacade(favoriteManager, new BreweryListProvider(favoriteBrewerage), detailPageFacade);

            MainPage = new NavigationPage(new MainPage(mainPageFacade));
        }


        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
