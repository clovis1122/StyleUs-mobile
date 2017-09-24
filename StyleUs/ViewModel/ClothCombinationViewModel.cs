using System;

using System.ComponentModel;
using System.Windows.Input;

using Xamarin.Forms;

using StyleUs.View;
using Prism.Navigation;
using Prism.Commands;
using StyleUs.ViewModel.Component;
using System.Collections.ObjectModel;

namespace StyleUs.ViewModel
{
	public class ClothCombinationViewModel : INotifyPropertyChanged
	{
		public class Image
		{

			public string imageUrl { get; set; }
			public string fileName { get; set; }

			public Image(string imageUrl, string fileName)
			{
				this.imageUrl = imageUrl;
				this.fileName = fileName;
			}

		}
		public event PropertyChangedEventHandler PropertyChanged;

		public FloatingMenuViewModel MenuViewModel { get; set; }

		public ObservableCollection<Image> _imageList = new ObservableCollection<Image>();
		public ObservableCollection<Image> imageList
		{
			get
			{
				return _imageList;
			}
			set
			{
				_imageList = value;
			}
		}

		public ClothCombinationViewModel(INavigationService navigationService)
		{
			MenuViewModel = new FloatingMenuViewModel(navigationService);

			// Fill the imageList with preset images.
			ReloadData();
		}

        static Random rnd = new Random();

		public void ReloadData()
		{

			var list = new ObservableCollection<Image>();

			string[] images = {
				"http://www.institutoferrolvello.es/images/rtgn7/Modelos%20Ropa%20-%20Mochini%20Playera%20Blanca%20con%20Estampado%20Blanco%20-%20Playeras%20em5sddpn_02.jpg",
				"https://www.estarguapas.com/pics/2012/03/modelo-mark-jacobs.jpg",
				"https://firstgroupstaff.files.wordpress.com/2013/05/oysho_gym_fg-staff.jpg",
				"http://www.okchicas.com/wp-content/uploads/2016/03/A-esta-modelo-se-le-dijo-que-era-demasiado-gorda-ahora-es-modelo-de-ropa-interior-9.jpg",		
                "http://www.mistermoda.com/wp-content/uploads/2010/09/Jon-Kortajarena-for-HM-Fall-Winter-201011-02.jpg",
				"https://thumbs.dreamstime.com/z/mujer-modelo-de-la-belleza-en-ropa-del-invierno-22551783.jpg",
				"nocarga",
			};

			for (int i = 0; i < images.Length; i++)
			{
				var item = new Image(images[i], string.Format("image_{0}.jpg", i));

				list.Add(item);
			}

			imageList = list;
		}

	}
}