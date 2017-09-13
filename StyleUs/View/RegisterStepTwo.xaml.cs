using System;
using System.Collections.Generic;

using Xamarin.Forms;

using StyleUs.ViewModel;

namespace StyleUs.View
{
    public partial class RegisterStepTwo : ContentPage
    {
        void onCreate(object sender, System.EventArgs e)
        {
            DisplayAlert("Bien!", "Has completado el proceso de registro de StyleUs", "Aceptar");
            Navigation.PopToRootAsync();
        }

        public RegisterStepTwo()
        {
            // InitializeComponent();

			var viewModel = new RegisterStepTwoViewModel();
			viewModel.navigation = Navigation;
			BindingContext = viewModel;
        }
    }
}
