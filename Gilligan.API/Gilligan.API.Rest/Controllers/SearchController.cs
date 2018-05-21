using System.Web.Http;
using AutoMapper;

namespace Gilligan.API.Rest.Controllers
{
    public class SearchController : ApiController
    {
        
        private readonly IMapper _mapper;

        public SearchController(IMapper mapper)
        {
            
            _mapper = mapper;
        }
    }
}
