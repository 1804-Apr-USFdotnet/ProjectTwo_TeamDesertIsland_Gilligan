using System;
using System.Collections.Generic;
using System.Linq;
using Gilligan.API.Models;
using Gilligan.API.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gilligan.API.Tests.Integration.Repositories
{
    [TestClass]
    public class ArtistRepositoryTests
    {
        private readonly GilliganTestContext _context;
        private readonly ArtistRepository _artistRepository;

        public ArtistRepositoryTests()
        {
            _context = new GilliganTestContext();
            _artistRepository = new ArtistRepository(_context);
        }

        [TestInitialize]
        public void ClearTable()
        {
            _context.Artists.RemoveRange(_context.Artists);
            _context.SaveChanges();
        }

        [TestMethod]
        public void Get_Empty_ReturnsAllArtists()
        {
            var artists = new List<Artist>
            {
                new Artist{Id = Guid.NewGuid()},
                new Artist{Id = Guid.NewGuid()}
            };

            _context.Artists.AddRange(artists);
            _context.SaveChanges();

            var results = _artistRepository.Get().ToList();

            Assert.AreEqual(artists.Count, results.Count);
        }

        [TestMethod]
        public void Add_Artist_AddsArtistToDatabase()
        {
            var artist = new Artist{Id = Guid.NewGuid()};

            _artistRepository.Add(artist);

            var artists = _context.Artists.ToList();

            Assert.IsTrue(artists.Contains(artist));
        }

        [TestMethod]
        public void Get_ListArtists_ReturnsCorrectArtists()
        {
            var first = new Artist{Id = Guid.NewGuid(), ArtistId = Guid.NewGuid()};
            var second = new Artist { Id = Guid.NewGuid(), ArtistId = Guid.NewGuid()};
            var third = new Artist { Id = Guid.NewGuid(), ArtistId = Guid.NewGuid() };

            var list = new List<Artist>
            {
                first,
                second,
                third
            };

            _context.Artists.AddRange(list);
            _context.SaveChanges();

            var searchList = new List<Artist>
            {
                new Artist{ArtistId = first.ArtistId},
                new Artist{ArtistId = second.ArtistId},
                new Artist{ArtistId = third.ArtistId}
            };

            var result = _artistRepository.Get(searchList).ToList();

            Assert.AreEqual(list.Count, result.Count);
        }
    }
}
