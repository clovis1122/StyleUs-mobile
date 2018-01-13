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
    public class AuthServices
    {
        public static async Task<KeyValuePair<bool,object>> login(string email, string password)
        {
            var resp = await ApiConnector.postJsonFromUrl("auth/login/", new { email, password});

            if (resp.GetStatusCode() != 200) {
                return new KeyValuePair<bool, object>(false,resp.GetResponseAsModel<Dictionary<string,ApiFieldError>>());
            }
            return new KeyValuePair<bool, object>(true, resp.GetResponseAsModel<User>());
        }

        public static async Task<KeyValuePair<bool, object>> register(StyleUs.Models.App.RegisterUser user)
        {
            var resp = await ApiConnector.postJsonFromUrl("auth/register/", user);

            if (resp.GetStatusCode() == 400)
            {
                return new KeyValuePair<bool, object>(false, resp.GetResponseAsModel<Dictionary<string, ApiFieldError>>());
            }

            if (resp.GetStatusCode() == 200)
            {
                return new KeyValuePair<bool, object>(true, resp.GetResponseAsModel<User>());
            }

            return new KeyValuePair<bool, object>();

        }
    }
}
