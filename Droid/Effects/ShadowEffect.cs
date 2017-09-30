using System;
using System.Linq;
using BaseEffect = StyleUs.Effect;
using StyleUs.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(ShadowEffect), nameof(ShadowEffect))]

namespace StyleUs.Droid
{
	public class ShadowEffect : PlatformEffect
	{
		protected override void OnAttached ()
		{
			try {
				var control = Control as Android.Widget.TextView;
				var effect = (StyleUs.Effect.ShadowEffect)Element.Effects.FirstOrDefault (e => e is StyleUs.Effect.ShadowEffect);
				if (effect != null) {
					float radius = effect.Radius;
					float distanceX = effect.DistanceX;
					float distanceY = effect.DistanceY;
					Android.Graphics.Color color = effect.Color.ToAndroid ();
					control.SetShadowLayer (radius, distanceX, distanceY, color);
				}
			} catch (Exception ex) {
				Console.WriteLine ("Cannot set property on attached control. Error: ", ex.Message);
			}
		}

		protected override void OnDetached ()
		{
		}
	}
}
