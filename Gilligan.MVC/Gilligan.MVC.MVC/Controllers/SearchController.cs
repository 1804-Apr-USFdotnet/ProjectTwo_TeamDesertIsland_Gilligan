using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using Gilligan.MVC.DomainContracts;
using Gilligan.MVC.ViewModels.Music;
using Gilligan.MVC.ViewModels.Search;
using Newtonsoft.Json;

namespace Gilligan.MVC.MVC.Controllers
{
    public class SearchController : AServiceController
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        public ActionResult Index()
        {
            return View();

        }

        public async Task<ActionResult> SearchSongsAsync(SearchViewModel viewModel)
        {
            if (!ModelState.IsValid) return View("", viewModel);

            var request = CreateRequestToService(HttpMethod.Get, "api/search/songs/" + viewModel.SearchString, viewModel.SearchString);

            var result = await HttpClient.SendAsync(request);

            var vm = await result.Content.ReadAsAsync<IEnumerable<SongViewModel>>();

            return View(vm);
        }

        public async Task<ActionResult> SearchAlbumsAsync(SearchViewModel viewModel)
        {
            if (!ModelState.IsValid) return View("", viewModel);

            var request = CreateRequestToService(HttpMethod.Get, "api/search/albums/" + viewModel.SearchString, viewModel.SearchString);

            var result = await HttpClient.SendAsync(request);

            //var vm = JsonConvert.DeserializeObject<IEnumerable<>()

            var vm = await result.Content.ReadAsAsync<IEnumerable<AlbumViewModel>>();

            return View(vm);
        }

        public async Task<ActionResult> SearchGenresAsync(SearchViewModel viewModel)
        {
            if (!ModelState.IsValid) return View("", viewModel);

            var request = CreateRequestToService(HttpMethod.Get, "api/search/genres/" + viewModel.SearchString, viewModel.SearchString);

            var result = await HttpClient.SendAsync(request);

            var vm = await result.Content.ReadAsAsync<IEnumerable<GenreViewModel>>();

            return View(vm);
        }

        public async Task<ActionResult> SearchArtistsAsync(SearchViewModel viewModel)
        {
            if (!ModelState.IsValid) return View("", viewModel);

            var request = CreateRequestToService(HttpMethod.Get, "api/search/artist/" + viewModel.SearchString, viewModel.SearchString);

            var result = await HttpClient.SendAsync(request);

            var vm = await result.Content.ReadAsAsync<IEnumerable<ArtistViewModel>>();

            return View(vm);
        }
    }
}