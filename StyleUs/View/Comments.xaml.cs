using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace StyleUs.View
{
    public partial class Comments : ContentPage
    {
        public Comments()
        {
            InitializeComponent();
            BindingContext = new StyleUs.ViewModel.CommentsViewModel();
        }
    }
}
