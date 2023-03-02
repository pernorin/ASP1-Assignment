using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP1_Assignment.Models.Entities
{
    public class ProductEntity
    {
        [Key]
        public string ArticleNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        
        [Column(TypeName = "money")]
        public decimal DiscountPrice { get; set; }
        public string? ImageUrl { get; set; } 
        public string? CategoryName { get; set; }

    }
}
