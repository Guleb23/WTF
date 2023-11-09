namespace Blog.Models
{
    public class Posts
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime DatePublic { get; set; }
    }
}
