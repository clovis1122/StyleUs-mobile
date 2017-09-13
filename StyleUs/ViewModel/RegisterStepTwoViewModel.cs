using System.ComponentModel;
using System.Windows.Input;

using Xamarin.Forms;

using StyleUs.View;

namespace StyleUs.ViewModel
{
	public class RegisterStepTwoViewModel : INotifyPropertyChanged
	{

		public ICommand cancel { get; set; }
        public ICommand finish { get; set; }

		public INavigation navigation;

		public event PropertyChangedEventHandler PropertyChanged;

		public string username { get; set; }
		public string password { get; set; }

		public RegisterStepTwoViewModel()
		{
			cancel = new Command(onCancel);
            finish = new Command(onFinish);
		}

		public void onCancel()
		{
			navigation.PopAsync();
		}

		public void onFinish()
		{
            // TODO: Use MessagingCenter to pass down an alert.

           // DisplayAlert("Bien!", "Has completado el proceso de registro de StyleUs", "Aceptar");
		}


	}
}