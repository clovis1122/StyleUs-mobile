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


namespace StyleUs.ViewModel {


    public class HomePageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public ObservableCollection<HomePostViewModel> _PostList = new ObservableCollection<HomePostViewModel>();

        public ObservableCollection<HomePostViewModel> PostList {
            get { return _PostList; }
            set { _PostList = value; }
        }

        public INavigationService navigation;

        public HomePageViewModel(INavigationService navigationService)
        {
            navigation = navigationService;

            fetchPosts();
        }

        public event PropertyChangedEventHandler PropertyChanged;


        public async void fetchPosts() 
        {
            PostList.Clear();
            try
            {
                var posts = await PostServices.fetchPosts();
                PostList.Clear();

                if (posts.Key)
                {
                    var postList = posts.Value as List<Post>;

                    foreach(var post in postList) {
                        PostList.Add(new HomePostViewModel(navigation)
                        {
                            Post = post
                        });
                    }
                }
            }
            catch (Exception e)
            {
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
                    post.comments = new List<Comment>();
                    post.likes_count = 5;
                    post.id = 1;
                    post.user = user;

                    PostList.Add(new HomePostViewModel(navigation) {
                        Post = post
                    });
                }
            }
        }

        // INavigationAware
        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            // When you navigate away from this page
        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            // Reload the posts when the user navigates again to this screen.
            fetchPosts();
        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

    }
}
