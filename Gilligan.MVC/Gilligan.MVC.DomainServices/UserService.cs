using System;
using System.Net;
using System.Threading.Tasks;
using Gilligan.MVC.DomainContracts;
using Gilligan.MVC.ViewModels.User;

namespace Gilligan.MVC.DomainServices
{
    public class UserService : IUserService
    {
        private readonly IHttpService _httpService;

        public UserService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<HttpStatusCode> Register(CreateUserViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpStatusCode> LogInAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<HttpStatusCode> LogOutAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<HttpStatusCode> UpdateAsync(UpdateUserViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
