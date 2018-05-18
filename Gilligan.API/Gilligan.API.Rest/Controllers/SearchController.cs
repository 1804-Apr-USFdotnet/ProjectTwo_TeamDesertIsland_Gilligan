using System.Web.Http;
using AutoMapper;
using Gilligan.API.DomainContracts;

namespace Gilligan.API.Rest.Controllers
{
    public class SearchController : ApiController
    {
        private readonly ISpotifyService _spotifyService;
        private readonly IMapper _mapper;

        public SearchController(ISpotifyService spotifyService, IMapper mapper)
        {
            _spotifyService = spotifyService;
            _mapper = mapper;
        }
    }
}
