using System.Net;
using System.Threading.Tasks;
using Gilligan.MVC.ViewModels.Music;
using Gilligan.MVC.ViewModels.User;

namespace Gilligan.MVC.DomainContracts
{
    public interface ISongService
    {
        Task<HttpStatusCode> AddSongAsync(AddRemoveUserSongViewModel viewModel);
        Task<HttpStatusCode> RemoveSongAsync(AddRemoveUserSongViewModel viewModel);
        Task<HttpStatusCode> RateSongAsync(RatingViewModel viewModel);
    }
}
