using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace XBreweryDbApp.ViewModels
{
    partial class DetailPageViewModel
    {
        private ICommand _favoriteCommand;

        public ICommand FavoriteCommand
        {
            get { return _favoriteCommand; }
        }
    }
}
