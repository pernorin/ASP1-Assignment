namespace ASP1_Assignment.Models.Entities
{
    public class CategoryEntity
    {

        public int Id { get; set; }
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<ProductEntity> Products { get; set; } = new HashSet<ProductEntity>();
    }
}
