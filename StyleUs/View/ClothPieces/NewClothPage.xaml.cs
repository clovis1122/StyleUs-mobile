using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace StyleUs.View.ClothPieces
{
    public partial class NewClothPage : ContentPage
    {
        public NewClothPage()
        {
            try {
                InitializeComponent();
            } catch(Exception e) {
                var f = e.Message;
            }


        }
    }
}
