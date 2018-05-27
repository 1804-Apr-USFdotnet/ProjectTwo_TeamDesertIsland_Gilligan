using Gilligan.MVC.ViewModels.Music;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Gilligan.MVC.MVC.Controllers
{
    public class RatingController : Controller
    {
        // GET: Rating
        public ActionResult Index()
        {
            return View();
        }

        public Task<ActionResult> SongRatings(int takeAmount)
        {
            return View();
        }

        public Task<ActionResult> ArtistRatings(int takeAmount)
        {
            return View();
        }

        public Task<ActionResult> AlbumRatings(int takeAmount)
        {
            return View();
        }

        public Task<ActionResult> GenreRatings(int takeAmount)
        {
            return View();
        }

        public Task<ActionResult> AddRating(AddRatingViewModel viewModel)
        {

        }
    }
}