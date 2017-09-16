using System;

using System.ComponentModel;
using System.Windows.Input;

using Xamarin.Forms;

using StyleUs.View;
using Prism.Navigation;
using Prism.Commands;
using Prism.Mvvm;

namespace StyleUs.ViewModel
{
    public class FloatingMenuViewModel : BindableBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool isMenuExpanded { get; set; }

		public ICommand toggleMenu { get; set; }
		public ICommand dashboard { get; set; }
        public ICommand profile { get; set; }
        public ICommand friends { get; set; }
        public ICommand notifications { get; set; }
		public ICommand clothPiece { get; set; }
		public ICommand clothCombination { get; set; }

        public INavigationService navigation;

        public FloatingMenuViewModel(INavigationService navigationService = null)
        {
              isMenuExpanded = false;
              navigation = navigationService;

			  toggleMenu = new Command(onToggleMenu);
              dashboard = new Command(goToDashboard);
              profile = new Command(goToProfile);
              friends = new Command(goToFriends);
              notifications = new Command(goToNotification);
              clothPiece = new Command(goToClothPiece);
              clothCombination= new Command(goToClothCombination);
        }
            
        void onToggleMenu() {
            isMenuExpanded ^= true;
			PropertyChanged(this,new PropertyChangedEventArgs("isMenuExpanded"));
        }

        void goToNotification() {
          //  navigation.NavigateAsync(new Uri("http://www.StyleUs.com/NotificationPage", UriKind.Absolute));
        }
		void goToDashboard()
		{
            //navigation.NavigateAsync(new Uri("http://www.StyleUs.com/HomePage", UriKind.Absolute));

		}
		void goToClothCombination()
		{
            //navigation.NavigateAsync(new Uri("http://www.StyleUs.com/ClothCombinationPage", UriKind.Absolute));

		}
		void goToClothPiece()
		{
            //navigation.NavigateAsync(new Uri("http://www.StyleUs.com/ClothPiecePage", UriKind.Absolute));

		}
		void goToFriends()
		{
            //navigation.NavigateAsync(new Uri("http://www.StyleUs.com/FriendPage", UriKind.Absolute));
		}
		void goToProfile()
		{
            //navigation.NavigateAsync(new Uri("http://www.StyleUs.com/ProfilePage", UriKind.Absolute));
		}

    }
}
