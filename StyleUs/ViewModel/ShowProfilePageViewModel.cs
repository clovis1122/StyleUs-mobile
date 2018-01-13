using StyleUs.ViewModel;
using Xamarin.Forms;
using Prism.Navigation;
using Prism.Commands;
using Prism.Events;
using System.ComponentModel;


public class ShowProfilePageViewModel : ContentPage
{

    public DelegateCommand back { get; set; }
    public DelegateCommand edit { get; set; }

    readonly INavigationService navigation;
    IEventAggregator events;

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
        //navigation.NavigateAsync("AboutUsPage");
        navigation.GoBackAsync();
        //navigation.NavigateAsync(new Uri("/MainTabbedPage/MenuPage", UriKind.Absolute));

    }

    public void OnEditClick()
    {
        navigation.NavigateAsync("EditProfilePage");
    }



}
