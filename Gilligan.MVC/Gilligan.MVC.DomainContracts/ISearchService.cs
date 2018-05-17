using System.Collections.Generic;

namespace Gilligan.MVC.DomainContracts
{
    public interface ISearchService
    {
        void SearchSongsAsync();
        void SearchAlbumsAsync();
        void SearchGenresAsync();
        void SearchArtistsAsync();
    }
}
