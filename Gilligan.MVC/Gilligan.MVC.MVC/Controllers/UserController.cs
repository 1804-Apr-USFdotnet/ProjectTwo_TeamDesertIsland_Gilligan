using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web.Mvc;
using Gilligan.MVC.DomainContracts;
using Gilligan.MVC.ViewModels.User;

namespace Gilligan.MVC.MVC.Controllers
{
    public class UserController : AServiceController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<ActionResult> RegisterAsync(Account account)
        {
            if (!ModelState.IsValid) return View("", account);

            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Post, "api/Account/Register", null);
            apiRequest.Content = new ObjectContent<Account>(account, new JsonMediaTypeFormatter());

            var response = await HttpClient.SendAsync(apiRequest);

            return RedirectToAction("Index", "Home");
        }

        public async Task<ActionResult> LogInAsync(Account account)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Post, "api/Account/Login", null);
            apiRequest.Content = new ObjectContent<Account>(account, new JsonMediaTypeFormatter());

            HttpResponseMessage apiResponse;
            try
            {
                apiResponse = await HttpClient.SendAsync(apiRequest);
            }
            catch
            {
                return View("Error");
            }

            if (!apiResponse.IsSuccessStatusCode)
            {
                return View("Error");
            }

            PassCookiesToClient(apiResponse);

            return RedirectToAction("Index", "Home");
        }

        public async Task<ActionResult> LogOutAsync()
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, "api/Account/Logout", null);

            HttpResponseMessage apiResponse;

            try
            {
                apiResponse = await HttpClient.SendAsync(apiRequest);
            }
            catch
            {
                return View("Error");
            }

            if (!apiResponse.IsSuccessStatusCode)
            {
                return View("Error");
            }

            PassCookiesToClient(apiResponse);

            return RedirectToAction("Index", "Home");
        }

        private bool PassCookiesToClient(HttpResponseMessage apiResponse)
        {
            if (apiResponse.Headers.TryGetValues("Set-Cookie", out IEnumerable<string> values))
            {
                foreach (string value in values)
                {
                    Response.Headers.Add("Set-Cookie", value);
                }
                return true;
            }
            return false;
        }

        public ActionResult Index ()
        {
            return View();
        }

        public ActionResult AddUser()
        {
            return View();
        }

        public async Task<ActionResult> CreateUser(UserViewModel viewModel)
        {
            var request = CreateRequestToService(HttpMethod.Post, "api/Account/User", null);
            request.Content = new ObjectContent<UserViewModel>(viewModel, new JsonMediaTypeFormatter());

            var response = await HttpClient.SendAsync(request);

            return RedirectToAction("Index", "Home");
        }
    }
}