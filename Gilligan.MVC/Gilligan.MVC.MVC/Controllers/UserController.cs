using System.Web.Mvc;
using Gilligan.MVC.DomainContracts;

namespace Gilligan.MVC.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
    }
}