using System;
using System.Collections.Generic;

using Xamarin.Forms;

using StyleUs.ViewModel;

namespace StyleUs.View
{
    public partial class RegisterStepTwoPage : ContentPage
    {
        void onCreate(object sender, System.EventArgs e)
        {
            DisplayAlert("Bien!", "Has completado el proceso de registro de StyleUs", "Aceptar");
        }

        public RegisterStepTwoPage()
        {
            InitializeComponent();
        }
    }
}
