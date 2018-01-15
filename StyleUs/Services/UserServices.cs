using System.Collections.Generic;
using System.Threading.Tasks;
using StyleUs.Models;
using StyleUs.Services.API;
using StyleUs.Models;

namespace StyleUs.Services
{
    public class UserServices
    {
        public static async Task<KeyValuePair<bool,object>> get()
        {
            var resp = await ApiConnector.getJsonFromUrl("users/");
            if (resp.GetStatusCode() != 200) {
                return new KeyValuePair<bool, object>(false,resp.GetResponseAsModel<Dictionary<string,ApiFieldError>>());
            }
            return new KeyValuePair<bool, object>(true, resp.GetResponseAsModel<List<User>>());
        }

        public static async Task<KeyValuePair<bool, object>> getUser(int id)
        {
            var resp = await ApiConnector.getJsonFromUrl($"users/{id}");
            if (resp.GetStatusCode() != 200)
            {
                return new KeyValuePair<bool, object>(false, resp.GetResponseAsModel<Dictionary<string, ApiFieldError>>());
            }
            return new KeyValuePair<bool, object>(true, resp.GetResponseAsModel<User>());
        }

        public static async Task<KeyValuePair<bool, object>?> addRelationship(int id, UserRelations relationId)
        {
            var resp = await ApiConnector.postJsonFromUrl($"users/{id}/relation", new { relationId = (int)relationId });

            if (resp.GetStatusCode() != 400)
            {
                return new KeyValuePair<bool, object>(false, resp.GetResponseAsModel<Dictionary<string, ApiFieldError>>());
            }
            return null;
        }

        public static async Task<KeyValuePair<bool, object>> getProfile()
        {
            var resp = await ApiConnector.getJsonFromUrl("users/profile");
            if (resp.GetStatusCode() != 200)
            {
                return new KeyValuePair<bool, object>(false, resp.GetResponseAsModel<Dictionary<string, ApiFieldError>>());
            }
            return new KeyValuePair<bool, object>(true, resp.GetResponseAsModel<User>());
        }
    }
}
