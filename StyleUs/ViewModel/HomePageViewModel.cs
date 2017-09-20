using System;

using System.ComponentModel;
using System.Windows.Input;

using Xamarin.Forms;

using StyleUs.View;
using Prism.Navigation;
using Prism.Commands;

namespace StyleUs.ViewModel
{
    public class HomePageViewModel
    {
        public FloatingMenuViewModel MenuViewModel { get; set; }

        public HomePageViewModel(INavigationService navigationService)
        {
            MenuViewModel = new FloatingMenuViewModel(navigationService);
        }
    }
}
