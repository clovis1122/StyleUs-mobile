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
        public static async Task<KeyValuePair<bool,object>> createPost(MediaFile file, string body)
        {
            var resp = await ApiConnector.postJsonFromUrl("posts/", new { body = body }, new MediaFile[] { file } );
            return new KeyValuePair<bool,object>();
        }

        public static async Task<KeyValuePair<bool, object>?> likePost(int postId, bool like)
        {
            var resp = await ApiConnector.postJsonFromUrl($"posts/{postId}/like", new { like } );
            if (resp.GetStatusCode() != 204)
            {
                return new KeyValuePair<bool, object>(false, resp.GetResponseAsModel<Dictionary<string, ApiFieldError>>());
            }
            return null;
        }

        public static async Task<KeyValuePair<bool, object>?> commentPost(int postId, string body)
        {
            var resp = await ApiConnector.postJsonFromUrl($"posts/{postId}/comment", new { body });
            if (resp.GetStatusCode() != 204)
            {
                return new KeyValuePair<bool, object>(false, resp.GetResponseAsModel<Dictionary<string, ApiFieldError>>());
            }

            return null;
        }

        public static async Task<KeyValuePair<bool, object>> fetchPosts()
        {
            var resp = await ApiConnector.getJsonFromUrl("posts/");
            if (resp.GetStatusCode() != 200)
            {
                return new KeyValuePair<bool, object>(false, resp.GetResponseAsModel<Dictionary<string, ApiFieldError>>());
            }
            return new KeyValuePair<bool, object>(true,resp.GetResponseAsModel<List<Post>>());
        }

    }
}
