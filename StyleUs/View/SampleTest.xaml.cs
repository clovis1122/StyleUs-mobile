using System;
using System.Collections.Generic;

using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace StyleUs.View
{
    public partial class SampleTest : ContentPage
    {
        void Handle_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
			SKImageInfo info = e.Info;
			SKSurface surface = e.Surface;
			SKCanvas canvas = surface.Canvas;

			canvas.Clear();

			SKPaint paint = new SKPaint
			{
				Style = SKPaintStyle.Stroke,
				Color = Color.Red.ToSKColor(),
				StrokeWidth = 50
			};
			canvas.DrawCircle(info.Width / 2, info.Height / 2, 100, paint);
        }

        public SampleTest()
        {
            InitializeComponent();
        }
    }
}
