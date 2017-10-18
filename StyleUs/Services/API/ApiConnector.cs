using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plugin.Connectivity;
using StyleUs.Models;

namespace StyleUs.Services.API
{
    public class ApiConnector
    {
        public static string API_ROOT = "https://serene-scrubland-79664.herokuapp.com/api/v1";

        /**
         * The idea is to return this class to remove some of the complexity
         * that results from managing HTTP requests.
         */
        private class ApiResponse : IApiResponse
        {
            int statusCode;
            string responseString;

            public ApiResponse(int status, string response) {
                statusCode = status;
                responseString = response;
            }

            public T GetResponseAsModel<T>()
            {
                return JsonConvert.DeserializeObject<T>(responseString);
            }

            public int GetStatusCode()
            {
                return statusCode;
            }
        }

        public static async Task<IApiResponse> postJsonFromUrl(string relativeUrl, object data = null ) 
        {
            // The client to use in our connection.
            HttpClient client = new HttpClient();
            string url = API_ROOT + relativeUrl;

            // The data to send in our request.
            var serializedData = JsonConvert.SerializeObject(data);
            var requestData = new StringContent(serializedData, Encoding.UTF8, "application/json");

            // Make the POST request
            var result = await client.PostAsync(url, requestData);

            return new ApiResponse(
                status: (int)result.StatusCode,
                response: await result.Content.ReadAsStringAsync()
            );
        }

    }
}
