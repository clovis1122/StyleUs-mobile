using System;

using StyleUs.Services;
using StyleUs.Models;

using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Prism.Commands;
using System.Windows.Input;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace StyleUs.ViewModel
{
    public class AddPicturePostViewModel : INotifyPropertyChanged
    {
        private MediaFile file = null;

        public ICommand TakePhoto { get; set; }
        public ICommand CreatePost { get; set; }
        public ImageSource image { get; set; }
        public string body { get; set; }
        public bool showSubmit { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public AddPicturePostViewModel()
        {
           // image = "https://freerangestock.com/thumbnail/27083/steampunk-woman-tips-hat.jpg";
            TakePhoto = new Command(takePhoto);
            CreatePost = new Command(createPost);

        }

        public async void takePhoto()
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                // "No Camera", ":( No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg"
            });

            if (file == null) return;

            this.file = file;
            image = ImageSource.FromFile(file.Path);
            showSubmit = true;
        }

        public async void createPost()
        {
            try {
                var x = await StyleUs.Services.PostServices.createPost(file, body);
            } catch {
                // Error! :(
            }
           
            // Post created! 
        }
    }
}
