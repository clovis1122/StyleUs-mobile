using System.ComponentModel;
using System.Windows.Input;

using Xamarin.Forms;

using StyleUs.View;

namespace StyleUs.ViewModel
{
	public class RegisterStepOneViewModel : INotifyPropertyChanged
	{

		public ICommand cancel { get; set; }
		public ICommand next { get; set; }

		public INavigation navigation;

		public event PropertyChangedEventHandler PropertyChanged;

		public string name { get; set; }
		public string lastname { get; set; }

		public RegisterStepOneViewModel()
		{
			cancel = new Command(onCancel);
			next = new Command(onNext);

            // TODO: bind the birthdate and elected sex to the ViewModel.
		}

		public void onCancel()
		{
            navigation.PopAsync();
		}

		public void onNext()
		{
			navigation.PushAsync(new RegisterStepTwo());

		}


	}
}