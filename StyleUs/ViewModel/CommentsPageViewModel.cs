using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;

namespace StyleUs.ViewModel
{
    public class CommentsPageViewModel : BindableBase
    {
        public INavigationService navigation;
        public CommentsPageViewModel(INavigationService navigationService)
        {
            navigation = navigationService;
        }
    }
}
