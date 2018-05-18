using System.Web.Http;
using AutoMapper;
using Gilligan.API.DomainContracts;

namespace Gilligan.API.Rest.Controllers
{
    public class RatingController : ApiController
    {
        private readonly IRatingService _ratingService;
        private readonly IMapper _mapper;

        public RatingController(IRatingService ratingService, IMapper mapper)
        {
            _ratingService = ratingService;
            _mapper = mapper;
        }
    }
}
