using System.ComponentModel;
using System.Windows.Input;

using Xamarin.Forms;

using StyleUs.View;

using Prism.Navigation;


namespace StyleUs.ViewModel
{
	public class RegisterStepTwoViewModel : INotifyPropertyChanged
	{

		public ICommand goBack { get; set; }
        public ICommand finish { get; set; }

		public INavigationService navigation;

		public event PropertyChangedEventHandler PropertyChanged;

		public string username { get; set; }
		public string password { get; set; }

		/**
          *  [CONSTRUCTOR] Get the required parameters and initializes them as needed.
          *  
          *  @param INavigationService   the required navigation service.
          */
		public RegisterStepTwoViewModel(INavigationService navigationService)
		{
			navigation = navigationService;

			// Commands
			goBack = new Command(onBack);
            finish = new Command(onFinish);
		}

		/**
          *  [EVENT] Fired once the user has decided to cancel.
          */
		public void onBack()
		{
            navigation.GoBackAsync();
		}
		/**
          *  [EVENT] Fired once the user has decided to finish.
          */
		public void onFinish()
		{
            navigation.GoBackAsync();

            // TODO: Use MessagingCenter to pass down an alert.

           // DisplayAlert("Bien!", "Has completado el proceso de registro de StyleUs", "Aceptar");
		}


	}
}