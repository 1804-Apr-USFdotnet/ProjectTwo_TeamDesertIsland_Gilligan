using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using Gilligan.API.DomainContracts;
using Gilligan.API.ViewModels;
using Microsoft.Ajax.Utilities;

namespace Gilligan.API.Rest.Controllers
{
    [RoutePrefix("api/search")]
    public class SearchController : ApiController
    {
        private readonly ISearchService _searchService;
        private readonly IMapper _mapper;

        public SearchController(IMapper mapper, ISearchService searchService)
        {
            _mapper = mapper;
            _searchService = searchService;
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("songs/{value}")]
        public IHttpActionResult SearchSongs(string value)
        {
            if (value.IsNullOrWhiteSpace()) return BadRequest("Null Value");

            var songs = _searchService.SearchLocalSongs(value);

            var viewModel = _mapper.Map<IEnumerable<SongViewModel>>(songs);

            return Ok(viewModel);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("albums/{value}")]
        public IHttpActionResult SearchAlbums(string value)
        {
            if (value.IsNullOrWhiteSpace()) return BadRequest("Null Value");

            var albums = _searchService.SearchLocalAlbums(value);

            var viewModel = _mapper.Map<IEnumerable<AlbumViewModel>>(albums);

            return Ok(viewModel);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("artists/{value}")]
        public IHttpActionResult SearchArtists(string value)
        {
            if (value.IsNullOrWhiteSpace()) return BadRequest("Null Value");

            var artists = _searchService.SearchLocalArtists(value);

            var viewModel = _mapper.Map<IEnumerable<ArtistViewModel>>(artists);

            return Ok(viewModel);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("genres/{value}")]
        public IHttpActionResult SearchGenres(string value)
        {
            if (value.IsNullOrWhiteSpace()) return BadRequest("Null Value");

            var genres = _searchService.SearchLocalGenres(value);

            var viewModel = _mapper.Map<IEnumerable<GenreViewModel>>(genres);

            return Ok(viewModel);
        }
    }
}
