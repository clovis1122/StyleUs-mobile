using System;
using System.Collections.Generic;
using Prism.Events;

using Xamarin.Forms;

using StyleUs.ViewModel;

namespace StyleUs.View
{
    public partial class RegisterStepTwoPage : ContentPage
    {
        public RegisterStepTwoPage() { InitializeComponent(); }
        public RegisterStepTwoPage(IEventAggregator events)
        {
            try {
            InitializeComponent();
            } catch(Exception ex) {
                var du = ex.Message;
            }
            events.GetEvent<Events.displayMessage>().Subscribe(message => {
                DisplayAlert("¡Error!", message, "Vale");
            });
        }
    }
}
