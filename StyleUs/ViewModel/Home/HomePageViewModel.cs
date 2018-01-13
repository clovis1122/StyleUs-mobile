using System;

using System.ComponentModel;
using System.Windows.Input;

using Xamarin.Forms;

using StyleUs.View;
using Prism.Navigation;
using Prism.Commands;
using StyleUs.ViewModel.Component;
using System.Collections.ObjectModel;
using StyleUs.Models;
using StyleUs.Services;
using System.Collections.Generic;

namespace StyleUs.ViewModel {


    public class HomePageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Post> _PostList = new ObservableCollection<Post>();
        public Boolean hasLike = false;
        public String LikeIcon { get; set; }


        public ObservableCollection<Post> PostList {
            get { return _PostList; }
            set { _PostList = value; }
        }


        public ICommand AddCommentView { get; set; }
        public ICommand SeeCommentView { get; set; }
        public ICommand LikeComment { get; set; }

        public INavigationService navigation;

        public HomePageViewModel(INavigationService navigationService)
        {
            navigation = navigationService;
            AddCommentView = new Command(GoToAddComment);
            SeeCommentView = new Command(GoToSeeComment);
            LikeComment = new Command(ChangeLikeIcon);
            LikeIcon = "heart_dark.png";

            fetchPosts();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void ChangeLikeIcon()
        {
            
            hasLike = !hasLike;
            LikeIcon = hasLike ? "heart_red.png" : "heart_dark.png";
        }

        public void GoToAddComment()
        {
            navigation.NavigateAsync("AddCommentPage");
        }

        public void GoToSeeComment()
        {
            navigation.NavigateAsync("Comments");
        }

        public async void fetchPosts() 
        {
            //try
            //{
            //    var posts = await PostServices.fetchPosts();

            //    if (posts.Key)
            //    {
            //        PostList = new ObservableCollection<Post>(posts.Value as List<Post>);
            //    }
            //}
            //catch (Exception e)
            //{
                for (int i = 0; i < 5; i++)
                {
                    var post = new Post();
                    var user = new User();

                    user.first_name = "Juan";
                    user.last_name = "Perez";
                    user.email = "dududu@chamuel.co";
                    user.image = "icon1.png";

                    post.body = "Prueba";
                    post.image = "icon1.png";
                    post.comments_count = 5;
                    post.like_count = 5;
                    post.id = 1;
                    post.user = user;

                    PostList.Add(post);
                }
            //}
        }

    }
}
