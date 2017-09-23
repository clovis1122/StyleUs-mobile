using System;

using System.ComponentModel;
using System.Windows.Input;

using Xamarin.Forms;

using StyleUs.View;
using Prism.Navigation;
using Prism.Commands;
using StyleUs.ViewModel.Component;

namespace StyleUs.ViewModel
{
    public class HomePageViewModel
    {
        public FloatingMenuViewModel MenuViewModel { get; set; }
        public ICommand ViewComment { get; set; }
        public INavigationService navigation;

        public HomePageViewModel(INavigationService navigationService)
        {
            MenuViewModel = new FloatingMenuViewModel(navigationService);
            navigation = navigationService;
            ViewComment = new Command(goToComment);
        }

        public void goToComment()
        {
            navigation.NavigateAsync("AddCommentPage");
        }
        
    }
}
