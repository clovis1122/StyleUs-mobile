using System.ComponentModel;
using System.Windows.Input;

using Xamarin.Forms;

using StyleUs.View;
using Prism.Navigation;
using System;
using StyleUs.Models.App;

namespace StyleUs.ViewModel
{
    public class RegisterStepOnePageViewModel : INotifyPropertyChanged, INavigationAware
	{

		public ICommand cancel { get; set; }
		public ICommand next { get; set; }

		public INavigationService navigation;

		public event PropertyChangedEventHandler PropertyChanged;

        public string first_name { get { return registerUser.first_name; } set { registerUser.first_name = value; } }
        public string last_name { get { return registerUser.last_name; } set { registerUser.last_name = value; } }
        public DateTime birthday { get { return registerUser.birthday; } set { registerUser.birthday = value; } }
        public bool is_male { get { return registerUser.is_male; } set { registerUser.is_male = value; } }

        private RegisterUser registerUser;
         
		/**
          *  [CONSTRUCTOR] Get the required parameters and initializes them as needed.
          *  
          *  @param INavigationService   the required navigation service.
          */
		public RegisterStepOnePageViewModel(INavigationService navigationService)
		{
			navigation = navigationService;

			// Commands
            cancel = new Command(onCancel);
            next = new Command(onNext);

            // Attributes

            registerUser = new RegisterUser();
		}

		/**
    	  *  [EVENT] Fired once the user has decided to cancel.
    	  */
		public void onCancel()
		{
            navigation.GoBackAsync();
		}

		/**
          *  [EVENT] Fired once the user has decided to continue.
          */
		public void onNext()
		{
            var param = new NavigationParameters();
            param.Add("user", registerUser);

            navigation.NavigateAsync("RegisterStepTwoPage",param);
		}

        // INavigationAware
        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            var user = parameters["user"];

            if (user is RegisterUser)
            {
                this.registerUser = (RegisterUser)user;
            }
        }
        public void OnNavigatedTo(NavigationParameters parameters)
        {
            var user = parameters["user"];

            if (user is RegisterUser)
            {
                this.registerUser = (RegisterUser)user;
            }
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            // stub
        }
    }
}