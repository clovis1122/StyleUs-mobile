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

        public FloatingMenuViewModel()
        {
            isMenuExpanded = false;
            toggleMenu = new Command(onToggleMenu);
        }

        void onToggleMenu() {
            isMenuExpanded ^= true;
			PropertyChanged(this,new PropertyChangedEventArgs("isMenuExpanded"));
        }

        void goToNotification() {
            
        }
		void goToProfile()
		{

		}

    }
}
