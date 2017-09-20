using System;
using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace StyleUs.View.Component
{

    /*
     * TODO:
     * 1. Add icons inside the circles
     * 2. Change hardcoded values to be responsive to the device's screen.
     */
    public partial class FloatingMenu : ContentView
    {
        public FloatingMenu()
		{
			InitializeComponent();
		}

		void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
		{
			SKImageInfo info = args.Info;
			SKSurface surface = args.Surface;
			SKCanvas canvas = surface.Canvas;

			canvas.Clear();

			// Colors

			// var black = Color.FromRgb(0, 0, 0).ToSKColor();
			var lightGray = Color.FromRgb(239, 239, 239).ToSKColor();
			var darkGray = Color.FromRgb(153, 153, 153).ToSKColor();

			SKPaint paint = new SKPaint
			{
				Style = SKPaintStyle.Stroke,
				Color = lightGray,
				StrokeWidth = 10
			};

            //TODO: Draw a plus (+) inside the circle...

			//int x0 = (info.Height / 2) - 50;
			//int x1 = (info.Height / 2) - 45;
			//int xm = (x0 + x1) / 2;

			//int y0 = (info.Width / 2) - 50;
			//int y1 = (info.Width / 2) - 45;
			//int ym = (x0 + x1) / 2;

			canvas.DrawCircle(info.Width / 2, info.Height / 2, 30, paint);

			//paint.Color = black;
			//canvas.DrawLine(xm,y0,xm,y1,paint);
			//canvas.DrawLine(x0,ym,x1,ym,paint);

			paint.Style = SKPaintStyle.Fill;
			paint.Color = darkGray;
			canvas.DrawCircle(info.Width / 2, info.Height / 2, 30, paint);
		}

        void drawMainButton() {
            
        }

        void drawButton(int x, int y, SKPaint paint) {
            
        }

	}
}
