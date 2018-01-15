using System;

using System.ComponentModel;
using System.Windows.Input;

using Xamarin.Forms;

using StyleUs.View;
using Prism.Navigation;
using Prism.Commands;
using Prism.Events;
using System.Threading.Tasks;
using StyleUs.Models;

namespace StyleUs.ViewModel
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {

        public ICommand register { get; set; }
        public ICommand login { get; set; }
        public ICommand forgotPassword { get; set; }

        INavigationService navigation;
        IEventAggregator events;

        public event PropertyChangedEventHandler PropertyChanged;

        public string email { get; set; }
        public string password { get; set; }

        /**
          *  [CONSTRUCTOR] Get the required parameters and initializes them as needed.
          *  
          *  @param INavigationService   the required navigation service.
          */
        public LoginPageViewModel(INavigationService navigationService, IEventAggregator eventAgregator)
        {
            navigation = navigationService;
            events = eventAgregator;
            email = "";
            password = "";

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

            if (email.Length == 0 || password.Length == 0) {
                events.GetEvent<Events.displayMessage>().Publish("Introduzca sus credenciales para iniciar sesión.");
                return;
            }

            events.GetEvent<Events.onLoginEvent>().Publish(true);

            AttemptLogin();
        }

        private async void AttemptLogin()
        {
            try
            {
                var res = await StyleUs.Services.AuthServices.login(email, password);

                if (!res.Key)
                {
                    events.GetEvent<Events.displayMessage>().Publish("No hemos podido iniciar sesion. Por favor, verifique sus credenciales.");
                    return;
                }

                var user = res.Value as User;

                Application.Current.Properties["token"] = user.token;
                Application.Current.SavePropertiesAsync();

                // Logged in!


                await navigation.NavigateAsync(new Uri("/MainTabbedPage/HomePage", UriKind.Absolute));

            }
            catch (Exception ex)
            {
                events.GetEvent<Events.displayMessage>().Publish("No hemos podido iniciar sesion. Por favor, verifique sus credenciales.");
            }
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