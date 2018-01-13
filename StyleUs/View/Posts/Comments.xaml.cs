using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace StyleUs.View
{
    public partial class Comments : ContentPage
    {
        void Handle_DescendantAdded(object sender, Xamarin.Forms.ElementEventArgs e)
        {
            throw new NotImplementedException();
        }

        public Comments()
        {
            InitializeComponent();
            //BindingContext = new StyleUs.ViewModel.CommentsViewModel();
        }
    }
}
