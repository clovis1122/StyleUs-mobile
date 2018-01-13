using StyleUs.ViewModel;
using Xamarin.Forms;
using Prism.Navigation;
using Prism.Commands;
using Prism.Events;
using System.ComponentModel;
using StyleUs.Services;
using System;
using StyleUs.Models;

namespace StyleUs.ViewModel
{
    public class EditProfilePageViewModel : ContentPage, INavigationAware
    {

        public DelegateCommand cancel { get; set; }
        public DelegateCommand save { get; set; }

        readonly INavigationService navigation;
        IEventAggregator events;

        public User user { get; set; }

        public EditProfilePageViewModel(INavigationService navigationService, IEventAggregator eventAgregator)
        {
            navigation = navigationService;
            events = eventAgregator;

            cancel = new DelegateCommand(OnCancelClick);
            save = new DelegateCommand(OnSaveClick);
        }

        public void OnCancelClick()
        {
            navigation.GoBackAsync();
        }

        public void OnSaveClick()
        {
            var navParameters = new NavigationParameters();
            navParameters.Add("user", user);

            navigation.GoBackAsync(navParameters);
        }

        // INavigationAware
        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            // When you go out
        }
        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            var newUser = parameters["user"] as User;

            if (newUser != null)
            {
                user = newUser.clone() as User;
                return;
            }

            if (user == null)
            {
                onGetUserProfile();
            }
        }

        public async void onGetUserProfile()
        {
            try
            {
                var response = await UserServices.getProfile();
                if (!response.Key)
                {
                    throw new Exception("FAILED!");
                }

                user = response.Value as User;
            }
            catch
            {
                // Failed :(

                var newUser = new StyleUs.Models.User();
                newUser.first_name = "Juan";
                newUser.last_name = "Perez";
                newUser.email = "dududu@chamuel.co";
                newUser.image = "icon1.png";

                user = newUser;
            }
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
            // todo
        }
    }
}
