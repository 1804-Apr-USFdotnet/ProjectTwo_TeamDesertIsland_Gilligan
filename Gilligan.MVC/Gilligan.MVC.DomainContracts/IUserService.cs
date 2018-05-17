using System.Net;
using System.Threading.Tasks;
using Gilligan.MVC.ViewModels.User;

namespace Gilligan.MVC.DomainContracts
{
    public interface IUserService
    {
        Task<HttpStatusCode> RegisterAsync(CreateUserViewModel viewModel);
        Task<HttpStatusCode> LogInAsync(LogInUserViewModel viewModel);
        Task<HttpStatusCode> LogOutAsync(LogOutUserViewModel viewModel);
        Task<HttpStatusCode> UpdateAsync(UpdateUserViewModel viewModel);
        Task<HttpStatusCode> DeleteAsync(DeleteUserViewModel viewModel);
    }
}
