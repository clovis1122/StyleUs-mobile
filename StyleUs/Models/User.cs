using System;
using Newtonsoft.Json;

namespace StyleUs.Models
{
    public class User
    {
        public string id { get; set; }
        public string age { get; set; }
        public string image { get; set; }
        public string last_name { get; set; }
        public string first_name { get; set; }
        public string is_male { get; set; }
        public string email { get; set; }
        public string token { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }

        [JsonIgnore]
        public string full_name {
            get {
                return first_name + " " + last_name;
            }
        }
        public string phone { get; set; } = "809-000-0000";

        public object clone() {
            return this.MemberwiseClone();
        }
    }
}
