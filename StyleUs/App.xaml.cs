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

            string navPage = "MenuPage";

            try {
                // AccountManager.SaveCredentials("Usernames123","Password456");
                if (AccountManager.UserName != null) {
                    navPage = "HomePage";
                }

            } catch(Exception e) {
                // No keychain :(
            }

            NavigationService.NavigateAsync(new Uri("/NavigationPage/" + navPage, UriKind.Absolute));
		}

		protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<View.Friend.FriendProfile, FriendProfileViewModel>();
            Container.RegisterTypeForNavigation<View.ClothPieces.SingleClothPiece, SingleClothPieceViewModel>();

            Container.RegisterTypeForNavigation<View.HomePage, HomePageViewModel>();
			      Container.RegisterTypeForNavigation<FriendPage, FriendViewModel>();
		        Container.RegisterTypeForNavigation<LoginPage, LoginPageViewModel>();
            Container.RegisterTypeForNavigation<ProfilePage, ProfileViewModel>();
            Container.RegisterTypeForNavigation<View.ClothPieces.NewClothPage>();
            Container.RegisterTypeForNavigation<View.Notification.NotificationList,ViewModel.Notification.NotificationListViewModel>();
            Container.RegisterTypeForNavigation<AddCommentPage, AddCommentPageViewModel>();
            Container.RegisterTypeForNavigation<ForgotPasswordPage,ForgotPasswordPageViewModel>();
            Container.RegisterTypeForNavigation<ClothCombinationPage, ClothCombinationViewModel>();
            Container.RegisterTypeForNavigation<RegisterStepOnePage, RegisterStepOnePageViewModel>();
            Container.RegisterTypeForNavigation<RegisterStepTwoPage, RegisterStepTwoPageViewModel>();
            Container.RegisterTypeForNavigation<AddCommentPage,AddCommentPageViewModel>();
            Container.RegisterTypeForNavigation<ViewComments,ViewCommentsViewModel>();
            Container.RegisterTypeForNavigation<AnswersPage,AnswersPageViewModel>();
            Container.RegisterTypeForNavigation<View.Users.FollowerLists, ViewModel.Users.FollowersListViewModel>();
            Container.RegisterTypeForNavigation<View.Users.FollowingLists, ViewModel.Users.FollowingListViewModel>();
            Container.RegisterTypeForNavigation<View.Menu, ViewModel.MenuViewModel>();
            Container.RegisterTypeForNavigation<View.AddPicturePost, AddPicturePostViewModel>();
            Container.RegisterTypeForNavigation<View.Comments, CommentsViewModel>();
            Container.RegisterTypeForNavigation<AddCameraButton, AddCameraButtonViewModel>();
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<MainTabbedPage>();
            Container.RegisterTypeForNavigation<AboutUsPage,AboutUsPageViewModel>();
            Container.RegisterTypeForNavigation<MenuPage,MenuPageViewModel>();
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
