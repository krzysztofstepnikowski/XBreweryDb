using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XBreweryDbApp.ViewModels
{
    partial class MainPageViewModel
    {
        private DelegateCommand<ItemTappedEventArgs> _goToDetailPage;

        public DelegateCommand<ItemTappedEventArgs> GoToDetailPage
        {
            get { return _goToDetailPage; }
        }

        private ICommand _favoriteCommand;
    }
}
