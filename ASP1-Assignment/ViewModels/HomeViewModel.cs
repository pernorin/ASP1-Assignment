using ASP1_Assignment.Models;

namespace ASP1_Assignment.ViewModels
{
    public class HomeViewModel
    {
        public HeroModel Hero { get; set; } = new HeroModel();
        public OfferModel Offer { get; set; } = new OfferModel();
        public IEnumerable<ProductModel> Products { get; set; } = new List<ProductModel>();
    }
}
