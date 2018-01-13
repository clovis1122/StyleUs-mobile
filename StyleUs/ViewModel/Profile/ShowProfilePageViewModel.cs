using StyleUs.ViewModel;
using Xamarin.Forms;
using Prism.Navigation;
using Prism.Commands;
using Prism.Events;
using System.ComponentModel;
using StyleUs.Models;
using System;
using StyleUs.Services;

public class ShowProfilePageViewModel : ContentPage, INavigationAware
{

    public DelegateCommand back { get; set; }
    public DelegateCommand edit { get; set; }

    readonly INavigationService navigation;
    IEventAggregator events;

    public User user { get; set; }

    //public new event PropertyChangedEventHandler PropertyChanged;

    public ShowProfilePageViewModel(INavigationService navigationService, IEventAggregator eventAgregator)
    {
        navigation = navigationService;
        events = eventAgregator;

        back = new DelegateCommand(OnBackClick);
        edit = new DelegateCommand(OnEditClick);
    }


    public void OnBackClick()
    {
        var navParameters = new NavigationParameters();
        navParameters.Add("user", user);

        //navigation.NavigateAsync("AboutUsPage");
        navigation.GoBackAsync(navParameters);
        //navigation.NavigateAsync(new Uri("/MainTabbedPage/MenuPage", UriKind.Absolute));

    }

    public void OnEditClick()
    {
        var navParameters = new NavigationParameters();
        navParameters.Add("user", user);

        navigation.NavigateAsync("EditProfilePage", navParameters);
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
            user = newUser;
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
