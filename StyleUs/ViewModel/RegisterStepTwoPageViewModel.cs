using System.ComponentModel;
using System.Windows.Input;

using Xamarin.Forms;

using StyleUs.View;

using Prism.Navigation;
using Prism.Events;

using StyleUs.Models.App;
using System;

namespace StyleUs.ViewModel
{
    public class RegisterStepTwoPageViewModel : INotifyPropertyChanged, INavigationAware
	{

		public ICommand goBack { get; set; }
        public ICommand finish { get; set; }

		public INavigationService navigation;
        IEventAggregator events;

		public event PropertyChangedEventHandler PropertyChanged;

        public string email { get { return registerUser.email; } set { registerUser.email = value; } }
        public string password { get { return registerUser.password; } set { registerUser.password = value; } }
        public string password_confirmation { 
            get { return registerUser.password_confirmation; } 
            set { registerUser.password_confirmation = value; } 
        }


        private RegisterUser registerUser;

		/**
          *  [CONSTRUCTOR] Get the required parameters and initializes them as needed.
          *  
          *  @param INavigationService   the required navigation service.
          */
        public RegisterStepTwoPageViewModel(INavigationService navigationService, IEventAggregator eventAgregator)
		{
			navigation = navigationService;
            events = eventAgregator;

            registerUser = new RegisterUser();
			// Commands
			goBack = new Command(onBack);
            finish = new Command(onFinish);
		}

		/**
          *  [EVENT] Fired once the user has decided to cancel.
          */
		public void onBack()
		{
            var param = new NavigationParameters();
            param.Add("user", registerUser);

            navigation.GoBackAsync(param);
		}

		/**
          *  [EVENT] Fired once the user has decided to finish.
          */
		public async void onFinish()
		{
            var res = await StyleUs.Services.AuthServices.register(registerUser);

            if (!res.Key)
            {
                events.GetEvent<Events.displayMessage>().Publish("No hemos podido crear su cuenta. Por favor, intente mas tarde.");
                return;
            }

            await navigation.NavigateAsync(new Uri("http://www.StyleUs.com/HomePage", UriKind.Absolute));
		}

        // INavigationAware
        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            
        }
        public void OnNavigatedTo(NavigationParameters parameters)
        {
            var user = parameters["user"];

            if (user is RegisterUser) {
                this.registerUser = (RegisterUser)user;

                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs("email"));
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs("password"));
                PropertyChanged?.Invoke(this,
                    new PropertyChangedEventArgs("password_confirmation"));
            }
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            // stub
        }
	}
}