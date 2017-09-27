using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Prism.Navigation;
using System.Collections.ObjectModel;

namespace StyleUs.ViewModel

{

    public class Comments
    {

        public string Name { get; set; }
        public string DetailComment { get; set; }
        public String TimeComment { get; set; }
        public int NumberAnswers { get; set; }
        public ImageSource ProfilePhoto { get; set; }

        

        public Comments(string name, string DetailComment, int TimeComment, int NumberAnswers, string image )
        {
            this.Name = name;
            this.DetailComment = DetailComment;
            this.TimeComment = ("hace " +TimeComment+ " minutos");
            this.NumberAnswers = NumberAnswers;
            this.ProfilePhoto = ImageSource.FromUri(new Uri(image));
        }


    }



    public class ViewCommentsViewModel : BindableBase
	{

        public ObservableCollection<Comments> _commentList = new ObservableCollection<Comments>();
        public ObservableCollection<Comments> CommentList
        {
            get
        {

            return _commentList;
        }
        

        set{
            _commentList = value;
                    }
        }


        public ViewCommentsViewModel( INavigationService navigationService )
        {
            CommentList.Add(new Comments("Chamuel Castillo", "Que cool esta", 5, 15, "https://www.anipedia.net/imagenes/como-nacen-los-hamsters.jpg"));
            CommentList.Add(new Comments("Adeury Camilo", "Vamos a echarnos", 1,10, "https://www.anipedia.net/imagenes/hamster-sirio-1.jpg"));
            CommentList.Add(new Comments("Andrea Polanco", "Soporto", 2, 3, "https://www.anipedia.net/imagenes/cuidados-hamster.jpg"));


        }
    }
}
