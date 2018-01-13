using System;

using System.ComponentModel;
using System.Windows.Input;

using Xamarin.Forms;

using StyleUs.View;
using Prism.Navigation;
using Prism.Commands;
using StyleUs.ViewModel.Component;
using System.Collections.ObjectModel;
using Prism.Events;
using System.Threading.Tasks;
using Prism.Mvvm;

using StyleUs.Models;
using StyleUs.Services;

namespace StyleUs.ViewModel
{
    public class ProfileViewModel : ContentPage, INavigationAware
    {

        public DelegateCommand back { get; set; }
        public DelegateCommand more { get; set; }
        public DelegateCommand followers { get; set; }

        public User user { get; set; }

        readonly INavigationService navigation;
        IEventAggregator events;

        public new event PropertyChangedEventHandler PropertyChanged;

        public ProfileViewModel(INavigationService navigationService, IEventAggregator eventAgregator)
        {
            navigation = navigationService;
            events = eventAgregator;

            back = new DelegateCommand(OnBackClick);
            more = new DelegateCommand(OnMoreClick);
            followers = new DelegateCommand(OnFollowersClick);
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


        public void OnBackClick()
        {
            var navParameters = new NavigationParameters();
            navParameters.Add("user", user);

            //navigation.NavigateAsync("AboutUsPage");
            navigation.GoBackAsync(navParameters);
            //navigation.NavigateAsync(new Uri("/MainTabbedPage/MenuPage", UriKind.Absolute));

        }

        public void OnMoreClick()
        {
            var navParameters = new NavigationParameters();
            navParameters.Add("user", user);

            //Poner navigation a la pantalla de miguel
            navigation.NavigateAsync("ShowProfilePage",navParameters);
        }

        public void OnFollowersClick()
        {
            navigation.NavigateAsync("FollowerLists");

        }

        // INavigationAware
        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            // When you navigate away from this page
        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            var newUser = parameters["user"] as User;

            if (newUser != null)
            {
                user = newUser;
                return;
            }

            if (user == null)
            {
                onGetUserProfile();
            }
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {
           
        }


    }
}
