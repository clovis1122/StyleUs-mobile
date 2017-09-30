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
    public class FriendProfileViewModel : INotifyPropertyChanged
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

		public FriendProfileViewModel(INavigationService navigationService)
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
				"https://www.anipedia.net/imagenes/cuidados-hamster.jpg",
				"http://i1.wp.com/tuhamster.com/wp-content/uploads/2015/10/como-criar-un-hamster_opt.jpg",
				"http://www.petwebsite.com/hamsters/hamsters_images/hamster_000009248846.jpg",
				"http://img.bekiamascotas.com/articulos/portada/41000/41059-h2.jpg",
				"https://i.ytimg.com/vi/w6Z5XpJ_IHM/maxresdefault.jpg",
				"http://s7d2.scene7.com/is/image/PetSmart/5081326?$sclp-prd-main_large$",
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