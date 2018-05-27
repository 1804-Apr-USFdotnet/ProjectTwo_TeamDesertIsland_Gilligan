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
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> SongRatings(int takeAmount)
        {
            var request = CreateRequestToService(HttpMethod.Get, "api/rating/song", takeAmount.ToString());

            var result = await HttpClient.SendAsync(request);

            var vm = await result.Content.ReadAsAsync<SongRatingsViewModel>();

            return View();
        }

        public async Task<ActionResult> ArtistRatings(int takeAmount)
        {
            var request = CreateRequestToService(HttpMethod.Get, "api/rating/artist", takeAmount.ToString());

            var result = await HttpClient.SendAsync(request);

            var vm = await result.Content.ReadAsAsync<ArtistRatingViewModel>();

            return View();
        }

        public async Task<ActionResult> AlbumRatings(int takeAmount)
        {
            var request = CreateRequestToService(HttpMethod.Get, "api/rating/album", takeAmount.ToString());

            var result = await HttpClient.SendAsync(request);

            var vm = await result.Content.ReadAsAsync<AlbumRatingsViewModel>();

            return View();
        }

        public async Task<ActionResult> GenreRatings(int takeAmount)
        {
            var request = CreateRequestToService(HttpMethod.Get, "api/rating/genre", takeAmount.ToString());

            var result = await HttpClient.SendAsync(request);

            var vm = await result.Content.ReadAsAsync<GenreRatingViewModel>();

            return View();
        }

        public Task<ActionResult> AddRating(AddRatingViewModel viewModel)
        {
            var asJson = JsonConvert.SerializeObject(viewModel);

            var request = CreateRequestToService(HttpMethod.Get, "api/rating/genre", asJson);

            var result = await HttpClient.SendAsync(request);
        }
    }
}