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
        public ICommand pieza { get; set; }
        public ICommand conjunto { get; set; }
        public ICommand sobreNosotros { get; set; }
        public ICommand salir { get; set; }

        public DelegateCommand perfil { get; set; }

        readonly INavigationService navigation;
        IEventAggregator events;

        NavigationPage navegacion;

        public event PropertyChangedEventHandler PropertyChanged;

        public MenuPageViewModel(INavigationService navigationService, IEventAggregator eventAgregator)
        {
            navigation = navigationService;
            events = eventAgregator;

            pieza = new Command(OnPiezasClick);
            conjunto = new Command(OnConjuntoClick);
            sobreNosotros = new Command(OnSobreNosotrosClick);
            salir = new Command(OnSalirClick);
            perfil = new DelegateCommand(OnPerfilClick);

        }

        public void OnPerfilClick(){

            navigation.NavigateAsync("ProfilePage");

        }

        public void OnPiezasClick()
        {

            //navigation.NavigateAsync(new Uri("/MainTabbedPage/AboutUsPage", UriKind.Absolute));
            navigation.NavigateAsync("ClothPieces");
            //navegacion.PushAsync(new AboutUsPage());
            //navigation.NavigateAsync(new Uri("/NavigationPage/AboutUsPage", UriKind.Absolute));
        }

        public void OnConjuntoClick()
        {
            navigation.NavigateAsync("ClothCombinationPage");
        }

        public void OnSobreNosotrosClick()
        {
            navigation.NavigateAsync("AboutUsPage");
            //navigation.NavigateAsync(new Uri("/MainTabbedPage/AboutUsPage", UriKind.Absolute));

        }

        public void OnSalirClick()
        {
            navigation.NavigateAsync("LoginPage");
        }
    }
}
