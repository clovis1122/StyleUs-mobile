using System;

using StyleUs.Services;
using StyleUs.Models;

using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;

namespace StyleUs.ViewModel.Notification
{
    public class NotificationListViewModel : INotifyPropertyChanged
    {

        public ObservableCollection<StyleUs.Models.Notification> _notificationList = new ObservableCollection<StyleUs.Models.Notification>();
        public ObservableCollection<StyleUs.Models.Notification> notificationList
        {
            get
            {
                return _notificationList;
            }
            set
            {
                _notificationList = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public NotificationListViewModel()
        {
            for (int i = 0; i < 20; i++)
            {
                var du = new StyleUs.Models.Notification();
                du.title = "Notificacion " + (i+1);
                du.detail = "Detalle de notificacion numero " + i;
                du.img = "Unknown.jpg";
                notificationList.Add(du);

            }
        }

        public async void loadNotification(){
            var du = await StyleUs.Services.NotificationServices.get();

            if (du.Key){
                notificationList = new ObservableCollection<StyleUs.Models.Notification>(du.Value as List<StyleUs.Models.Notification>);
            }
        }
    }
}
