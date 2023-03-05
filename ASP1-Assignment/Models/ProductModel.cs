namespace ASP1_Assignment.Models
{
    public class ProductModel
    {
        public string ArticleNumber { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public string? ImageUrl { get; set; }
        public string? CategoryName { get; set; }
    }

}
