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
using Prism.Navigation;
using StyleUs.Models.Enums;

namespace StyleUs.ViewModel
{
    public class AddPicturePostViewModel : INotifyPropertyChanged
    {
        private MediaFile file = null;

        INavigationService navigation;

        public ICommand TakePhoto { get; set; }
        public ICommand CreatePost { get; set; }
        public ImageSource image { get; set; }
        public string body { get; set; }
        public bool showSubmit { get; set; }
        public bool isCloth { get; set; }
        public bool isLoading { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public AddPicturePostViewModel(INavigationService navigationService)
        {
           // image = "https://freerangestock.com/thumbnail/27083/steampunk-woman-tips-hat.jpg";
            TakePhoto = new Command(takePhoto);
            CreatePost = new Command(createPost);
            navigation = navigationService;
            isLoading = false;
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
                Name = "test.jpg",
            });

            if (file == null) return;

            this.file = file;
            image = ImageSource.FromFile(file.Path);
            showSubmit = true;
        }

        public async void createPost()
        {
            isLoading = true;

            try {
                var x = await StyleUs.Services.PostServices.createPost(file, body, isCloth ? PostTypes.CLOTH : PostTypes.PIERCE);
            } catch(Exception e) {
                // Error! :(
            }

            // Post created! Clean up before exit.


            if (file != null) {
                file.Dispose();
            }

            image = null;
            body = "";
            showSubmit = false;
            isLoading = false;

            navigation.NavigateAsync(new Uri("/MainTabbedPage/HomePage",UriKind.Absolute));
        }
    }
}
