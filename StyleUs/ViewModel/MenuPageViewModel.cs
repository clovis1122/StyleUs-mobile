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
    public class MenuPageViewModel : INotifyPropertyChanged
    {
        public DelegateCommand pieza { get; set; }
        public DelegateCommand conjunto { get; set; }
        public DelegateCommand sobreNosotros { get; set; }
        public DelegateCommand salir { get; set; }

        readonly INavigationService navigation;
        IEventAggregator events;

        public event PropertyChangedEventHandler PropertyChanged;

        public MenuPageViewModel(INavigationService navigationService, IEventAggregator eventAgregator)
        {
            navigation = navigationService;
            events = eventAgregator;

            pieza = new DelegateCommand(OnPiezasClick);
            conjunto = new DelegateCommand(OnConjuntoClick);
            sobreNosotros = new DelegateCommand(OnSobreNosotrosClick);
            salir = new DelegateCommand(OnSalirClick);

        }


        public void OnPiezasClick()
        {

            //navigation.NavigateAsync(new Uri("/MainTabbedPage/AboutUsPage", UriKind.Absolute));
            navigation.NavigateAsync("AboutUsPage");
            //navigation.NavigateAsync(new Uri("/NavigationPage/AboutUsPage", UriKind.Absolute));
        }

        public void OnConjuntoClick()
        {
            navigation.NavigateAsync("AboutUsPage");
        }

        public void OnSobreNosotrosClick()
        {
            navigation.NavigateAsync("AboutUsPage");
        }

        public void OnSalirClick()
        {
            navigation.NavigateAsync("LoginPage");
        }
    }
}
