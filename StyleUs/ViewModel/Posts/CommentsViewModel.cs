using System;

using StyleUs.Services;
using StyleUs.Models;

using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;

using System.Windows.Input;

using Xamarin.Forms;

using StyleUs.View;
using Prism.Navigation;
using Prism.Commands;
using Prism.Events;
using System.Threading.Tasks;
using StyleUs.Services;

namespace StyleUs.ViewModel
{
    public class CommentsViewModel : INotifyPropertyChanged, INavigationAware
    {
        public DelegateCommand back { get; set; }
        public ICommand comment { get; set; }
        private Post post;
        public string body { get; set; }

        readonly INavigationService navigation;
        IEventAggregator events;

        public ObservableCollection<Comment> _commentsList = new ObservableCollection<Comment>();
        public ObservableCollection<Comment> commentsList
        {
            get{
                return _commentsList;
            }

            set{
                _commentsList = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        String[] listadoNombre = new String[] {"Andrea","Adeury","Clovis","Chamuel","Miguel","Cristian"};
        String[] listadoApellido = new string[] { "Polanco", "Camilo", "Ramirez", "Castillo", "Oviedo", "Luna" };
        static Random random = new Random();

        public CommentsViewModel(INavigationService navigationService, IEventAggregator eventAgregator)
        {
            navigation = navigationService;
            events = eventAgregator;

            back = new DelegateCommand(OnBackClick);
            comment = new Command(onComment);
        }

        public void OnBackClick()
        {
            navigation.GoBackAsync();
        }

        public void onComment() 
        {
            User user = null;

            if (Application.Current.Properties.ContainsKey("user")) {
                user = Application.Current.Properties["user"] as User;
            } else {
                user = new User()
                {
                    id = "1",
                    last_name = "John",
                    first_name = "Doe",
                };
            }

            var com = new Comment()
            {
                body = body,
                user = user,
            };

            commentsList.Add(com);
            post.comments.Add(com);

            try {
                PostServices.commentPost(post.id, body);
            } catch { }
        }

        public void generateComments()
        {
            string[] comentarios = new string[]{
            "1 - Este es mi comentario, corto para probar",
            "2 - Aqui voy yo, probando con un comentario mas o menos para ver como crece el campo",
            "3 - Klk, Damas y caballeros",
            "4 - Llegue yo, tambien soy parte del grupo, reportanto desde Intec a todo el mundo, activo con mi aplicacion" +
            "Style Us lo mejor que he podido usar, muy cool"
            };
            
            for (int i = 0; i <= 10; i++)
            {
                var comment = new StyleUs.Models.Comment();
                comment.body = "Body!";
            }
        }

        // INavigationAware
        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            // When you navigate away from this page
        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            var comments = parameters["comments"] as List<Comment>;
            var _post = parameters["post"] as Post;

            if (comments != null)
            {
                commentsList = new ObservableCollection<Comment>(comments);
                post = _post;
            } else {
                generateComments();
            }

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }
    }
}
