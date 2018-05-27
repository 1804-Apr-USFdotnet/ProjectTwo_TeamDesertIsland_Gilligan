using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Gilligan.MVC.DomainContracts;
using Gilligan.MVC.DomainServices;
using Gilligan.MVC.ViewModels.Music;
using Gilligan.MVC.ViewModels.User;

namespace Gilligan.MVC.MVC.Controllers
{
    public class SongController : Controller
    {
        private readonly ISongService _songService;

        public SongController(ISongService songService)
        {
            _songService = songService;
        }

        //AddSongAsync
        public async Task<ActionResult> AddSongAsync(AddRemoveUserSongViewModel viewModel)
        {
            if (!ModelState.IsValid) return View("", viewModel);

            var result = await _songService.AddSongAsync(viewModel);

            if (result == HttpStatusCode.Created) return View("");

            return View("");
        }

        //RemoveSongAsync
        public async Task<ActionResult> RemoveSongAsync(AddRemoveUserSongViewModel viewModel)
        {
            if (!ModelState.IsValid) return View("", viewModel);

            var result = await _songService.RemoveSongAsync(viewModel);

            if (result == HttpStatusCode.Created) return View("");

            return View("");
        }

        //RateSongAsync
        public async Task<ActionResult> RateSongAsync(RatingViewModel viewModel)
        {
            if (!ModelState.IsValid) return View("", viewModel);

            var result = await _songService.RateSongAsync(viewModel);

            if (result == HttpStatusCode.Created) return View("");

            return View("");
        }

        public ActionResult AddAlbum ()
        {
            return View();
        }

        public ActionResult AddArtist()
        {
            return View();
        }

        public ActionResult AddGenre()
        {
            return View();
        }

        public ActionResult AddRating()
        {
            return View();
        }

        public ActionResult AddSong()
        {
            return View();
        }

        public ActionResult Album()
        {
            return View();
        }

        public ActionResult AlbumRating()
        {
            return View();
        }

        public ActionResult Artist()
        {
            return View();
        }

        public ActionResult ArtistRating()
        {
            return View();
        }

        public ActionResult Genre()
        {
            return View();
        }

        public ActionResult GenreRating()
        {
            return View();
        }

        public ActionResult Rating()
        {
            return View();
        }

        public ActionResult Song()
        {
            return View();
        }

        public ActionResult SongRatings()
        {
            return View();
        }

        public ActionResult Index ()
        {
            return View();
        }
    }
}
