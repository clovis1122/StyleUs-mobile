using System;

using Xamarin.Forms;

using Prism.Unity;
using Prism.Navigation;

using StyleUs.View;
using StyleUs.ViewModel;
using StyleUs.View.Users;

namespace StyleUs
{
	public partial class App : PrismApplication
	{
        public static string AppName { get { return "TodoListApp"; } }

		    public App()
		    {
	    		InitializeComponent();
		    }

        public App(IPlatformInitializer initializer = null) : base(initializer) {
            InitializeComponent();
        }

        protected override void OnInitialized(){

			InitializeComponent();

            string navPage = "/NavigationPage/Login";

            // TODO: this is insecure.

            if (Application.Current.Properties.ContainsKey("token")) {
                navPage = "/MainTabbedPage/HomePage";
            }

            // navPage = "/MainTabbedPage/Comments";

            //Application.Current.Properties["token"] = "123";
            //Application.Current.SavePropertiesAsync();

            NavigationService.NavigateAsync(new Uri(navPage, UriKind.Absolute));
		}

		protected override void RegisterTypes()

        {
            Container.RegisterTypeForNavigation<View.Friend.FriendProfile, FriendProfileViewModel>();
            Container.RegisterTypeForNavigation<View.ClothPieces.SingleClothPiece, SingleClothPieceViewModel>();

            Container.RegisterTypeForNavigation<View.HomePage, HomePageViewModel>("HomePage");
            Container.RegisterTypeForNavigation<FriendPage, FriendViewModel>("FriendPage");
            Container.RegisterTypeForNavigation<LoginPage, LoginPageViewModel>("Login");
            Container.RegisterTypeForNavigation<View.ProfilePage, ViewModel.ProfileViewModel>("ProfilePage");
            Container.RegisterTypeForNavigation<ProfilePage, ProfileViewModel>("ProfilePage");
            Container.RegisterTypeForNavigation<View.ClothPieces.NewClothPage,ViewModel.ClothPieceViewModel>("ClothPieces");
            Container.RegisterTypeForNavigation<View.Notification.NotificationList,ViewModel.Notification.NotificationListViewModel>("NotificationList");
            Container.RegisterTypeForNavigation<AddCommentPage, AddCommentPageViewModel>();
            Container.RegisterTypeForNavigation<ForgotPasswordPage,ForgotPasswordPageViewModel>("ForgotPasswordPage");
            Container.RegisterTypeForNavigation<ClothCombinationPage, ClothCombinationViewModel>("ClothCombinationPage");
            Container.RegisterTypeForNavigation<RegisterStepOnePage, RegisterStepOnePageViewModel>();
            Container.RegisterTypeForNavigation<RegisterStepTwoPage, RegisterStepTwoPageViewModel>();
            Container.RegisterTypeForNavigation<AddCommentPage,AddCommentPageViewModel>();
            Container.RegisterTypeForNavigation<ViewComments,ViewCommentsViewModel>();
            Container.RegisterTypeForNavigation<AnswersPage,AnswersPageViewModel>();
            Container.RegisterTypeForNavigation<View.Users.FollowerLists, ViewModel.Users.FollowersListViewModel>("FollowerLists");
            Container.RegisterTypeForNavigation<View.Users.FollowingLists, ViewModel.Users.FollowingListViewModel>("FollowingLists");
            Container.RegisterTypeForNavigation<View.AddPicturePost, AddPicturePostViewModel>("AddPicturePost");
            Container.RegisterTypeForNavigation<View.Comments, CommentsViewModel>("Comments");
            Container.RegisterTypeForNavigation<AddCameraButton, AddCameraButtonViewModel>("AddCameraButton");
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainTabbedPage>();
            Container.RegisterTypeForNavigation<AboutUsPage,AboutUsPageViewModel>("AboutUsPage");
            Container.RegisterTypeForNavigation<View.Menu,MenuPageViewModel>("MenuPage");
            Container.RegisterTypeForNavigation<View.ShowProfilePage,ShowProfilePageViewModel>("ShowProfilePage");
            Container.RegisterTypeForNavigation<View.EditProfilePage, ViewModel.EditProfilePageViewModel>("EditProfilePage");
            Container.RegisterTypeForNavigation<View.Users.FollowerListsProfile, ViewModel.Users.FollowersListViewModel >("FollowerListsProfile");
        }

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
