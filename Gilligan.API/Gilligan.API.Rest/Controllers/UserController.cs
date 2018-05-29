using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using AutoMapper;
using Gilligan.API.DomainContracts;
using Gilligan.API.Models;
using Gilligan.API.Repositories;
using Gilligan.API.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace Gilligan.API.Rest.Controllers
{
    public class UserController : ApiController
    {
        private readonly IInventoryService _userService;
        private readonly IMapper _mapper;

        public UserController(IInventoryService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("~/api/Account/Register")]
        [AllowAnonymous]
        public IHttpActionResult Register(Account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            // actually register
            var userStore = new UserStore<IdentityUser>(new GilliganContext());
            var userManager = new UserManager<IdentityUser>(userStore);
            var user = new IdentityUser(account.UserName);

            if (userManager.Users.Any(u => u.UserName == account.UserName))
            {
                return BadRequest();
            }

            userManager.Create(user, account.Password);

            return Ok();
        }

        [HttpPost]
        [Route("~/api/Account/RegisterAdmin")]
        [AllowAnonymous]
        public IHttpActionResult RegisterAdmin(Account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            // actually register
            var userStore = new UserStore<IdentityUser>(new GilliganContext());
            var userManager = new UserManager<IdentityUser>(userStore);
            var user = new IdentityUser(account.UserName);

            if (userManager.Users.Any(u => u.UserName == account.UserName))
            {
                return BadRequest();
            }

            userManager.Create(user, account.Password);

            // the only difference from Register action
            userManager.AddClaim(user.Id, new Claim(ClaimTypes.Role, "admin"));

            return Ok();
        }

        [HttpPost]
        [Route("~/api/Account/Login")]
        [AllowAnonymous]
        public IHttpActionResult LogIn(Account account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            // actually login
            var userStore = new UserStore<IdentityUser>(new GilliganContext());
            var userManager = new UserManager<IdentityUser>(userStore);
            var user = userManager.Users.FirstOrDefault(u => u.UserName == account.UserName);

            if (user == null)
            {
                return BadRequest();
            }

            if (!userManager.CheckPassword(user, account.Password))
            {
                return Unauthorized();
            }

            var authManager = Request.GetOwinContext().Authentication;
            var claimsIdentity = userManager.CreateIdentity(user, WebApiConfig.AuthenticationType);

            authManager.SignIn(new AuthenticationProperties { IsPersistent = true }, claimsIdentity);

            return Ok();
        }

        [HttpGet]
        [Route("~/api/Account/Logout")]
        public IHttpActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut(WebApiConfig.AuthenticationType);
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("~/api/Account/User")]
        public IHttpActionResult NewUser(UserViewModel viewModel)
        {
            var user = new User
            {
                Id = Guid.NewGuid(), 
                UserId = Guid.NewGuid(),
                UserName = viewModel.UserName
            };

            var context = new GilliganContext();

            context.Users.Add(user);
            context.SaveChanges();

            return Ok();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("~/api/Account/User")]
        public IHttpActionResult AllUsers()
        {
            var context = new GilliganContext();
            var users = context.Users.ToList();

            var vm = _mapper.Map<IEnumerable<UserViewModel>>(users);

            return Ok(vm);
        }
    }
}
