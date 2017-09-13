using System;

using Xamarin.Forms;

using StyleUs.ViewModel;
using Prism.Events;

namespace StyleUs.View
{
    public partial class Login : ContentPage
    {
		void notYet(object sender, System.EventArgs e)
		{
			DisplayAlert("Lo sentimos!", "Todavia no se ha implementado esta funcionalidad.", "Aceptar");
		}

        public Login()
        {
            InitializeComponent();
        }
    }
}
