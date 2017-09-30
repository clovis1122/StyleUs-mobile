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
    public class FriendProfileViewModel
	{
		public FloatingMenuViewModel MenuViewModel { get; set; }
		public INavigationService navigation;

		public FriendProfileViewModel(INavigationService navigationService)
		{
			MenuViewModel = new FloatingMenuViewModel(navigationService);
			navigation = navigationService;
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
