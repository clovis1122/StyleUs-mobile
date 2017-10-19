using System;
namespace StyleUs.Models.App
{
    public class RegisterUser
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public DateTime birthday { get; set; }
        public bool is_male {get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string password_confirmation { get; set; }
    }
}
