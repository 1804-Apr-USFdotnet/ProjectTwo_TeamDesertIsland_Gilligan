using System.Threading.Tasks;
using System.Web.Mvc;
using Gilligan.MVC.DomainContracts;
using Gilligan.MVC.ViewModels.Search;

namespace Gilligan.MVC.MVC.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        public ActionResult Index  ()
        {
            return View();

        }

        public async Task<ActionResult> SearchSongsAsync(SearchViewModel viewModel)
        {
            if (!ModelState.IsValid) return View("", viewModel);

            var result = await _searchService.SearchSongsAsync(viewModel);

            return View("", result);
        }

        public async Task<ActionResult> SearchAlbumsAsync(SearchViewModel viewModel)
        {
            if (!ModelState.IsValid) return View("", viewModel);

            var result = await _searchService.SearchAlbumsAsync(viewModel);

            return View("", result);
        }

        public async Task<ActionResult> SearchGenresAsync(SearchViewModel viewModel)
        {
            if (!ModelState.IsValid) return View("", viewModel);

            var result = await _searchService.SearchGenresAsync(viewModel);

            return View("", result);
        }

        public async Task<ActionResult> SearchArtistsAsync(SearchViewModel viewModel)
        {
            if (!ModelState.IsValid) return View("", viewModel);

            var result = await _searchService.SearchArtistsAsync(viewModel);

            return View("", result);
        }

        
    }
}