using System;
using System.Linq;
using CoreGraphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using BaseEffect = StyleUs.Effect.ShadowEffect;
using StyleUs.iOS;

[assembly: ExportEffect (typeof(ShadowEffect), nameof(ShadowEffect))]
namespace StyleUs.iOS
{
	public class ShadowEffect : PlatformEffect
	{
		protected override void OnAttached ()
		{
			try {
				var effect = (BaseEffect)Element.Effects.FirstOrDefault (e => e is BaseEffect);
				if (effect != null) {
					Control.Layer.CornerRadius = effect.Radius;
					Control.Layer.ShadowColor = effect.Color.ToCGColor ();
					Control.Layer.ShadowOffset = new CGSize (effect.DistanceX, effect.DistanceY);
					Control.Layer.ShadowOpacity = 1.0f;
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
