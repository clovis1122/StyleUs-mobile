using System;

using StyleUs.Services;
using StyleUs.Models;

using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using Prism.Commands;
using Prism.Events;
using Prism.Navigation;

namespace StyleUs.ViewModel.Users
{
    public class FollowersListViewModel : INotifyPropertyChanged
    {

        public DelegateCommand back { get; set; }
        public ObservableCollection<User> _followerList = new ObservableCollection<User>();
        INavigationService navigation;
        IEventAggregator events;

        public ObservableCollection<User> followerList
        {
            get
            {
                return _followerList;
            }
            set
            {
                _followerList = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public FollowersListViewModel(INavigationService navigationService, IEventAggregator eventAgregator )
        {
            navigation = navigationService;
            events = eventAgregator;

            loadUsers();
            back = new DelegateCommand(OnBackClick);
        }


        public void OnBackClick()
        {
            navigation.GoBackAsync();
        }


        public async void loadUsers() {
            try {
                var du = await UserServices.get();

                if (du.Key)
                {
                    followerList = new ObservableCollection<User>(du.Value as List<User>);
                }
            } catch {
                for (int i = 0; i < 5; i++)
                {
                    var du = new StyleUs.Models.User();
                    du.first_name = "Juan";
                    du.last_name = "Perez";
                    du.email = "dududu@chamuel.co";
                    du.image = "icon1.png";
                    followerList.Add(du);
                }
            }
        }
    }
}
