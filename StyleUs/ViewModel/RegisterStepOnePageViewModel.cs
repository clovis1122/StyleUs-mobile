using System.ComponentModel;
using System.Windows.Input;

using Xamarin.Forms;

using StyleUs.View;
using Prism.Navigation;

namespace StyleUs.ViewModel
{
	public class RegisterStepOnePageViewModel : INotifyPropertyChanged
	{

		public ICommand cancel { get; set; }
		public ICommand next { get; set; }

		public INavigationService navigation;

		public event PropertyChangedEventHandler PropertyChanged;

		public string name { get; set; }
		public string lastname { get; set; }

		/**
          *  [CONSTRUCTOR] Get the required parameters and initializes them as needed.
          *  
          *  @param INavigationService   the required navigation service.
          */
		public RegisterStepOnePageViewModel(INavigationService navigationService)
		{
			navigation = navigationService;

			// Commands
            cancel = new Command(onCancel);
            next = new Command(onNext);

			// TODO: bind the birthdate and elected sex to the ViewModel.
		}

		/**
    	  *  [EVENT] Fired once the user has decided to cancel.
    	  */
		public void onCancel()
		{
            navigation.GoBackAsync();
		}

		/**
          *  [EVENT] Fired once the user has decided to continue.
          */
		public void onNext()
		{
            navigation.NavigateAsync("RegisterStepTwoPage");
		}
	}
}