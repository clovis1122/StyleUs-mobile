using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using StyleUs.View;
using StyleUs.ViewModel;

namespace StyleUs.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        void notYet(object sender, System.EventArgs e)
        {
            DisplayAlert("Lo sentimos!", "Todavia no se ha implementado esta funcionalidad.", "Aceptar");
        }

        public Login()
        {
            InitializeComponent();

            var viewModel = new LoginViewModel();
            viewModel.navigation = Navigation;
            BindingContext = viewModel;


        }
    }
}
