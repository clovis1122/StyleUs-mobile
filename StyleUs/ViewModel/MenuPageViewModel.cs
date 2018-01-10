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

using StyleUs.Models;
using StyleUs.Services;

namespace StyleUs.ViewModel
{
    public class MenuPageViewModel : INotifyPropertyChanged
    {
        public ICommand pieza { get; set; }
        public ICommand conjunto { get; set; }
        public ICommand sobreNosotros { get; set; }
        public ICommand salir { get; set; }

        public DelegateCommand perfil { get; set; }

        public User user { get; set; }

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

            onGetUserProfile();
        }

        public async void onGetUserProfile() 
        {
            try {
                var response = await UserServices.getProfile();
                if (!response.Key) {
                    throw new Exception("FAILED!");
                }

                user = response.Value as User;
            } catch {

                // Failed :(

                var newUser = new StyleUs.Models.User();
                newUser.first_name = "Juan";
                newUser.last_name = "Perez";
                newUser.email = "dududu@chamuel.co";
                newUser.image = "icon1.png";

                user = newUser;
            }
        }

        public void OnPerfilClick()
        {
            navigation.NavigateAsync("ProfilePage");
        }

        public void OnPiezasClick()
        {
            navigation.NavigateAsync("ClothPieces");
        }

        public void OnConjuntoClick()
        {
            navigation.NavigateAsync("ClothCombinationPage");
        }

        public void OnSobreNosotrosClick()
        {
            navigation.NavigateAsync("AboutUsPage");
        }

        public async void OnSalirClick()
        {
            Application.Current.Properties.Clear();
            await Application.Current.SavePropertiesAsync();
            navigation.NavigateAsync("Login");
        }
    }
}
