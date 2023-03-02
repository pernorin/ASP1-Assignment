using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP1_Assignment.Models.Entities
{
    public class ProductEntity
    {
        [Key]
        public string ArticleNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        //public int ImageId { get; set; } // en product - flera bilder

        
        [Column(TypeName = "money")]
        public decimal Price { get; set; }
        public decimal DiscountPrice { get; set; }
        public int CategoryId { get; set; }

        public CategoryEntity Category { get; set; } = null!;
        public IEnumerable<ImageEntity> Images { get; set; } = new List<ImageEntity>();  // Rätt?
    }
}
