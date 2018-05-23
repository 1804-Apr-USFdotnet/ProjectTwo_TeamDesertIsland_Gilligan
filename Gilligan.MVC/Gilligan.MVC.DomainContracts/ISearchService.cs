using System.Collections.Generic;
using System.Threading.Tasks;
using Gilligan.MVC.ViewModels.Music;
using Gilligan.MVC.ViewModels.Search;

namespace Gilligan.MVC.DomainContracts
{
    public interface ISearchService
    {
        Task<IEnumerable<SongViewModel>> SearchSongsAsync(SearchViewModel viewModel);
        Task<IEnumerable<AlbumViewModel>> SearchAlbumsAsync(SearchViewModel viewModel);
        Task<IEnumerable<GenreViewModel>> SearchGenresAsync(SearchViewModel viewModel);
        Task<IEnumerable<ArtistViewModel>> SearchArtistsAsync(SearchViewModel viewModel);
    }
}
