using System.Web.Http;
using AutoMapper;
using Gilligan.API.DomainContracts;

namespace Gilligan.API.Rest.Controllers
{
    public class UserController : ApiController
    {
        private readonly IInventoryService _userService;
        private readonly IMapper _mapper;

        public UserController(IInventoryService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
    }
}
