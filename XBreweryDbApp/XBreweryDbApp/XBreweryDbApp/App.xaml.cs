using System.Collections.Generic;
using Prism.Unity;
using Xamarin.Forms;
using XBreweryDbApp.Features.BreweryDescription;
using XBreweryDbApp.Features.BreweryList;
using XBreweryDbApp.Features.Favorite;
using XBreweryDbApp.ViewModels;
using Microsoft.Practices.Unity;
using XBreweryDbApp.Views.Details;
using XBreweryDbApp.Adapters.Features;
using XBreweryDbApp.Views.Main;

namespace XBreweryDbApp
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
            Container.RegisterTypeForNavigation<MainPage, MainPageViewModel>();
            Container.RegisterTypeForNavigation<DetailPage, DetailPageViewModel>();
            Container.RegisterType<IMainPageFeatures, MainPageFeatureFacade>();

            Container.RegisterType<BreweryListProvider>(new InjectionConstructor(favoriteBrewerage));
            Container.RegisterType<FavoriteBreweryManager>(new InjectionConstructor(favoriteBrewerage));

            Container.RegisterInstance<IDetailPageFeatures>(new DetailPageFeatureFacade(new BreweryDescriptionProvider(),
                favoriteManager));
        }
    }
}
