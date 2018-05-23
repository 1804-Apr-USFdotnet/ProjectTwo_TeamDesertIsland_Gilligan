using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using Autofac;
using AutoMapper;
using Gilligan.API.DomainServices;
using Gilligan.API.Models;
using Gilligan.API.Repositories;
using Gilligan.API.Rest;
using Gilligan.API.Rest.Controllers;
using Gilligan.API.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gilligan.API.Tests.Integration.Rest
{
    [TestClass]
    public class SearchControllerTests
    {
        private readonly SearchController _searchController;
        private readonly GilliganTestContext _context;

        public SearchControllerTests()
        {
            _context = new GilliganTestContext();
            var container = Bootstrapper.RegisterTypes();
            var mapper = container.Resolve<IMapper>();
            _searchController = new SearchController(mapper, new SearchService(new SongRepository(_context), new AlbumRepository(_context), new ArtistRepository(_context), new GenreRepository(_context)));
        }

        [TestInitialize]
        public void ClearTables()
        {
            _context.Artists.RemoveRange(_context.Artists);
            _context.Genres.RemoveRange(_context.Genres);
            _context.Albums.RemoveRange(_context.Albums);
            _context.Songs.RemoveRange(_context.Songs);
            _context.SaveChanges();
        }

        [TestMethod]
        public void SearchSongs_String_ReturnsCorrectSongs()
        {
            var songs = new List<Song>
            {
                new Song{Id = Guid.NewGuid(), Name = "Bob's Revenge", Album = new Album{Id = Guid.NewGuid()}},
                new Song{Id = Guid.NewGuid(), Name = "Marty", Album = new Album{Id = Guid.NewGuid()}}
            };

            _context.Songs.AddRange(songs);
            _context.SaveChanges();

            var result = _searchController.SearchSongs("Bob") as OkNegotiatedContentResult<IEnumerable<SongViewModel>>;

            const int expected = 1;

            Assert.AreEqual(expected, result.Content.ToList().Count);
        }

        [TestMethod]
        public void SearchAlbums_String_ReturnsCorrectAlbums()
        {
            var albums = new List<Album>
            {
                new Album{Id = Guid.NewGuid(), Name = "Rick"},
                new Album{Id = Guid.NewGuid(), Name = "Morth"}
            };

            _context.Albums.AddRange(albums);
            _context.SaveChanges();

            var results = _searchController.SearchAlbums("mor") as OkNegotiatedContentResult<IEnumerable<AlbumViewModel>>;

            const int expected = 1;

            Assert.AreEqual(expected, results.Content.ToList().Count);
        }

        [TestMethod]
        public void SearchArtists_String_ReturnsCorrectArtists()
        {
            var artists = new List<Artist>
            {
                new Artist{Id = Guid.NewGuid(), Name = "Rickie Rick"},
                new Artist{Id = Guid.NewGuid(), Name = "Mortimer"}
            };

            _context.Artists.AddRange(artists);
            _context.SaveChanges();

            var results = _searchController.SearchArtists("Mort") as OkNegotiatedContentResult<IEnumerable<ArtistViewModel>>;

            const int expected = 1;

            Assert.AreEqual(expected, results.Content.ToList().Count);
        }

        [TestMethod]
        public void SearchGenres_String_ReturnsCorrectGenres()
        {
            var genres = new List<Genre>
            {
                new Genre{Id = Guid.NewGuid(), Name = "Hard Rick"},
                new Genre{Id = Guid.NewGuid(), Name = "Soft Morty"}
            };

            _context.Genres.AddRange(genres);
            _context.SaveChanges();

            var results = _searchController.SearchGenres("Rick") as OkNegotiatedContentResult<IEnumerable<GenreViewModel>>;

            const int expected = 1;

            Assert.AreEqual(expected, results.Content.ToList().Count);
        }
    }
}
