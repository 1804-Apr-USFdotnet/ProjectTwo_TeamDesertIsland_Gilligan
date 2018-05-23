using System.Web.Http;
using AutoMapper;
using Gilligan.API.DomainContracts;
using Gilligan.API.Models;
using Gilligan.API.ViewModels;

namespace Gilligan.API.Rest.Controllers
{
    [RoutePrefix("api/inventory")]
    public class InventoryController : ApiController
    {
        private readonly IInventoryService _inventoryService;
        private readonly IMapper _mapper;

        public InventoryController(IInventoryService inventoryService, IMapper mapper)
        {
            _inventoryService = inventoryService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("usersong")]
        public IHttpActionResult AddSongToUser(AddRemoveUserSongViewModel viewModel)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid Model State");

            var userSong = _mapper.Map<UserSong>(viewModel);

            _inventoryService.AddSongToUser(userSong);

            return Ok();
        }

        [HttpDelete]
        [Route("usersong")]
        public IHttpActionResult RemoveSongFromUser(AddRemoveUserSongViewModel viewModel)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid Model State");

            var userSong = _mapper.Map<UserSong>(viewModel);

            _inventoryService.RemoveSongFromUser(userSong);

            return Ok();
        }

        [HttpPost]
        [Route("song")]
        public IHttpActionResult AddSongToInventory(AddSongViewModel viewModel)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid Model State");

            var song = _mapper.Map<Song>(viewModel);

            _inventoryService.AddSong(song);

            return Ok();
        }

        [HttpPost]
        [Route("album")]
        public IHttpActionResult AddAlbumToInventory(AddAlbumViewModel viewModel)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid Model State");

            var album = _mapper.Map<Album>(viewModel);

            _inventoryService.AddAlbum(album);

            return Ok();
        }

        [HttpPost]
        [Route("artist")]
        public IHttpActionResult AddArtistToInventory(AddArtistViewModel viewModel)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid Model State");

            var artist = _mapper.Map<Artist>(viewModel);
            
            _inventoryService.AddArtist(artist);

            return Ok();
        }

        [HttpPost]
        [Route("genre")]
        public IHttpActionResult AddGenreToInventory(AddGenreViewModel viewModel)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid Model State");

            var genre = _mapper.Map<Genre>(viewModel);

            _inventoryService.AddGenre(genre);

            return Ok();
        }
    }
}
