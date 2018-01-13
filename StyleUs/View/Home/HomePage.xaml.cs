using System;
using System.Collections.Generic;

using Xamarin.Forms;
using StyleUs.ViewModel;
using System.Windows.Input;

namespace StyleUs.View
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            try {
                InitializeComponent();
            } catch(Exception e) {
                var du = e;
            }
        }
    }
}
