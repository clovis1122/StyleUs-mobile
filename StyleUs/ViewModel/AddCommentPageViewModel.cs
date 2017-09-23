using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism;
using Prism.Navigation;
using System.Windows.Input;
using Xamarin.Forms;

namespace StyleUs.ViewModel
{
    public class AddCommentPageViewModel : BindableBase
    {
        public ICommand viewHome { get; set; }
        public INavigationService navigation;

        public AddCommentPageViewModel(INavigationService navigationService)
        {
            navigation = navigationService;
            viewHome = new Command(goBack);
        
        }

        public void goBack()
        {
            navigation.GoBackAsync();
        }
    }
}
