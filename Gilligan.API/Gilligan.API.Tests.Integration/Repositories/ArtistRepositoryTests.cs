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
    }
}
