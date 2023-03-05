using ASP1_Assignment.Models.Identity;
using ASP1_Assignment.Services;
using ASP1_Assignment.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP1_Assignment.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserService _userService;

        public AccountController(UserService userService)
        {
            _userService = userService;
        }


		public async Task<IActionResult> Index(string id)
		{
			UserAccount userAccount = await _userService.GetUserAccountAsync(id);
			return View(userAccount);
		}

		//public async Task<IActionResult> Index()
		//{
		//	var viewModel = new AccountViewModel();


		//	return View(viewModel);
		//}
	}
}
