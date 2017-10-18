using System;

using Xamarin.Forms;

using StyleUs.ViewModel;
using Prism.Events;
using System.Threading.Tasks;

namespace StyleUs.View
{
    public partial class LoginPage : ContentPage
    {

        public LoginPage(){ InitializeComponent(); }
        public LoginPage(IEventAggregator events)
        {
            InitializeComponent();

            startAnimation();

            events.GetEvent<Events.onLoginEvent>().Subscribe(start => onLogin(start));
            events.GetEvent<Events.displayMessage>().Subscribe(message => {
                DisplayAlert("¡Error!",message,"Vale");
            });
        }

        public async void startAnimation() 
        {

            // Title animation.

            await Task.Delay(2000);

            title.Animate(
                name: "colorchange",
                animation: new Animation((val) =>
                {
                    var newValue = (int)(255 * (1 - (val * 0.5)));
                    var newColor = Color.FromRgb(newValue, newValue, newValue);
                    title.FormattedText.Spans[0].ForegroundColor = newColor;
                }),
                length: 1500,
                repeat: () => { return false; }
            );

            await title.TranslateTo(0, -150,1500);

            pageWrapper.FadeTo(0, 2000);
            content.FadeTo(1, 2000);

        }

        public async void onLoginStartAnimation() 
        {
            await content.FadeTo(0,1000);
            await title.TranslateTo(0, 100, 1000);
        }

        public async void onLoginEndAnimation()
        {
            await content.FadeTo(1, 1000);
            await title.TranslateTo(0, -150, 1000);
        }


        public void onLogin(bool start) {
            if (start) {
                onLoginStartAnimation();
                return;
            }
            onLoginEndAnimation();
            return;
        }
    }
}
