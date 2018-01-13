using System.ComponentModel;
using System.Windows.Input;

using Xamarin.Forms;

using StyleUs.View;

using Prism.Navigation;
using Prism.Events;

using StyleUs.Models.App;
using System;
using System.Collections.Generic;
using StyleUs.Services.API;
using static StyleUs.View.RegisterStepTwoPage;

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
            events.GetEvent<Events.payload>().Publish(new Alert
            {
                title = "Iniciando sesión",
                message = "Iniciando sesión, por favor, espere."
            });

            try {
                var res = await StyleUs.Services.AuthServices.register(registerUser);

                if (!res.Key)
                {
                    var errors = res.Value as Dictionary<string, ApiFieldError>;
                    string message = "Ha habido un error. Por favor, verifique sus datos e intente de nuevo.";

                    foreach(var entry in errors) {
                        message += $"\n {entry.Key}: {entry.Value.message}";
                    }
                    
                    events.GetEvent<Events.payload>().Publish(new Alert
                    {
                        title = "Error!",
                        message = message
                    });
                } else {
                    var user = res.Value as StyleUs.Models.User;
                    Application.Current.Properties["token"] = user.token;

                    await navigation.NavigateAsync(new Uri("/MainTabbedPage/HomePage", UriKind.Absolute));
                }

            } catch {
                // 
                events.GetEvent<Events.payload>().Publish(new Alert
                {
                    title = "Oops!",
                    message = "Something went wrong :( No hemos podido crear su cuenta. Por favor, intente mas tarde.",
                });
            }

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