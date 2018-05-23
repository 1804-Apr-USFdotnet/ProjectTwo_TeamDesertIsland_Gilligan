using System;
using System.Collections.Generic;
using System.Linq;
using Gilligan.API.DomainServices;
using Gilligan.API.Models;
using Gilligan.API.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gilligan.API.Tests.Integration.DomainServices
{
    [TestClass]
    public class SearchServiceTests
    {
        private readonly SearchService _searchService;
        private readonly GilliganTestContext _context;

        public SearchServiceTests()
        {
            _context = new GilliganTestContext();
            _searchService = new SearchService(new SongRepository(_context), new AlbumRepository(_context),
                new ArtistRepository(_context), new GenreRepository(_context));
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
        public void SearchLocalSongs_String_ReturnsMatchingSongs()
        {
            var songs = new List<Song>
            {
                new Song{Id = Guid.NewGuid(), Name = "Bob's Revenge", Album = new Album{Id = Guid.NewGuid()}},
                new Song{Id = Guid.NewGuid(), Name = "Marty", Album = new Album{Id = Guid.NewGuid()}}
            };

            _context.Songs.AddRange(songs);
            _context.SaveChanges();

            var result = _searchService.SearchLocalSongs("Bob").ToList();

            const int expected = 1;

            Assert.AreEqual(expected, result.Count);
        }

        [TestMethod]
        public void SearchLocalAlbums_String_ReturnsMatchingAlbums()
        {
            var albums = new List<Album>
            {
                new Album{Id = Guid.NewGuid(), Name = "Rick"},
                new Album{Id = Guid.NewGuid(), Name = "Morth"}
            };

            _context.Albums.AddRange(albums);
            _context.SaveChanges();

            var results = _searchService.SearchLocalAlbums("mor").ToList();

            const int expected = 1;

            Assert.AreEqual(expected, results.Count);
        }

        [TestMethod]
        public void SearchLocalArtists_String_ReturnsMatchingArtists()
        {
            var artists = new List<Artist>
            {
                new Artist{Id = Guid.NewGuid(), Name = "Rickie Rick"},
                new Artist{Id = Guid.NewGuid(), Name = "Mortimer"}
            };

            _context.Artists.AddRange(artists);
            _context.SaveChanges();

            var results = _searchService.SearchLocalArtists("Mort").ToList();

            const int expected = 1;

            Assert.AreEqual(expected, results.Count);
        }

        [TestMethod]
        public void SearchLocalGenres_String_ReturnsMatchingGenres()
        {
            var genres = new List<Genre>
            {
                new Genre{Id = Guid.NewGuid(), Name = "Hard Rick"},
                new Genre{Id = Guid.NewGuid(), Name = "Soft Morty"}
            };

            _context.Genres.AddRange(genres);
            _context.SaveChanges();

            var results = _searchService.SearchLocalGenres("Rick").ToList();

            const int expected = 1;

            Assert.AreEqual(expected, results.Count);
        }
    }
}
