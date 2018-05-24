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

        public 
    }
}
