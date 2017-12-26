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


        public CommentsViewModel()
        {
            //loadComment();
            for (int i = 0; i <= 10; i++)
            {
                var du = new StyleUs.Models.Comment();
                du.name = listadoNombre[random.Next(listadoNombre.Length - 1)] + " " +
                    listadoApellido[random.Next(listadoApellido.Length - 1)];
                du.time = DateTime.Now.ToString("h:mm");
                du.descriptionComment = "Creando comentarios disponibles sobre las piezas, conjuntos y demas" +
                    " para que sea largo y podemos ver de que tipo de damano queda en el celular bla bla bla";
                du.img = "ICONO2.png";
                commentsList.Add(du);
            }

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
                for (int i = 0; i <= 10; i++)
                {
                    var du = new StyleUs.Models.Comment();
                    du.name = listadoNombre[random.Next(listadoNombre.Length - 1)] + " " +
                        listadoApellido[random.Next(listadoApellido.Length - 1)];
                    du.time = DateTime.Now.ToString("h:mm");
                    du.descriptionComment = "Creando comentarios disponibles sobre las piezas, conjuntos y demas" +
                        " para que sea largo y podemos ver de que tipo de damano queda en el celular bla bla bla";
                    du.img = "ICONO2.png";
                    commentsList.Add(du);
                }
            }

        }


    }
}
