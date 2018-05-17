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

        public async Task<HttpStatusCode> RegisterAsync(CreateUserViewModel viewModel)
        {
            const string registerUri = "";

            return await _httpService.CreateEntityAsync(viewModel, registerUri);
        }

        public async Task<HttpStatusCode> LogInAsync(LogInUserViewModel viewModel)
        {
            const string logInAsyncUri = "";

            return await _httpService.UpdateEntityAsync(viewModel, logInAsyncUri);
        }

        public async Task<HttpStatusCode> LogOutAsync(LogOutUserViewModel viewModel)
        {
            const string logOutAsyncUri = "";

            return await _httpService.UpdateEntityAsync(viewModel, logOutAsyncUri);
        }

        public async Task<HttpStatusCode> UpdateAsync(UpdateUserViewModel viewModel)
        {
            const string updateAsyncUri = "";

            return await _httpService.UpdateEntityAsync(viewModel, updateAsyncUri);
        }

        public async Task<HttpStatusCode> DeleteAsync(DeleteUserViewModel viewModel)
        {
            const string deleteAsyncUri = "";

            return await _httpService.DeleteEntityAsync(viewModel, deleteAsyncUri);
        }
    }
}
