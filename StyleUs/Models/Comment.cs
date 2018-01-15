using System;
namespace StyleUs.Models
{
    public class Comment
    {
        public int id { get; set; }
        public User user { get; set; }
        public Post post { get; set; }
        public string body { get; set; }
        public string created_at { get; set; }
    }
}
