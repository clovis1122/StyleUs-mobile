using System;

using System.ComponentModel;
using System.Windows.Input;

using Xamarin.Forms;

using StyleUs.View;
using Prism.Navigation;
using Prism.Commands;
using StyleUs.ViewModel.Component;
using System.Collections.ObjectModel;
using Prism.Events;

namespace StyleUs.ViewModel
{
    public class ClothPieceViewModel : INotifyPropertyChanged
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

        public DelegateCommand back { get; set; }

        INavigationService navigation;
        IEventAggregator events;

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
        static Random rnd = new Random();

        public ClothPieceViewModel(INavigationService navigationService, IEventAggregator eventAgregator)
        {
            MenuViewModel = new FloatingMenuViewModel(navigationService);

            // Fill the imageList with preset images.
            ReloadData();

            navigation = navigationService;
            events = eventAgregator;

            back = new DelegateCommand(OnBackClick);
        }

		public void ReloadData()
		{

			var list = new ObservableCollection<Image>();

			string[] images = {
				"http://telemarcas.com.do/185-thickbox_default/PolocheHombreAzulClaroRef24K15.jpg",
				"https://static.tiendo.do/uploads/media/product_attribute_line_value/recipeImg/2e/8553-84019/8553-84019_normal-normal.jpg",
				"https://media.quiksilver.com.au/media/catalog/product/cache/thumbnail/1000x1000/9df78eab33525d08d6e5fb8d27136e95/e/q/eqynp03107_quiksilver_mens_fonic_pant_ktfh_1_h.jpg",
				"http://ropa-militar.com/9425-annack_home/pantalon-tactico-army-en-camuflaje-multicam-de-propper.jpg",
				"https://ae01.alicdn.com/kf/HTB198SOX6ihSKJjy0Fiq6AuiFXaM/Nueva-Moda-Feliz-Impreso-Camisa-de-Las-Mujeres-3-4-de-Manga-Larga-Suelta-Tops-Pullover.jpg",
				"https://sses.tidebuy.com/images/product/c/101053/12709/12709590_1.jpeg",
				"https://sses.tidebuy.com/images/product/c/101053/12557/12557567_7.jpeg",
				"http://cdn.cichic.com/media/catalog/product/cache/1/image/5e06319eda06f020e43594a9c230972d/1/1/11147477929-1/black-plain-fur-buttons-belt-turndown-collar-fashion-double-breasted-peplum-wool-coat.jpg",
				"https://ae01.alicdn.com/kf/HTB1yl.sNXXXXXaRXXXXq6xXFXXX1/New-Velvet-Hooded-Jacket-Autumn-Winter-Female-Jackets-Women-Navy-Wool-Coat-Jacket-Casual-Long-Trench.jpg",
				"http://shyla.vteximg.com.br/arquivos/ids/158563-1000-1000/Abrigo-Richard.jpg",
			};
			int number = 0;
			for (int n = 0; n < 2; n++)
			{
				for (int i = 0; i < images.Length; i++)
				{
					number++;
                    var item = new Image(images[rnd.Next(images.Length)], string.Format("image_{0}.jpg", number));

					list.Add(item);
				}
			}

            imageList = list;
		}

        public void OnBackClick()
        {
            navigation.GoBackAsync();
        }

    }
}
