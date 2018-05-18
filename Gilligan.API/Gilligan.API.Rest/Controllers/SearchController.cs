using System.Web.Http;
using AutoMapper;
using Gilligan.API.DomainContracts;

namespace Gilligan.API.Rest.Controllers
{
    public class SearchController : ApiController
    {
        private readonly ISearchService _searchService;
        private readonly IMapper _mapper;

        public SearchController(ISearchService searchService, IMapper mapper)
        {
            _searchService = searchService;
            _mapper = mapper;
        }
    }
}
