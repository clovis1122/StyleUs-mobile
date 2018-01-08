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


namespace StyleUs.ViewModel
{
    public class ProfileViewModel : ContentPage
    {

        public DelegateCommand back { get; set; }
        public DelegateCommand edit { get; set; }
        public DelegateCommand followers { get; set; }

        readonly INavigationService navigation;
        IEventAggregator events;

        public new event PropertyChangedEventHandler PropertyChanged;

        public ProfileViewModel(INavigationService navigationService, IEventAggregator eventAgregator)
        {
            navigation = navigationService;
            events = eventAgregator;

            back = new DelegateCommand(OnBackClick);
            edit = new DelegateCommand(OnEditClick);
            followers = new DelegateCommand(OnFollowersClick);
        }


        public void OnBackClick()
        {
            //navigation.NavigateAsync("AboutUsPage");
            navigation.GoBackAsync();
            //navigation.NavigateAsync(new Uri("/MainTabbedPage/MenuPage", UriKind.Absolute));

        }

        public void OnEditClick()
        {
            //Poner navigation a la pantalla de miguel

        }

        public void OnFollowersClick()
        {

            navigation.NavigateAsync("FollowerLists");

        }


    }
}
