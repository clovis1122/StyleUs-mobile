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


namespace StyleUs.ViewModel
{
    public class CommentsViewModel : INotifyPropertyChanged
    {
        public DelegateCommand back { get; set; }

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
            //loadComment();
            Random random = new Random();

            String[] comentarios = new string[]{
                "Este es mi comentario, corto para probar",
                "Aqui voy yo, probando con un comentario mas o menos para ver como crece el campo",
                "Klk, Damas y caballeros",
                "Llegue yo, tambien soy parte del grupo, reportanto desde Intec a todo el mundo, activo con mi aplicacion" +
                "Style Us lo mejor que he podido usar, muy cool"
            };

            for (int i = 0; i <= 10; i++)
            {
                var du = new StyleUs.Models.Comment();
                du.name = listadoNombre[random.Next(listadoNombre.Length - 1)] + " " +
                    listadoApellido[random.Next(listadoApellido.Length - 1)];
                du.time = DateTime.Now.ToString("h:mm");
                du.descriptionComment = comentarios[random.Next(0, 4)];
                du.img = "PhotoPerfil" + random.Next(1, 5).ToString();
                commentsList.Add(du);
            }


            navigation = navigationService;
            events = eventAgregator;

            back = new DelegateCommand(OnBackClick);
        }


        public void OnBackClick()
        {
            navigation.GoBackAsync();

        }



        public async void loadComment()
        {
            

            try
            {
                var du2 = await CommentServices.get();

                if (du2.Key)
                {
                    commentsList = new ObservableCollection<Comment>(du2.Value as List<Comment>);
                }
            }
            catch
            {   
                Random random = new Random();

                String[] comentarios = new string[]{
                "1 - Este es mi comentario, corto para probar",
                "2 - Aqui voy yo, probando con un comentario mas o menos para ver como crece el campo",
                "3 - Klk, Damas y caballeros",
                "4 - Llegue yo, tambien soy parte del grupo, reportanto desde Intec a todo el mundo, activo con mi aplicacion" +
                "Style Us lo mejor que he podido usar, muy cool"
            };

                for (int i = 0; i <= 10; i++)
                {
                    var du = new StyleUs.Models.Comment();
                    du.name = listadoNombre[random.Next(listadoNombre.Length - 1)] + " " +
                        listadoApellido[random.Next(listadoApellido.Length - 1)];
                    du.time = DateTime.Now.ToString("h:mm");
                    du.descriptionComment = comentarios[random.Next(0, 3)];
                    du.img = "PhotoPerfil" + random.Next(1, 4).ToString();
                    commentsList.Add(du);
                }
            }

        }


    }
}
