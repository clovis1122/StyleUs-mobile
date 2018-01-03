using System;

using System.ComponentModel;
using System.Windows.Input;

using Xamarin.Forms;

using StyleUs.View;
using Prism.Navigation;
using Prism.Commands;
using Prism.Events;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace StyleUs.ViewModel
{
    public class AboutUsPageViewModel : ContentPage
    {

        public DelegateCommand back { get; set; }

        readonly INavigationService navigation;
        IEventAggregator events;

        public event PropertyChangedEventHandler PropertyChanged;

        public AboutUsPageViewModel(INavigationService navigationService, IEventAggregator eventAgregator)
        {
            navigation = navigationService;
            events = eventAgregator;

            back = new DelegateCommand(OnBackClick);
        }


        public void OnBackClick(){
            //navigation.NavigateAsync("AboutUsPage");
            navigation.GoBackAsync();
            //navigation.NavigateAsync(new Uri("/MainTabbedPage/MenuPage", UriKind.Absolute));
           
        }
    }
}

