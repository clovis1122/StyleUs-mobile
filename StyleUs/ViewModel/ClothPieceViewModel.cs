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
    public class ClothPieceViewModel
    {
        public FloatingMenuViewModel MenuViewModel { get; set; }

        public ClothPieceViewModel(INavigationService navigationService)
        {
            MenuViewModel = new FloatingMenuViewModel(navigationService);
        }
    }
}
