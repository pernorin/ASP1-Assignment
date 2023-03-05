using ASP1_Assignment.Contexts;
using ASP1_Assignment.Models;
using Microsoft.EntityFrameworkCore;

namespace ASP1_Assignment.Services
{
    // lek7 - 03_Fixxo
    public class ProductService
    {
        private readonly IdentityContext _context;

        public ProductService(IdentityContext context)
        {
            _context = context;
        }
         
        public async Task<IEnumerable<ProductModel>> GetProductsAsync()
        {
            var _products = await _context.Products.ToListAsync();

            var products = new List<ProductModel>();
            foreach (var product in _products)
            {
                products.Add(new ProductModel
                {
                    ArticleNumber = product.ArticleNumber,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price,
                    DiscountPrice = product.DiscountPrice,
                    ImageUrl = product.ImageUrl,
                    CategoryName = product.CategoryName
                });
            }
            return products;
        }
    }
        
}
