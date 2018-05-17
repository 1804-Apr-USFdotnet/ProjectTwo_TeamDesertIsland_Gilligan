using Gilligan.MVC.DomainContracts;

namespace Gilligan.MVC.DomainServices
{
    public class SearchService : ISearchService
    {
        private readonly IHttpService _httpService;

        public SearchService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public void SearchSongsAsync()
        {
            throw new System.NotImplementedException();
        }

        public void SearchAlbumsAsync()
        {
            throw new System.NotImplementedException();
        }

        public void SearchGenresAsync()
        {
            throw new System.NotImplementedException();
        }

        public void SearchArtistsAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
