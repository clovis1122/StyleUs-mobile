using StyleUs.ViewModel;
using Xamarin.Forms;
using Prism.Navigation;
using Prism.Commands;
using Prism.Events;
using System.ComponentModel;

public class EditProfilePageViewModel
    {
        public class EditProfileViewModel : ContentPage
    {

        public DelegateCommand back { get; set; }

        readonly INavigationService navigation;
        IEventAggregator events;

        public new event PropertyChangedEventHandler PropertyChanged;

        public EditProfileViewModel(INavigationService navigationService, IEventAggregator eventAgregator)
        {
            navigation = navigationService;
            events = eventAgregator;

            back = new DelegateCommand(OnBackClick);
        }


        public void OnBackClick()
        {
            //navigation.NavigateAsync("AboutUsPage");
            navigation.GoBackAsync();
            //navigation.NavigateAsync(new Uri("/MainTabbedPage/MenuPage", UriKind.Absolute));

        }


    
    }
}
