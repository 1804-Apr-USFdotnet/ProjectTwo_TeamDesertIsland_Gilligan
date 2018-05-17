using System.Net;
using System.Threading.Tasks;
using Gilligan.MVC.ViewModels.User;

namespace Gilligan.MVC.DomainContracts
{
    public interface IUserService
    {
        Task<HttpStatusCode> Register(CreateUserViewModel viewModel);
        Task<HttpStatusCode> LogInAsync();
        Task<HttpStatusCode> LogOutAsync();
        Task<HttpStatusCode> UpdateAsync(UpdateUserViewModel viewModel);
    }
}
