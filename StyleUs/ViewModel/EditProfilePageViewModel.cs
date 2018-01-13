using StyleUs.ViewModel;
using Xamarin.Forms;
using Prism.Navigation;
using Prism.Commands;
using Prism.Events;
using System.ComponentModel;

namespace StyleUs.ViewModel
{
    public class EditProfilePageViewModel : ContentPage
    {

        public DelegateCommand cancel { get; set; }
        public DelegateCommand save { get; set; }

        readonly INavigationService navigation;
        IEventAggregator events;

        public EditProfilePageViewModel(INavigationService navigationService, IEventAggregator eventAgregator)
        {
            navigation = navigationService;
            events = eventAgregator;

            cancel = new DelegateCommand(OnCancelClick);
            save = new DelegateCommand(OnSaveClick);
        }

        public void OnCancelClick(){

            navigation.GoBackAsync();

        }

        public void OnSaveClick(){

            navigation.GoBackAsync();
        }
    }
}
