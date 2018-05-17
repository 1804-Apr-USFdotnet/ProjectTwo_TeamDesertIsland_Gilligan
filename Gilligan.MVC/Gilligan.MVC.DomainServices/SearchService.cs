using System.Collections.Generic;
using System.Threading.Tasks;
using Gilligan.MVC.DomainContracts;
using Gilligan.MVC.ViewModels.Music;
using Gilligan.MVC.ViewModels.Search;

namespace Gilligan.MVC.DomainServices
{
    public class SearchService : ISearchService
    {
        private readonly IHttpService _httpService;

        public SearchService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<IEnumerable<SongViewModel>> SearchSongsAsync(SearchViewModel viewModel)
        {
            const string searchSongsAsyncUri = "";

            return await _httpService.GetEntityAsync(viewModel, new List<SongViewModel>(), searchSongsAsyncUri);
        }

        public async Task<IEnumerable<AlbumViewModel>> SearchAlbumsAsync(SearchViewModel viewModel)
        {
            const string searchAlbumsAsyncUri = "";

            return await _httpService.GetEntityAsync(viewModel, new List<AlbumViewModel>(), searchAlbumsAsyncUri);
        }

        public async Task<IEnumerable<GenreViewModel>> SearchGenresAsync(SearchViewModel viewModel)
        {
            const string searchGenreAsyncUri = "";

            return await _httpService.GetEntityAsync(viewModel, new List<GenreViewModel>(), searchGenreAsyncUri);
        }

        public async Task<IEnumerable<ArtistViewModel>> SearchArtistsAsync(SearchViewModel viewModel)
        {
            const string searchGenreAsyncUri = "";

            return await _httpService.GetEntityAsync(viewModel, new List<ArtistViewModel>(), searchGenreAsyncUri);
        }
    }
}
