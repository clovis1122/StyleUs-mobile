using System;
namespace StyleUs.Models
{
    public class Post
    {
        public int id { get; set; }
        public User user { get; set; }
        public string body { get; set; }
        public string image { get; set; }
        public int like_count { get; set; }
        public string clothe { get; set; }
        public int comments_count { get; set; }
        public bool is_liked { get; set; }
    }
}
