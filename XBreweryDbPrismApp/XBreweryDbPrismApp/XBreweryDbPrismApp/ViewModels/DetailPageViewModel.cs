using System;
using Prism.Mvvm;
using Prism.Navigation;
using XBreweryDbPrismApp.Features.Details;

namespace XBreweryDbPrismApp.ViewModels
{
    public class DetailPageViewModel : BindableBase, INavigationAware
    {
        private IDetailPageFeatures _detailPageFeatures;

        private string _description;

        public string Description
        {
            get { return _description; }

            set { SetProperty(ref _description, value); }
        }

        public DetailPageViewModel(IDetailPageFeatures detailPageFeatures)
        {
            _detailPageFeatures = detailPageFeatures;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
           
            var id = Convert.ToString(parameters["id"]);
            Description = _detailPageFeatures.GetBreweryDescription(id);

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
           
        }

       
    }
}