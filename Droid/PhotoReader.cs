using System;
using System.Threading.Tasks;
using System.IO;
using StyleUs.Droid;

[assembly: Xamarin.Forms.Dependency (typeof (PhotoReader))]
namespace StyleUs.Droid {
    
    public class PhotoReader : Java.Lang.Object, IPhoto {
        public async Task<Stream> GetPhoto ( string path )
        {
            // Open the photo and put it in a Stream to return       
            var memoryStream = new MemoryStream ();

            using (var source = System.IO.File.OpenRead (path)) {
                await source.CopyToAsync (memoryStream);
            }

            return memoryStream;
        }
    }
}
