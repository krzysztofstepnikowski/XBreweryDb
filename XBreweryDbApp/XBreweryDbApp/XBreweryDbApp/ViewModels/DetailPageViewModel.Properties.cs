using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XBreweryDbApp.ViewModels
{
    partial class DetailPageViewModel
    {
        private string _id;

        public string Id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }

        private string _description;

        public string Description
        {
            get { return _description; }

            set { SetProperty(ref _description, value); }
        }



        public string FavoriteButtonText => IsFavorite ? "Delete from favorites" : "Add to favorites";

        public Color FavoriteButtonBackgroundColor => IsFavorite ? Color.Green : Color.Red;


        private bool _isFavorite;

        public bool IsFavorite
        {
            get { return _isFavorite; }

            set
            {
                SetProperty(ref _isFavorite, value);
                OnPropertyChanged(() => FavoriteButtonText);
                OnPropertyChanged(() => FavoriteButtonBackgroundColor);
            }
        }

    }
}
