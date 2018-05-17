using System;
using System.Threading.Tasks;
using Gilligan.MVC.DomainContracts;
using Gilligan.MVC.ViewModels;

namespace Gilligan.MVC.DomainServices
{
    public class UserService : IUserService
    {
        private readonly IHttpService<UserViewModel> _httpService;

        public UserService(IHttpService<UserViewModel> httpService)
        {
            _httpService = httpService;
        }

        public void LogInAsync()
        {
            throw new NotImplementedException();
        }

        public void LogOutAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateInformationAsync()
        {
            throw new NotImplementedException();
        }
    }
}
