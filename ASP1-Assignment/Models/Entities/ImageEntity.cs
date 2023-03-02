namespace ASP1_Assignment.Models.Entities
{
    public class ImageEntity
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public string Alt { get; set; } = string.Empty;
        public string ArticleNumber { get; set; } = string.Empty;

        public ProductEntity Product { get; set; } = null!;
    }
}
