using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plugin.Connectivity;
using StyleUs.Models;

namespace StyleUs.Services
{
    public class AuthServices
    {
        public static async Task<User> login(string email, string password)
        {
            HttpClient client = new HttpClient();

            string url = Constants.API_ROOT + "/auth/login";

            var obj = new
            {
                email = email,
                password = password,
            };

            string data = JsonConvert.SerializeObject(obj);

            var content = new StringContent(data, Encoding.UTF8, "application/json");

            var result = await client.PostAsync(url,content);
            var res = await result.Content.ReadAsStringAsync();

           
            return null;
        }
    }
}
