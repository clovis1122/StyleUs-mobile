using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using StyleUs.View;
using StyleUs.ViewModel;

namespace StyleUs.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterStepOnePage : ContentPage
    {
        public RegisterStepOnePage()
        {
            NavigationPage.SetHasBackButton(this, false);
           InitializeComponent();
        }
    }
}
