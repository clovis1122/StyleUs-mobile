using System;

using System.ComponentModel;
using System.Windows.Input;

using Xamarin.Forms;

using StyleUs.View;
using Prism.Navigation;
using Prism.Commands;
using Prism.Events;
using System.Threading.Tasks;

namespace StyleUs.ViewModel
{
    public class MenuViewModel : INotifyPropertyChanged
    {
        public ICommand pieza { get; set; }
        public ICommand conjunto { get; set; }
        public ICommand salir { get; set; }

        INavigationService navigation;
        IEventAggregator events;

        public event PropertyChangedEventHandler PropertyChanged;

        public MenuViewModel(INavigationService navigationService, IEventAggregator eventAgregator)
        {
            navigation = navigationService;
            events = eventAgregator;

            pieza = new Command(onPiezasClick);
            conjunto = new Command(onConjuntoClick);
            salir = new Command(onSalirClick);

        }

        public void onPiezasClick(){
            navigation.NavigateAsync("ClothPiecePage");
        }

        public void onConjuntoClick()
        {
            navigation.NavigateAsync("ClothCombinationPage");
        }

        public void onSalirClick()
        {
            navigation.NavigateAsync("LoginPage");
        }
    }
}
