using System;

using System.ComponentModel;
using System.Windows.Input;

using Xamarin.Forms;

using StyleUs.View;
using Prism.Navigation;
using Prism.Commands;

namespace StyleUs.ViewModel
{
	public class LoginPageViewModel : INotifyPropertyChanged
	{

		public ICommand register { get; set; }
		public ICommand login { get; set; }
        public ICommand forgotPassword { get; set; }
        public INavigationService navigation;

		public event PropertyChangedEventHandler PropertyChanged;

		public string email { get; set; }
		public string password { get; set; }

		/**
          *  [CONSTRUCTOR] Get the required parameters and initializes them as needed.
          *  
          *  @param INavigationService   the required navigation service.
          */
        public LoginPageViewModel(INavigationService navigationService)
		{
            navigation = navigationService;

			register = new Command(onRegisterClick);
			login = new Command(onLoginClick);
            forgotPassword = new Command(onForgotPasswordClick);
		}

		/**
          *  [EVENT] Fired once the user has tapped the register button.
          */
		public void onRegisterClick()
        {
            navigation.NavigateAsync("RegisterStepOnePage");
		}

		/**
          *  [EVENT] Fired once the user has tapped the login button.
          */
		public void onLoginClick()
		{
            //TODO: Validate the data!

            AttemptLogin();
		}

        private async void AttemptLogin() {
            
            var res = await StyleUs.Services.AuthServices.login(email, password);

            if (res.Key) {
                
                // Make a fake page just so we can mark it as absolute.

                await navigation.NavigateAsync(new Uri("http://www.StyleUs.com/HomePage",UriKind.Absolute));
            } else {
                //AUTH FAILED.
            }

            return;
        }

		/**
          *  [EVENT] Fired once the user has tapped the register button.
          */
		public void onForgotPasswordClick()
		{
			navigation.NavigateAsync("ForgotPasswordPage");
            // http://www.StyleUs/com/Login/ForgotPasswordPage/HomePage/LogiPage
		}

    }
}