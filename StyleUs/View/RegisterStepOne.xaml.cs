using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using StyleUs.View;
using StyleUs.ViewModel;

namespace StyleUs.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterStepOne : ContentPage
    {
        public RegisterStepOne()
        {
           // InitializeComponent();

            var viewModel = new RegisterStepOneViewModel();
			viewModel.navigation = Navigation;
			BindingContext = viewModel;
        }
    }
}
