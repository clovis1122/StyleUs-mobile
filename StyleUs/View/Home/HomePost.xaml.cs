using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Prism.Behaviors;
using Xamarin.Forms;

namespace StyleUs.View.Home
{
    public partial class HomePost : ViewCell, INotifyPropertyChanged
    {
        // Bindable properties
        public static readonly BindableProperty OnLikeProperty =
            BindableProperty.Create("OnLike", typeof(ICommand), typeof(HomePost), null);
        public static readonly BindableProperty OnCommentProperty =
            BindableProperty.Create("OnComment", typeof(ICommand), typeof(HomePost), null);
        
        // Accessor for bindable properties.
        public ICommand OnLike
        {
            get { return (ICommand)GetValue(OnLikeProperty); }
            set { SetValue(OnLikeProperty, value); }
        }
        public ICommand OnComment
        {
            get { return (ICommand)GetValue(OnCommentProperty); }
            set { SetValue(OnCommentProperty, value); }
        }

        // Constructor
        public HomePost()
        {
            InitializeComponent();
        }

        // Events
        public void OnLikePost(object sender, EventArgs args)
        {
            var post = BindingContext as StyleUs.Models.Post;

            if (post == null || !OnLike.CanExecute(post)) return;

            OnLike.Execute(post);
        }
        public void OnCommentPost(object sender, EventArgs args)
        {
            var post = BindingContext as StyleUs.Models.Post;

            if (post == null || !OnComment.CanExecute(post)) return;

            OnComment.Execute(post);
        }
    }
}
