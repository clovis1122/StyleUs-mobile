using System;

using System.ComponentModel;
using System.Windows.Input;

using Xamarin.Forms;

using StyleUs.View;
using Prism.Navigation;
using Prism.Commands;

namespace StyleUs.ViewModel
{
	public class LoginViewModel : INotifyPropertyChanged
	{
        
		public ICommand registerClick { get; set; }
        public INavigationService navigation;

		public event PropertyChangedEventHandler PropertyChanged;

		public string username { get; set; }
		public string password { get; set; }

		/**
          *  [CONSTRUCTOR] Get the required parameters and initializes them as needed.
          *  
          *  @param INavigationService   the required navigation service.
          */
        public LoginViewModel(INavigationService navigationService)
		{
            navigation = navigationService;

            registerClick = new Command(onRegisterClick);
		}

		/**
          *  [EVENT] Fired once the user has tapped the register button.
          */
		public void onRegisterClick()
        {
            navigation.NavigateAsync("RegisterStepOne");
		}

		/**
          *  [EVENT] Fired when the user's tapped feature is not available.
          */
		public void notYet()
		{
            // TODO: Implement with Messaging Center.
			// DisplayAlert("Lo sentimos!", "Todavia no se ha implementado esta funcionalidad.", "Aceptar");
		}
    }
}