using System;
using Xamarin.Forms;

using SkiaSharp;
using SkiaSharp.Views.Forms;
using SkiaSharp.Extended.Iconify;

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
            
            (menuList.Children[0] as SKCanvasView).PaintSurface += ((object sender, SKPaintSurfaceEventArgs args) =>
            {
                OnCanvasViewPaintSurface(args, "mdi-bell-outline");
            });
            (menuList.Children[1] as SKCanvasView).PaintSurface += ((object sender, SKPaintSurfaceEventArgs args) =>
            {
                OnCanvasViewPaintSurface(args, "mdi-view-dashboard");
            });
            (menuList.Children[2] as SKCanvasView).PaintSurface += ((object sender, SKPaintSurfaceEventArgs args) =>
            {
                OnCanvasViewPaintSurface(args, "mdi-tshirt-v");
            });
            (menuList.Children[3] as SKCanvasView).PaintSurface += ((object sender, SKPaintSurfaceEventArgs args) =>
            {
                OnCanvasViewPaintSurface(args, "mdi-plus-circle");
            });
            (menuList.Children[4] as SKCanvasView).PaintSurface += ((object sender, SKPaintSurfaceEventArgs args) =>
            {
                OnCanvasViewPaintSurface(args, "mdi-clipboard-account");
            });
            (menuList.Children[5] as SKCanvasView).PaintSurface += ((object sender, SKPaintSurfaceEventArgs args) =>
            {
                OnCanvasViewPaintSurface(args, "mdi-account-multiple");
            });
            (menuList.Children[6] as SKCanvasView).PaintSurface += ((object sender, SKPaintSurfaceEventArgs args) =>
            {
                OnCanvasViewPaintSurface(args, "mdi-account");
            });

		}

        void OnCanvasViewPaintSurface(SKPaintSurfaceEventArgs args, string icon)
		{
			SKImageInfo info = args.Info;
			SKSurface surface = args.Surface;
			SKCanvas canvas = surface.Canvas;

            SKTextRunLookup.Instance.AddMaterialDesignIcons();

            string icon1 = "{{ " + icon + " color=FF0000 }}";

			canvas.Clear();

            // var black = Color.FromRgb(0, 0, 0).ToSKColor();
            // var lightGray = Color.FromRgb(239, 239, 239).ToSKColor();
            // var darkGray = Color.FromRgb(153, 153, 153).ToSKColor();

			using (var paint = new SKPaint()) {
                paint.IsAntialias = true;
                paint.TextSize = 80;
                paint.Typeface = SKTypeface.FromFamilyName("Arial");

                canvas.DrawIconifiedText(icon1, info.Height / 2, info.Width / 2, paint);
                canvas.DrawLine(10, 10, 100, 100,paint);

            };




            // TODO: Draw a plus (+) inside the circle...

			// int x0 = (info.Height / 2) - 50;
			// int x1 = (info.Height / 2) - 45;
			// int xm = (x0 + x1) / 2;

			// int y0 = (info.Width / 2) - 50;
			// int y1 = (info.Width / 2) - 45;
			// int ym = (x0 + x1) / 2;

			// canvas.DrawCircle(info.Width / 2, info.Height / 2, 30, paint);

			// paint.Color = black;
			// canvas.DrawLine(xm,y0,xm,y1,paint);
			// canvas.DrawLine(x0,ym,x1,ym,paint);

			// paint.Style = SKPaintStyle.Fill;
			// paint.Color = darkGray;
			// canvas.DrawCircle(info.Width / 2, info.Height / 2, 30, paint);
		}

        void drawMainButton() {
            
        }

        void drawButton(int x, int y, SKPaint paint) {
            
        }

	}
}
