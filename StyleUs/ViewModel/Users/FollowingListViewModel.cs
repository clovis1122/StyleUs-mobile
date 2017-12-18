using System;

using StyleUs.Services;
using StyleUs.Models;

using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;

namespace StyleUs.ViewModel.Users
{
    public class FollowingListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<User> _followingList = new ObservableCollection<User>();
        public ObservableCollection<User> followingList
        {
            get
            {
                return _followingList;
            }
            set
            {
                _followingList = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public FollowingListViewModel()
        {
            for (int i = 0; i < 5; i++) {
                var du = new StyleUs.Models.User();
                du.first_name = "Juan";
                du.last_name = "Perez";
                du.email = "dududu@chamuel.co";
                du.image = "https://freerangestock.com/thumbnail/27083/steampunk-woman-tips-hat.jpg";
                followingList.Add(du);
            }
        }

        public async void loadUsers() {
            var du = await UserServices.get();

            if (du.Key) {
                followingList = new ObservableCollection<User>(du.Value as List<User>);
            }

        }
    }
}
