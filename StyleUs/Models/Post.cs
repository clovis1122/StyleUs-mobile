namespace StyleUs.Models
{
    public class Post
    {
        public int id { get; set; }
        public User user { get; set; }
        public string body { get; set; }
        public string image { get; set; }

        public int like_count { get; set; }
        public string created_at { get; set; }
        public bool is_liked { get; set; }
        public System.Collections.Generic.List<Comment> comments { get; set; }
    }
}
