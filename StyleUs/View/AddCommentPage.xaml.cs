using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism.Navigation;

namespace StyleUs.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddCommentPage : PopupPage
    {
        public INavigationService navigation;

        public AddCommentPage()
        {
           
            InitializeComponent();
            

            CloseWhenBackgroundIsClicked = true;
            

        }
    }
}