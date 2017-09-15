using System;

using System.ComponentModel;
using System.Windows.Input;

using Xamarin.Forms;

using StyleUs.View;
using Prism.Navigation;
using Prism.Commands;

namespace StyleUs.ViewModel
{
    public class FloatingMenuViewModel
    {
        bool isMenuExpanded {get; set; } = false;

		public ICommand toggleMenu { get; set; }
        
        public FloatingMenuViewModel()
        {
            toggleMenu = new Command(onToggleMenu);
        }

        void onToggleMenu() {
            isMenuExpanded ^= true;
        }

    }
}
