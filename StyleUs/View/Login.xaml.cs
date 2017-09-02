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
        public Login()
        {
            InitializeComponent();

            var viewModel = new LoginViewModel();
            viewModel.navigation = Navigation;
            BindingContext = viewModel;


        }
    }
}
