using System;
using Xamarin.Forms;

namespace StyleUs.View
{
    public partial class MainTabbedPage : TabbedPage
    {
        public MainTabbedPage()
        {
            try {
                InitializeComponent();
            } catch (Exception e) {
                var du = e;

            }
        }
    }
}
