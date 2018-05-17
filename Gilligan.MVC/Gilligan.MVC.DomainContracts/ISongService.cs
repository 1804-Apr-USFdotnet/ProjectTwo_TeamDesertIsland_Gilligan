using System.Net;
using System.Threading.Tasks;
using Gilligan.MVC.ViewModels;

namespace Gilligan.MVC.DomainContracts
{
    public interface ISongService
    {
        Task<HttpStatusCode> AddSongAsync(AddRemoveSongViewModel viewModel);
        Task<HttpStatusCode> RemoveSongAsync(AddRemoveSongViewModel viewModel);
        Task<HttpStatusCode> RateSongAsync(RatingViewModel viewModel);
    }
}
