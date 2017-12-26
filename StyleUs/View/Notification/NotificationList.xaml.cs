using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace StyleUs.View.Notification
{
    public partial class NotificationList : ContentPage
    {
        public NotificationList()
        {
            InitializeComponent();
            BindingContext = new StyleUs.ViewModel.Notification.NotificationListViewModel();
           
        }
    }
}
