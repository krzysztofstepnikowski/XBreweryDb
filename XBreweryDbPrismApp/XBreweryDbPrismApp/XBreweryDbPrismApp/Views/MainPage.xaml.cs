using System;
using System.Diagnostics;
using Xamarin.Forms;
using XBreweryDbPrismApp.Models;
using XBreweryDbPrismApp.ViewModels;

namespace XBreweryDbPrismApp.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BreweryListView.ItemSelected += (sender, e) => BreweryListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            (BindingContext as MainPageViewModel)?.OnResume();
        }
    }
}
