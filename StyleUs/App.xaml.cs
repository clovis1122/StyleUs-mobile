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

            NavigationService.NavigateAsync("Login");
		}

		protected override void RegisterTypes()
		{
			Container.RegisterTypeForNavigation<Login, LoginViewModel>();
            Container.RegisterTypeForNavigation<ForgotPassword,ForgotPasswordViewModel>();
            Container.RegisterTypeForNavigation<RegisterStepOne,RegisterStepOneViewModel>();
            Container.RegisterTypeForNavigation<RegisterStepTwo,RegisterStepTwoViewModel>();
            Container.RegisterTypeForNavigation<HomePage>();
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