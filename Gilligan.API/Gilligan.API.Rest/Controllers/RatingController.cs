using System.Web.Http;
using AutoMapper;
using Gilligan.API.DomainContracts;
using Gilligan.API.Models;
using Gilligan.API.ViewModels;

namespace Gilligan.API.Rest.Controllers
{
    [RoutePrefix("api/rating")]
    public class RatingController : ApiController
    {
        private readonly IRatingService _ratingService;
        private readonly IMapper _mapper;

        public RatingController(IRatingService ratingService, IMapper mapper)
        {
            _ratingService = ratingService;
            _mapper = mapper;
        }

        [HttpPost]
        public IHttpActionResult AddRating(AddRatingViewModel viewModel)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid Model State");

            var rating = _mapper.Map<Rating>(viewModel);

            _ratingService.AddRating(rating);

            return Ok();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("album/{takeAmount}")]
        public IHttpActionResult AlbumRatings(int takeAmount)
        {
            var albumRatings = _ratingService.AlbumRatings(takeAmount);

            var viewModel = _mapper.Map<AlbumRatingsViewModel>(albumRatings);

            return Ok(viewModel);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("song/{takeAmount}")]
        public IHttpActionResult SongRatings(int takeAmount)
        {
            var songRatings = _ratingService.SongRatings(takeAmount);

            var viewModel = _mapper.Map<SongRatingsViewModel>(songRatings);

            return Ok(viewModel);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("artist/{takeAmount}")]
        public IHttpActionResult ArtistRatings(int takeAmount)
        {
            var artistRatings = _ratingService.ArtistRatings(takeAmount);

            var viewModel = _mapper.Map<ArtistRatingsViewModel>(artistRatings);

            return Ok(viewModel);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("genre/{takeAmount}")]
        public IHttpActionResult GenreRatings(int takeAmount)
        {
            var genreRatings = _ratingService.GenreRatings(takeAmount);

            var viewModel = _mapper.Map<GenreRatingsViewModel>(genreRatings);

            return Ok(viewModel);
        }
    }
}
