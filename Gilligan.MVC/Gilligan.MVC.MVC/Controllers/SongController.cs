using System.Web.Mvc;
using Gilligan.MVC.DomainContracts;

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

        //RemoveSongAsync

        //RateSongAsync
    }
}
