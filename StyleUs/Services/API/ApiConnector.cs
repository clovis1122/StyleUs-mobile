using System;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Plugin.Connectivity;
using StyleUs.Models;
using Plugin.Media.Abstractions;
using System.IO;

namespace StyleUs.Services.API
{
    public class ApiConnector
    {
        public static string API_ROOT = "https://quiet-gorge-89832.herokuapp.com/api/v1";

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

        public static async Task<IApiResponse> postJsonFromUrl(string relativeUrl, object data = null, MediaFile[] files = null)
        {
            // The client to use in our connection.
            HttpClient client = new HttpClient();
            string url = API_ROOT + relativeUrl;

            HttpResponseMessage result;

            if (files != null) 
            {
                var requestData = new MultipartFormDataContent();

                foreach (PropertyInfo propertyInfo in data.GetType().GetRuntimeProperties())
                {
                    var property = propertyInfo.GetValue(data, null) as string;

                    requestData.Add(new StringContent(property),propertyInfo.Name);
                }

                foreach(var file in files) {
                    MemoryStream ms = new MemoryStream();
                    file.GetStream().CopyTo(ms);
                    ByteArrayContent baContent = new ByteArrayContent(ms.ToArray());
                    requestData.Add(baContent, "image", "image.png");
                }

                // Make the POST request
                result = await client.PostAsync(url, requestData);

            } else 
            {
                // The data to send in our request.
                var serializedData = JsonConvert.SerializeObject(data);
                var requestData = new StringContent(serializedData, Encoding.UTF8, "application/json");

                // Make the POST request
                result = await client.PostAsync(url, requestData);
            }

            return new ApiResponse(
                status: (int)result.StatusCode,
                response: await result.Content.ReadAsStringAsync()
            );
        }

        public static async Task<IApiResponse> getJsonFromUrl(string relativeUrl, object data = null)
        {
            // The client to use in our connection.
            HttpClient client = new HttpClient();
            string url = API_ROOT + relativeUrl;

            // The data to send in our request.
            var serializedData = JsonConvert.SerializeObject(data);
            var requestData = new StringContent(serializedData, Encoding.UTF8, "application/json");

            // Make the GET request
            var result = await client.GetAsync(url);
            return new ApiResponse(
                status: (int)result.StatusCode,
                response: await result.Content.ReadAsStringAsync()
            );
        }

    }
}
