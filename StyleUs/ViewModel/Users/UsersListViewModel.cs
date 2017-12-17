using System;

using StyleUs.Services;
using StyleUs.Models;

using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;

namespace StyleUs.ViewModel.Users
{
    public class UsersListViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<User> _userList = new ObservableCollection<User>();
        public ObservableCollection<User> userList
        {
            get
            {
                return _userList;
            }
            set
            {
                _userList = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public UsersListViewModel()
        {
            loadUsers();
        }

        public async void loadUsers() {
            var du = await UserServices.get();

            if (du.Key) {
                userList = new ObservableCollection<User>(du.Value as List<User>);
            }

        }
    }
}
