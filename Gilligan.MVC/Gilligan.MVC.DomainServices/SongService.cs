using System.Net;
using System.Threading.Tasks;
using Gilligan.MVC.DomainContracts;
using Gilligan.MVC.ViewModels;

namespace Gilligan.MVC.DomainServices
{
    public class SongService : ISongService
    {
        private readonly IHttpService _httpService;

        public SongService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<HttpStatusCode> AddSongAsync(AddRemoveSongViewModel viewModel)
        {
            return await _httpService.CreateEntityAsync(viewModel);
        }

        public async Task<HttpStatusCode> RemoveSongAsync(AddRemoveSongViewModel viewModel)
        {
            return await _httpService.DeleteEntityAsync(viewModel);
        }

        public async Task<HttpStatusCode> RateSongAsync(RatingViewModel viewModel)
        {
            return await _httpService.CreateEntityAsync(viewModel);
        }
    }
}
