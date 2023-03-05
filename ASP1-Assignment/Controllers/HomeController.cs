using ASP1_Assignment.Models;
using ASP1_Assignment.Services;
using ASP1_Assignment.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ASP1_Assignment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductService _productService;

        public HomeController(ProductService productService)
        {
            _productService = productService;
        }

        public  async Task<IActionResult> Index()
        {
            var viewModel = new HomeViewModel();

            //var products = _productService.GetProductsAsync();

            viewModel.Products = await _productService.GetProductsAsync();

            viewModel.Hero = new HeroModel()
            {
                Title_1 = "WELCOME TO BMARKETO SHOP",
                Title_2 = "Exclusive Chair gold Collection.",
                ImageUrl = "~/wwwroot/Images/chair.jpg"
            };

            viewModel.Offer = new OfferModel()
            {
                Headline = "Get The Best Price",
                Text1 = "UP TO SELL",
                Text2 = "50% OFF",
                BodyText = "Lorem ipsum, dolor sit amet consectetur adipisicing elit. Iusto, beatae optio ratione a ducimus enim atque neque praesentium saepe similique ad dolores!",
                LinkText = "Discover More"
			};

            return View(viewModel);
        }
    }
}
