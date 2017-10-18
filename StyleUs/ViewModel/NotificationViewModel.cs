using System;

using System.ComponentModel;
using System.Windows.Input;

using Xamarin.Forms;

using StyleUs.View;
using Prism.Navigation;
using Prism.Commands;
using StyleUs.ViewModel.Component;
using System.Collections.ObjectModel;

namespace StyleUs.ViewModel
{
    public class Notification {
        
        public string title { get; set; }
        public string detail { get; set; }
		public string type { get; set; }
        public ImageSource image { get; set; }

        public Notification(string title, string detail, string image, string type) {
            this.title = title;
            this.detail = detail;
            this.image = ImageSource.FromUri(new Uri(image));
            this.type = type;
        }

    }

    public class NotificationViewModel
    {
		public ObservableCollection<Notification> _notificationList = new ObservableCollection<Notification>();
        public ObservableCollection<Notification> notificationList { 
            get { 
                return _notificationList; 
            } 
            set { 
                _notificationList = value; 
            } 
        }

        public FloatingMenuViewModel MenuViewModel { get; set; }
        public ICommand ItemTappedCommand { get; set; }

        public INavigationService navigation;

        public NotificationViewModel(INavigationService navigationService)
        {
            MenuViewModel = new FloatingMenuViewModel(navigationService);



            fetchNotifications();

			notificationList.Add(new Notification("Ramon Manuel", "Ramon ha cargado una nueva prenda.","https://www.anipedia.net/imagenes/como-nacen-los-hamsters.jpg", "Piece"));
			notificationList.Add(new Notification("Manuel Matos", "Ramon ha cargado un nuevo conjunto.", "https://www.anipedia.net/imagenes/hamster-sirio-1.jpg", "Combination"));
			notificationList.Add(new Notification("Andrea Martines","Andrea te ha enviado una solicitud de seguimiento.", "https://www.anipedia.net/imagenes/cuidados-hamster.jpg", "Profile"));
            ItemTappedCommand = new Command(
                item => onItemTapped((Notification)item)
            );
            navigation = navigationService;
        }

        public async void fetchNotifications() {
            // var serv = new StyleUs.Services.ApiService();
            // var data = await serv.GetNotification();

            // notificationList.Add(new Notification(data.title, data.detail, data.img,"profile"));
        }

		/**
          *  [EVENT] Fired once the user has tapped the register button.
          */
        public void onItemTapped(Notification e)
		{
            switch(e.type) {
                case "Piece":
                case "Combination":
                    navigation.NavigateAsync("SingleClothPiece");
                    break;
                case "Profile":
                    navigation.NavigateAsync("FriendProfile");
                    break;
            }
		}
    }
}
