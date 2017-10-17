using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plugin.Connectivity;
using StyleUs.Models;

namespace StyleUs.Services
{
    public class ApiService : IApiService
    {
        public async Task<User> GetUser()
        {
            if(await CrossConnectivity.Current.IsRemoteReachable("www.google.com.do")){
				HttpClient client = new HttpClient();
                string result = await client.GetStringAsync("http://styleus.app/api/gett");

				var model = JsonConvert.DeserializeObject<User>(result);
				return model;
            }else{
                await App.Current.MainPage.DisplayAlert("Error", "Please check your internet connection", "Ok");
                return null;
            }
		}
        public async Task<Notification> GetNotification()
        {
            try {
                
                HttpClient client = new HttpClient();
                string result = await client.GetStringAsync("http://styleus.app/api/add");

                var model = JsonConvert.DeserializeObject<Notification>(result);
                return model;

            } catch (Exception ex) {
                var ce = ex.Message;
                return null;
            }
        }
    }
}
