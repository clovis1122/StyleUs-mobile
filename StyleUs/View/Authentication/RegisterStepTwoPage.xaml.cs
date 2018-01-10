using System;
using System.Collections.Generic;
using Prism.Events;

using Xamarin.Forms;

using StyleUs.ViewModel;

namespace StyleUs.View
{
    public partial class RegisterStepTwoPage : ContentPage
    {
        public class Alert {
            public string title { get; set; } = "";
            public string message { get; set; } = "";
            public string button { get; set; } = "Vale";
        }

        public RegisterStepTwoPage() { InitializeComponent(); }
        public RegisterStepTwoPage(IEventAggregator events)
        {
            InitializeComponent();

            events.GetEvent<Events.payload>().Subscribe(payload => {

                var resp = payload as Alert;
                
                showMessage(resp);
            });
        }

        private void showMessage(Alert alert) 
        {
            if (alert == null) return;

            DisplayAlert(alert.title, alert.message, alert.button);
        }
    }
}
