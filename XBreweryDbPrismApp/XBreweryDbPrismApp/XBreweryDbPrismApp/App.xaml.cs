using System.Collections.Generic;
using Autofac.Core;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Xamarin.Forms;
using XBreweryDbPrismApp.Features.Details;
using XBreweryDbPrismApp.Features.Features.BreweryDescription;
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
            Container.RegisterTypeForNavigation<MainPage>();
           Container.RegisterTypeForNavigation<DetailPage>();


            var favoriteBrewerage = new HashSet<string>();
            var favoriteManager = new FavoriteBreweryManager(favoriteBrewerage);
            Container.RegisterInstance<IMainPageFeatures>(new MainPageFeature(favoriteManager,
                new BreweryListProvider(favoriteBrewerage)));

            Container.RegisterInstance<IDetailPageFeatures>(new DetailPageFeature(new BreweryDescriptionProvider(), favoriteManager));
        }
    }
}
