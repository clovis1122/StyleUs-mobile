using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using Microsoft.Practices.Unity;
using Prism.Unity;
using UIKit;
using FFImageLoading.Forms.Touch;
using FFImageLoading.Forms;
using FFImageLoading.Transformations;
using Xamarin.Auth;

namespace StyleUs.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
            global::Xamarin.Forms.Forms.Init();
            CachedImageRenderer.Init();

            AccountManager.manager = AccountStore.Create();

			LoadApplication(new App(new iOSInitializer()));

            var ignore = new CircleTransformation();

			return base.FinishedLaunching(app, options);
		}

		public class iOSInitializer : IPlatformInitializer
		{
			public void RegisterTypes(IUnityContainer container)
			{

			}
		}
	}
}