using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Gilligan.MVC.DomainContracts;
using Gilligan.MVC.ViewModels.User;

namespace Gilligan.MVC.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ActionResult> RegisterAsync(CreateUserViewModel viewModel)
        {
            if (!ModelState.IsValid) return View("", viewModel);

            var result = await _userService.RegisterAsync(viewModel);

            if (result == HttpStatusCode.Created) return View("");

            return View("");
        }

        public async Task<ActionResult> LogInAsync(LogInUserViewModel viewModel)
        {
            if (!ModelState.IsValid) return View("", viewModel);

            var result = await _userService.LogInAsync(viewModel);

            if (result == HttpStatusCode.Created) return View("");

            return View("");
        }

        public async Task<ActionResult> LogOutAsync(LogOutUserViewModel viewModel)
        {
            if (!ModelState.IsValid) return View("", viewModel);

            var result = await _userService.LogOutAsync(viewModel);

            if (result == HttpStatusCode.Created) return View("");

            return View("");
        }
    }
}