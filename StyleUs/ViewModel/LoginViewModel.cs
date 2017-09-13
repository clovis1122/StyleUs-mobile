using System;

using System.ComponentModel;
using System.Windows.Input;

using Xamarin.Forms;

using StyleUs.View;

namespace StyleUs.ViewModel
{
	public class LoginViewModel : INotifyPropertyChanged
	{
        
		public ICommand registerClick { get; set; }
        public INavigation navigation;

		public event PropertyChangedEventHandler PropertyChanged;

		public string username { get; set; }
		public string password { get; set; }

		public LoginViewModel()
		{
			registerClick = new Command(onRegisterClick);
		}

		public void onRegisterClick()
        {
            navigation.PushAsync(new RegisterStepOne());

		}


	}
}