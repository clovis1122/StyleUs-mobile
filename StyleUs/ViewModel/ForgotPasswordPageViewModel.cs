using System;

using System.ComponentModel;
using System.Windows.Input;

using Xamarin.Forms;

using StyleUs.View;
using Prism.Navigation;
using Prism.Commands;

namespace StyleUs.ViewModel
{
	public class ForgotPasswordPageViewModel : INotifyPropertyChanged
	{

		public ICommand send { get; set; }

		public INavigationService navigation;

		public event PropertyChangedEventHandler PropertyChanged;

		public string email { get; set; }

		/**
          *  [CONSTRUCTOR] Get the required parameters and initializes them as needed.
          *  
          *  @param INavigationService   the required navigation service.
          */
		public ForgotPasswordPageViewModel(INavigationService navigationService)
		{
			navigation = navigationService;

			send = new Command(onSendClick);
		}

		/**
          *  [EVENT] Fired once the user has tapped the send button.
          */
		public void onSendClick()
		{
			navigation.GoBackAsync();
		}
	}
}
