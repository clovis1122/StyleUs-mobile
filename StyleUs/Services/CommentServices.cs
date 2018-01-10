using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plugin.Connectivity;
using StyleUs.Models;
using System.Collections.Generic;
using StyleUs.Services.API;

namespace StyleUs.Services
{
    public class CommentServices
    {
        public static async Task<KeyValuePair<bool, object>> get()
        {
            var resp = await ApiConnector.getJsonFromUrl("View/");
            if (resp.GetStatusCode() != 200)
            {
                return new KeyValuePair<bool, object>(false, resp.GetResponseAsModel<Dictionary<string, ApiFieldError>>());
            }
            return new KeyValuePair<bool, object>(true, resp.GetResponseAsModel<List<Comment>>());
        }
    }
}
