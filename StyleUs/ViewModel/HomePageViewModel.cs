using System;

using System.ComponentModel;
using System.Windows.Input;

using Xamarin.Forms;

using StyleUs.View;
using Prism.Navigation;
using Prism.Commands;
using StyleUs.ViewModel.Component;
using System.Collections.ObjectModel;

namespace StyleUs.ViewModel { 
    public class HomePage
    {
        public string  UserName { get; set; }
        public string  TimePost { get; set; }
        public ImageSource ProfileImage { get; set; }
        public ImageSource ImagePost { get; set; }
        public string Description { get; set; }
        public string CommentQuantity { get; set; }
        public string LikesQuantity { get; set; }

        public HomePage(string username, int timePost, string profileImage, string description,string postImage,int commentQuantity, int likesQuantity)
        {
            this.UserName = username;
            this.TimePost = timePost.ToString() + "h";
            this.ProfileImage = ImageSource.FromUri(new Uri(profileImage));
            this.ImagePost = ImageSource.FromUri(new Uri(postImage));
            this.Description = description;
            this.CommentQuantity = commentQuantity.ToString();
            this.LikesQuantity = likesQuantity.ToString();
        }

    }
       
    public class HomePageViewModel
    {
        public ObservableCollection<HomePage> _postList = new ObservableCollection<HomePage>();
        public ObservableCollection<HomePage> PostList

        {
            get
            {
                return _postList;
            }

            set
            {
                _postList = value;
            }
        }
        public FloatingMenuViewModel MenuViewModel { get; set; }
        public ICommand AddCommentView { get; set; }
        public ICommand SeeCommentView { get; set; }
        public INavigationService navigation;

        public HomePageViewModel(INavigationService navigationService)
        {
            MenuViewModel = new FloatingMenuViewModel(navigationService);
            navigation = navigationService;
            AddCommentView = new Command(GoToAddComment);
            SeeCommentView = new Command(GoToSeeComment);

            PostList.Add(new HomePage("Andrea Polanco", 1, "https://freerangestock.com/thumbnail/27083/steampunk-woman-tips-hat.jpg", "Esta pieza se trata de un look expectacular", "https://freerangestock.com/thumbnail/22170/woman-poses-in-parking-garage.jpg", 28,12));
            PostList.Add(new HomePage("Chamuel Castillo", 5, "https://freerangestock.com/thumbnail/27083/steampunk-woman-tips-hat.jpg", "Traje del verano. Tu mejor estilo", "https://cdn.pixabay.com/photo/2017/08/10/08/00/suit-2619784__340.jpg", 28,10));
            PostList.Add(new HomePage("Adeury Camilo",11, "https://freerangestock.com/thumbnail/29604/outdoor-model-photography-.jpg", "Esta pieza se trata de un look expectacular", "https://freerangestock.com/thumbnail/22170/woman-poses-in-parking-garage.jpg", 28,14));
            PostList.Add(new HomePage("Clovis Ramirez", 15, "https://freerangestock.com/thumbnail/27083/steampunk-woman-tips-hat.jpg", "Esta pieza se trata de un look expectacular", "https://freerangestock.com/thumbnail/22170/woman-poses-in-parking-garage.jpg", 28,9));
        }

        public HomePageViewModel()
        {
        }

        public void GoToAddComment()
        {
            navigation.NavigateAsync("AddCommentPage");
        }

        public void GoToSeeComment()
        {
            navigation.NavigateAsync("ViewComments");
        }
        
    }
}
