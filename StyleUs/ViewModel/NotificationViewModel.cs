﻿using System;

using System.ComponentModel;
using System.Windows.Input;

using Xamarin.Forms;

using StyleUs.View;
using Prism.Navigation;
using Prism.Commands;
using StyleUs.ViewModel.Component;

namespace StyleUs.ViewModel
{
    public class NotificationViewModel
    {
        public FloatingMenuViewModel MenuViewModel { get; set; }

        public NotificationViewModel(INavigationService navigationService)
        {
            MenuViewModel = new FloatingMenuViewModel(navigationService);
        }
    }
}
