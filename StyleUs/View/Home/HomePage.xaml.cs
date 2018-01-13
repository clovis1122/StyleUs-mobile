using System;
using System.Collections.Generic;

using Xamarin.Forms;
using StyleUs.ViewModel;

namespace StyleUs.View
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
          InitializeComponent();
        }

        /// <summary>
        ///  Fired one the comments are tapped. This leads to the comments page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public void OnTapGestureRecognizerTapped(object sender, EventArgs args) {
            HomePageViewModel vm = BindingContext as HomePageViewModel;

            //Call command from viewmodel     
            if ((vm != null) && (vm.SeeCommentView.CanExecute(null)))
                vm.SeeCommentView.Execute(null);
        }

        public void OnTapGestureRecognizerLike(object sender, EventArgs args)
        {
            HomePageViewModel vm = BindingContext as HomePageViewModel;

            //Call command from viewmodel     
            if ((vm != null) && (vm.LikeComment.CanExecute(null)))
                vm.LikeComment.Execute(null);
        }
    }
}
