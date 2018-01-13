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
using System.Linq;
using StyleUs.Models;

namespace StyleUs.ViewModel {


    public class HomePageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Post> _PostList = new ObservableCollection<Post>();

        public ObservableCollection<Post> PostList {
            get { return _PostList; }
            set { _PostList = value; }
        }

        public ICommand OnLike { get; set; }
        public ICommand OnComment { get; set; }

        public INavigationService navigation;

        public HomePageViewModel(INavigationService navigationService)
        {
            navigation = navigationService;
            OnLike = new Command(OnLikePost);
            OnComment = new Command(OnCommentPost);

            fetchPosts();
        }

        public void OnLikePost(object _post) {
            var post = _post as Post;
            if (post == null) return;

        }

        public void OnCommentPost(object _post)
        {
            var post = _post as Post;
            if (post == null) return;

            navigation.NavigateAsync("Comments");
        }

        public event PropertyChangedEventHandler PropertyChanged;


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
