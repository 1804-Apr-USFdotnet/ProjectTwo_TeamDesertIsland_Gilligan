using System.Web.Http;
using AutoMapper;
using Gilligan.API.DomainContracts;

namespace Gilligan.API.Rest.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
    }
}
