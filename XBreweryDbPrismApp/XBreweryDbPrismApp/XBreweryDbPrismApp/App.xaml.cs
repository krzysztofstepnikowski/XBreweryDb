using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Xamarin.Forms;
using XBreweryDbPrismApp.Features.Features.BreweryList;
using XBreweryDbPrismApp.Features.Features.Favorite;
using XBreweryDbPrismApp.Features.Main;
using XBreweryDbPrismApp.ViewModels;
using XBreweryDbPrismApp.Views;

namespace XBreweryDbPrismApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer)
        {
        }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage, MainPageViewModel>();
            Container.RegisterTypeForNavigation<DetailPage>();


            var favoriteBrewerage = new HashSet<string>();
            var favoriteManager = new FavoriteBreweryManager(favoriteBrewerage);
            Container.RegisterInstance<IMainPageFeatures>(new MainPageFeature(favoriteManager,
                new BreweryListProvider(favoriteBrewerage)));
        }
    }
}
