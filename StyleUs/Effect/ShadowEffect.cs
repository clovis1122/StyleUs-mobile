using Xamarin.Forms;

namespace StyleUs.Effect
{
	public class ShadowEffect : RoutingEffect
	{
		public float Radius { get; set; }

		public Color Color { get; set; }

		public float DistanceX { get; set; }

		public float DistanceY { get; set; }

        public ShadowEffect() : base($"StyleUs.Effect.{nameof(ShadowEffect)}")
		{
            var e = Xamarin.Forms.Effect.Resolve($"StyleUs.Effect.{nameof(ShadowEffect)}");
            var f = $"StyleUs.Effect.{nameof(ShadowEffect)}";
		}
	}
}