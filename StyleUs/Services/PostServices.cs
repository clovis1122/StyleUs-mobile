using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plugin.Connectivity;
using StyleUs.Models;
using System.Collections.Generic;
using StyleUs.Services.API;
using Plugin.Media.Abstractions;

namespace StyleUs.Services
{
    public class PostServices
    {
        public static async Task<KeyValuePair<bool,object>> createPost(MediaFile file)
        {
            var resp = await ApiConnector.postJsonFromUrl("/users/", new { body = "My Body" }, new MediaFile[] { file } );
            return new KeyValuePair<bool,object>();
        }
    }
}
