using System.Collections.Generic;
using Gilligan.API.DomainServices;
using Gilligan.API.Models;
using Gilligan.API.RepositoryContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Gilligan.API.Tests.Unit.DomainServices
{
    [TestClass]
    public class SearchServiceTests
    {
        private readonly SearchService _searchService;
        private readonly Mock<ISongRepository> _songRepository;
        private readonly Mock<IAlbumRepository> _albumRepository;
        private readonly Mock<IArtistRepository> _artistRepository;
        private readonly Mock<IGenreRepository> _genreRepository;

        public SearchServiceTests()
        {
            _songRepository = new Mock<ISongRepository>();
            _songRepository.Setup(x => x.Get()).Returns(new List<Song>());

            _albumRepository = new Mock<IAlbumRepository>();
            _albumRepository.Setup(x => x.Get()).Returns(new List<Album>());

            _artistRepository = new Mock<IArtistRepository>();
            _artistRepository.Setup(x => x.Get()).Returns(new List<Artist>());

            _genreRepository = new Mock<IGenreRepository>();
            _genreRepository.Setup(x => x.Get()).Returns(new List<Genre>());

            _searchService = new SearchService(_songRepository.Object, _albumRepository.Object, _artistRepository.Object, _genreRepository.Object);
        }

        [TestMethod]
        public void SearchLocalSongs_StringValue_CallsSongRepoGet()
        {
            _searchService.SearchLocalSongs("");

            _songRepository.Verify(x => x.Get(), Times.AtLeastOnce);
        }

        [TestMethod]
        public void SearchLocalAlbums_StringValue_CallsAlbumRepoGet()
        {
            _searchService.SearchLocalAlbums("");

            _albumRepository.Verify(x => x.Get(), Times.AtLeastOnce);
        }

        [TestMethod]
        public void SearchLocalArtists_StringValue_CallsArtistRepoGet()
        {
            _searchService.SearchLocalArtists("");

            _artistRepository.Verify(x => x.Get(), Times.AtLeastOnce);
        }

        [TestMethod]
        public void SearchLocalGenres_StringValue_CallsGenreRepoGet()
        {
            _searchService.SearchLocalGenres("");

            _genreRepository.Verify(x => x.Get(), Times.AtLeastOnce);
        }
    }
}
