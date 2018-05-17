using System;
using System.Net;
using System.Threading.Tasks;
using Gilligan.MVC.ViewModels;

namespace Gilligan.MVC.DomainContracts
{
    public class SongService : ISongService
    {
        private readonly IHttpService<SongViewModel> _httpService;

        public SongService(IHttpService<SongViewModel> httpService)
        {
            _httpService = httpService;
        }

        public async Task<HttpStatusCode> AddSongAsync(AddRemoveSongViewModel viewModel)
        {
            return await _httpService.CreateEntityAsync(viewModel);
        }

        public async Task<HttpStatusCode> RemoveSongAsync(AddRemoveSongViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpStatusCode> RateSongAsync()
        {
            throw new NotImplementedException();
        }
    }
}
