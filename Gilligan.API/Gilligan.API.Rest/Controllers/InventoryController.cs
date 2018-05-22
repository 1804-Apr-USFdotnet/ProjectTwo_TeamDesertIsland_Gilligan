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

            var song = _mapper.Map<Song>(viewModel.SongViewModel);
            var user = _mapper.Map<User>(viewModel.UserViewModel);

            _inventoryService.AddSongToUser(song, user);

            return Ok();
        }

        [HttpDelete]
        [Route("usersong")]
        public IHttpActionResult RemoveSongFromUser(AddRemoveUserSongViewModel viewModel)
        {
            if (!ModelState.IsValid) return BadRequest("Invalid Model State");

            var song = _mapper.Map<Song>(viewModel.SongId);
            var user = _mapper.Map<User>(viewModel.UserId);

            _inventoryService.RemoveSongFromUser(song, user);

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
    }
}
