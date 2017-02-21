using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Prism.Unity;
using Xamarin.Forms;
using XBreweryDbPrismApp.Features.Details;
using XBreweryDbPrismApp.Features.Features.BreweryDescription;
using XBreweryDbPrismApp.Features.Features.BreweryList;
using XBreweryDbPrismApp.Features.Features.Favorite;
using XBreweryDbPrismApp.Features.Main;
using XBreweryDbPrismApp.Views;
using XBreweryDbPrismApp.ViewModels;

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
            var favoriteBrewerage = new HashSet<string>(); //moze byc tworzony raz
            var favoriteManager = new FavoriteBreweryManager(favoriteBrewerage);

            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainPage,MainPageViewModel>();
            Container.RegisterTypeForNavigation<DetailPage, DetailPageViewModel>();
            Container.RegisterType<IMainPageFeatures, MainPageFeature>();

            Container.RegisterType<BreweryListProvider>(new InjectionConstructor(favoriteBrewerage));
            Container.RegisterType<FavoriteBreweryManager>(new InjectionConstructor(favoriteBrewerage));

            Container.RegisterInstance<IDetailPageFeatures>(new DetailPageFeature(new BreweryDescriptionProvider(),
                favoriteManager));
        }
    }
}
