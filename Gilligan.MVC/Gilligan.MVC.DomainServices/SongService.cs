using System.Net;
using System.Threading.Tasks;
using Gilligan.MVC.DomainContracts;
using Gilligan.MVC.ViewModels.Music;
using Gilligan.MVC.ViewModels.User;

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
            const string addSongUri = "";

            return await _httpService.UpdateEntityAsync(viewModel, addSongUri);
        }

        public async Task<HttpStatusCode> RemoveSongAsync(AddRemoveSongViewModel viewModel)
        {
            const string removeSongUri = "";

            return await _httpService.UpdateEntityAsync(viewModel, removeSongUri);
        }

        public async Task<HttpStatusCode> RateSongAsync(RatingViewModel viewModel)
        {
            const string rateSongUri = "";

            return await _httpService.CreateEntityAsync(viewModel, rateSongUri);
        }
    }
}
