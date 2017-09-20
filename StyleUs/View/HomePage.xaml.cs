using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace StyleUs.View
{
    public partial class HomePage : ContentPage
    {
        void goToProfile(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new ProfilePage());
        }
		void goToNotification(object sender, System.EventArgs e)
		{
			Navigation.PushAsync(new ProfilePage());
		}

        public HomePage()
        {
            InitializeComponent();
        }
    }
}
