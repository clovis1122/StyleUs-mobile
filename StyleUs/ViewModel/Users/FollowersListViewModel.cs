using System;

using StyleUs.Services;
using StyleUs.Models;

using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using Prism.Commands;

namespace StyleUs.ViewModel.Users
{
    public class FollowersListViewModel : INotifyPropertyChanged
    {

        public DelegateCommand back { get; set; }
        public ObservableCollection<User> _followerList = new ObservableCollection<User>();


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

        public FollowersListViewModel()
        {
            loadUsers();
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
