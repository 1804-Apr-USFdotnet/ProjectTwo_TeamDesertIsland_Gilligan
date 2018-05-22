using System.Collections.Generic;
using System.Web.Http.Results;
using Autofac;
using AutoMapper;
using Gilligan.API.DomainContracts;
using Gilligan.API.Models;
using Gilligan.API.Rest;
using Gilligan.API.Rest.Controllers;
using Gilligan.API.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Gilligan.API.Tests.Unit.Rest
{
    [TestClass]
    public class SearchControllerTests
    {
        private readonly SearchController _searchController;

        public SearchControllerTests()
        {
            var container = Bootstrapper.RegisterTypes();
            var mapper = container.Resolve<IMapper>();
            var searchService = new Mock<ISearchService>();
            searchService.Setup(x => x.SearchLocalSongs(It.IsAny<string>())).Returns(new List<Song>());

            _searchController = new SearchController(mapper, searchService.Object);
        }

        [TestMethod]
        public void SearchSongs_InvalidString_ReturnsBadRequest()
        {
            _searchController.ModelState.AddModelError("Error", "Bad");

            var result = _searchController.SearchSongs("");

            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        [TestMethod]
        public void SearchSongs_String_ReturnsOk()
        {
            var result = _searchController.SearchSongs("stuff");

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<IEnumerable<SongViewModel>>));
        }

        [TestMethod]
        public void SearchSongs_String_ReturnsCorrectType()
        {
            var result = _searchController.SearchSongs("stuff");

            var resultType = result as OkNegotiatedContentResult<IEnumerable<SongViewModel>>;

            Assert.IsInstanceOfType(resultType.Content, typeof(IEnumerable<SongViewModel>));
        }
    }
}
