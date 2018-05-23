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
            searchService.Setup(x => x.SearchLocalAlbums(It.IsAny<string>())).Returns(new List<Album>());
            searchService.Setup(x => x.SearchLocalGenres(It.IsAny<string>())).Returns(new List<Genre>());
            searchService.Setup(x => x.SearchLocalArtists(It.IsAny<string>())).Returns(new List<Artist>());

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

        [TestMethod]
        public void SearchAlbums_InvalidString_ReturnsBadRequest()
        {
            _searchController.ModelState.AddModelError("Error", "Bad");

            var result = _searchController.SearchAlbums("");

            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        [TestMethod]
        public void SearchALbums_String_ReturnsOk()
        {
            var result = _searchController.SearchAlbums("Meh");

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<IEnumerable<AlbumViewModel>>));
        }

        [TestMethod]
        public void SearchSongs_String_ReturnsCorrecType()
        {
            var result = _searchController.SearchAlbums("Meh");

            var resultType = result as OkNegotiatedContentResult<IEnumerable<AlbumViewModel>>;

            Assert.IsInstanceOfType(resultType.Content, typeof(IEnumerable<AlbumViewModel>));
        }

        [TestMethod]
        public void SearchArtists_InvalidString_ReturnsBadRequest()
        {
            _searchController.ModelState.AddModelError("Error", "Bad");

            var result = _searchController.SearchArtists("");

            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        [TestMethod]
        public void SearchArtists_String_ReturnsOk()
        {
            var result = _searchController.SearchArtists("Meh");

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<IEnumerable<ArtistViewModel>>));
        }

        [TestMethod]
        public void SearchArtists_String_ReturnsCorrectType()
        {
            var result = _searchController.SearchArtists("Meh");

            var resultType = result as OkNegotiatedContentResult<IEnumerable<ArtistViewModel>>;

            Assert.IsInstanceOfType(resultType.Content, typeof(IEnumerable<ArtistViewModel>));
        }

        [TestMethod]
        public void SearchGenres_InvalidString_ReturnsBadRequest()
        {
            _searchController.ModelState.AddModelError("Error", "Bad");

            var result = _searchController.SearchGenres("");

            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
        }

        [TestMethod]
        public void SearchGenres_String_ReturnsOk()
        {
            var result = _searchController.SearchGenres("Meh");

            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<IEnumerable<GenreViewModel>>));
        }

        [TestMethod]
        public void SearchGenres_String_ReturnsCorrectType()
        {
            var result = _searchController.SearchGenres("Meh");

            var resultType = result as OkNegotiatedContentResult<IEnumerable<GenreViewModel>>;

            Assert.IsInstanceOfType(resultType.Content, typeof(IEnumerable<GenreViewModel>));
        }
    }
}
