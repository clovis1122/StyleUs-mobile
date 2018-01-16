using Android.App;
using Android.Content.PM;
using Android.OS;
using Microsoft.Practices.Unity;
using Plugin.Permissions;
using Prism.Unity;
using Xamarin.Auth;

namespace StyleUs.Droid {
    [Activity(Label = "StyleUs", Icon = "@drawable/appIcon", Theme = "@style/splashscreen", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

            AccountManager.manager = AccountStore.Create(this);

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);

			LoadApplication(new App(new AndroidInitializer()));

		}

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
        {
            PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

		public class AndroidInitializer : IPlatformInitializer
		{
			public void RegisterTypes(IUnityContainer container)
			{

			}
		}
	}
}
