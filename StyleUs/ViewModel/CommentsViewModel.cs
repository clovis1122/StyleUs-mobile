using System;

using StyleUs.Services;
using StyleUs.Models;

using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;


namespace StyleUs.ViewModel
{
    public class CommentsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<StyleUs.Models.Comment> _commentsList = new ObservableCollection<Comment>();
        public ObservableCollection<StyleUs.Models.Comment> commentsList
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
            for (int i = 0; i <= 20;i++){
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
            var du = await StyleUs.Services.CommentServices.get();

            if (du.Key)
            {
                commentsList = new ObservableCollection<StyleUs.Models.Comment>(du.Value as List<StyleUs.Models.Comment>);
            }
        }


    }
}
