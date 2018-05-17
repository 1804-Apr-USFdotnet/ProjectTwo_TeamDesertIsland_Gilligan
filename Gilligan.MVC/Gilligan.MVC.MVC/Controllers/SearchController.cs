using System.Web.Mvc;
using Gilligan.MVC.DomainContracts;

namespace Gilligan.MVC.MVC.Controllers
{
    public class SearchController : Controller
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }
    }
}