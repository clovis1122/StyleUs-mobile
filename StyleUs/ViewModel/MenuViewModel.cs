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
    public class MenuViewModel : INotifyPropertyChanged
    {
        public DelegateCommand pieza { get; set; }
        public DelegateCommand conjunto { get; set; }
        public DelegateCommand sobreNosotros { get; set; }
        public DelegateCommand salir { get; set; }

        INavigationService navigation;
        IEventAggregator events;

        public event PropertyChangedEventHandler PropertyChanged;

        public MenuViewModel(INavigationService navigationService, IEventAggregator eventAgregator)
        {
            navigation = navigationService;
            events = eventAgregator;

            pieza = new DelegateCommand(onPiezasClick);
            conjunto = new DelegateCommand(onConjuntoClick);
            sobreNosotros = new DelegateCommand(onSobreNosotrosClick);
            salir = new DelegateCommand(onSalirClick);

        }


        public void onPiezasClick(){
            //navigation.NavigateAsync(new Uri("/MainTabbedPage/ClothPiecePage", UriKind.Absolute));
            navigation.NavigateAsync("ClothPiecePage");
        }

        public void onConjuntoClick()
        {
            navigation.NavigateAsync("ClothCombinationPage");
        }

        public void onSobreNosotrosClick(){
            navigation.NavigateAsync("ProfilePage");
        }

        public void onSalirClick()
        {
            navigation.NavigateAsync("LoginPage");
        }
    }
}
