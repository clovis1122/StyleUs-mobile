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
        public ICommand AddCommentView { get; set; }
        public ICommand SeeCommentView { get; set; }
        public INavigationService navigation;

        public HomePageViewModel(INavigationService navigationService)
        {
            MenuViewModel = new FloatingMenuViewModel(navigationService);
            navigation = navigationService;
            AddCommentView = new Command(GoToAddComment);
            SeeCommentView = new Command(GoToSeeComment);
        }

        public void GoToAddComment()
        {
            navigation.NavigateAsync("AddCommentPage");
        }

        public void GoToSeeComment()
        {
            navigation.NavigateAsync("ViewComments");
        }
        
    }
}
