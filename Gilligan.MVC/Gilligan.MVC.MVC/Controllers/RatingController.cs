using Gilligan.MVC.ViewModels.Music;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Gilligan.MVC.MVC.Controllers
{
    public class RatingController : AServiceController
    {
        // GET: Rating
        //public ActionResult Index()
        //{
        //    return View();
        //}
        private const int takeAmount = 10;

        public async Task<ActionResult> SongRatings(int? takeAmount)
        {
            var request = CreateGet(HttpMethod.Get, "api/rating/song" + takeAmount);

            var result = await HttpClient.SendAsync(request);

            var vm = await result.Content.ReadAsAsync<SongRatingsViewModel>();

            return View(vm);
        }

        public async Task<ActionResult> ArtistRatings(int? takeAmount)
        {
            var request = CreateGet(HttpMethod.Get, "api/rating/artist" + takeAmount);

            var result = await HttpClient.SendAsync(request);

            var vm = await result.Content.ReadAsAsync<ArtistRatingViewModel>();

            return View(vm);
        }

        public async Task<ActionResult> AlbumRatings(int? takeAmount)
        {
            var request = CreateGet(HttpMethod.Get, "api/rating/album" + takeAmount);

            var result = await HttpClient.SendAsync(request);

            var vm = await result.Content.ReadAsAsync<AlbumRatingsViewModel>();

            return View(vm);
        }

        public async Task<ActionResult> GenreRatings(int? takeAmount)
        {
            var request = CreateGet(HttpMethod.Get, "api/rating/genre" + takeAmount);

            var result = await HttpClient.SendAsync(request);

            var vm = await result.Content.ReadAsAsync<GenreRatingViewModel>();

            return View(vm);
        }

        public async Task<RedirectToRouteResult> AddRating(AddRatingViewModel viewModel)
        {
            var asJson = JsonConvert.SerializeObject(viewModel);

            var request = CreateRequestToService(HttpMethod.Post, "api/rating/genre", asJson);

            var result = await HttpClient.SendAsync(request);

            return RedirectToAction("Index", "Home");
        }
    }
}