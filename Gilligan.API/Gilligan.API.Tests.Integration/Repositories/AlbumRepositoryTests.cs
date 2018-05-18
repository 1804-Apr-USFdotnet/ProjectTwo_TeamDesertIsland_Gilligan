using System;
using System.Collections.Generic;
using System.Linq;
using Gilligan.API.Models;
using Gilligan.API.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gilligan.API.Tests.Integration.Repositories
{
    [TestClass]
    public class AlbumRepositoryTests
    {
        private readonly GilliganTestContext _context;
        private readonly AlbumRepository _albumRepository;

        public AlbumRepositoryTests()
        {
            _context = new GilliganTestContext();
            _albumRepository = new AlbumRepository(_context);
        }

        [TestInitialize]
        public void ClearTable()
        {
            _context.Albums.RemoveRange(_context.Albums);
            _context.SaveChanges();
        }

        [TestMethod]
        public void Get_Empty_ReturnsAllAlbums()
        {
            var albums = new List<Album>
            {
                new Album{Id = Guid.NewGuid(), ReleaseDate = DateTime.Now},
                new Album{Id = Guid.NewGuid(), ReleaseDate = DateTime.Today}
            };

            _context.Albums.AddRange(albums);
            _context.SaveChanges();

            var results = _albumRepository.Get().ToList();

            Assert.AreEqual(albums.Count, results.Count);
        }
    }
}
