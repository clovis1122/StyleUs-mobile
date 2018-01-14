using System.ComponentModel;
using System.Windows.Input;
using Prism.Navigation;
using StyleUs.Models;
using Xamarin.Forms;

namespace StyleUs.ViewModel
{

    public class HomePostViewModel : INotifyPropertyChanged
    {
        public Post Post { get; set; }

        public ICommand OnLike { get; set; }
        public ICommand OnComment { get; set; }

        public INavigationService navigation;

        public event PropertyChangedEventHandler PropertyChanged;

        public HomePostViewModel(INavigationService navigationService)
        {
            navigation = navigationService;

            OnLike = new Command(OnLikePost);
            OnComment = new Command(OnCommentPost);
        }

        public void OnLikePost()
        {
            // Mark as liked, adds 1 to the counter.
            Post.is_liked = !Post.is_liked;
            Post.like_count += Post.is_liked ? 1 : -1;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Post"));
        }

        public void OnCommentPost()
        {
            navigation.NavigateAsync("Comments");
        }
    }
}
