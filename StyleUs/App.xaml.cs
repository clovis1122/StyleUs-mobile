using System;

using Xamarin.Forms;

using Prism.Unity;
using Prism.Navigation;

using StyleUs.View;
using StyleUs.ViewModel;

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

            string navPage = "/NavigationPage/LoginPage";

            try {
                AccountManager.SaveCredentials("Usernames123","Password456");
                if (AccountManager.UserName != null) {
                    navPage = "/MainTabbedPage/HomePage";
                }

            } catch(Exception e) {
                // No keychain :(
                var du = "a";
            }
            NavigationService.NavigateAsync(new Uri(navPage, UriKind.Absolute));
		}

		protected override void RegisterTypes()

        {
            Container.RegisterTypeForNavigation<View.Friend.FriendProfile, FriendProfileViewModel>();
            Container.RegisterTypeForNavigation<View.ClothPieces.SingleClothPiece, SingleClothPieceViewModel>();

            Container.RegisterTypeForNavigation<View.HomePage, HomePageViewModel>("HomePage");
            Container.RegisterTypeForNavigation<FriendPage, FriendViewModel>("FriendPage");
            Container.RegisterTypeForNavigation<LoginPage, LoginPageViewModel>("LoginPage");
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
            Container.RegisterTypeForNavigation<MenuPage,MenuPageViewModel>("MenuPage");
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
