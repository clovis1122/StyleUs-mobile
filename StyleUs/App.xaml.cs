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
		public App()
		{
    		InitializeComponent();
		}

        public App(IPlatformInitializer initializer = null) : base(initializer) {
            InitializeComponent();
        }

        protected override void OnInitialized(){
			InitializeComponent();

            NavigationService.NavigateAsync("LoginPage");
		}

		protected override void RegisterTypes()
		{
            Container.RegisterTypeForNavigation<HomePage, HomePageViewModel>();
			Container.RegisterTypeForNavigation<FriendPage, FriendViewModel>();
			Container.RegisterTypeForNavigation<LoginPage, LoginPageViewModel>();
            Container.RegisterTypeForNavigation<ProfilePage, ProfileViewModel>();
            Container.RegisterTypeForNavigation<ClothPiecePage, ClothPieceViewModel>();
            Container.RegisterTypeForNavigation<NotificationPage, NotificationViewModel>();
            Container.RegisterTypeForNavigation<ForgotPasswordPage,ForgotPasswordPageViewModel>();
            Container.RegisterTypeForNavigation<ClothCombinationPage, ClothCombinationViewModel>();
            Container.RegisterTypeForNavigation<RegisterStepOnePage, RegisterStepOnePageViewModel>();
            Container.RegisterTypeForNavigation<RegisterStepTwoPage, RegisterStepTwoPageViewModel>();
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