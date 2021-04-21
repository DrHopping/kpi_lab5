namespace kpi_lab5.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string BlogId { get; set; }
        public string BlogName { get; set; }
        public string AuthorId { get; set; }
        public string ImageUrl { get; set; }
    }
}