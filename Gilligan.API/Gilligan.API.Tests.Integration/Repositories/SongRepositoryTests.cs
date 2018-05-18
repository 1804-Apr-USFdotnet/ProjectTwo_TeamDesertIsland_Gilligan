using System;
using System.Collections.Generic;
using System.Linq;
using Gilligan.API.Models;
using Gilligan.API.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gilligan.API.Tests.Integration.Repositories
{
    [TestClass]
    public class SongRepositoryTests
    {
        private readonly GilliganTestContext _context;
        private readonly SongRepository _songRepository;

        public SongRepositoryTests()
        {
            _context = new GilliganTestContext();
            _songRepository = new SongRepository(_context);
        }

        [TestInitialize]
        public void ClearTable()
        {
            _context.Songs.RemoveRange(_context.Songs);
            _context.SaveChanges();
        }

        [TestMethod]
        public void Get_Guid_ReturnsCorrectSong()
        {
            var song = new Song
            {
                Id = Guid.NewGuid(),
                SongId = Guid.NewGuid(),
                Album = new Album { Id = Guid.NewGuid(), ReleaseDate = DateTime.Today}
            };

            _context.Songs.Add(song);
            _context.SaveChanges();

            var result = _songRepository.Get(song.SongId);

            Assert.AreEqual(song, result);
        }

        [TestMethod]
        public void Get_Empty_ReturnsAllSongs()
        {
            var songs = new List<Song>
            {
                new Song
                {
                    Id = Guid.NewGuid(),
                    SongId = Guid.NewGuid(),
                    Album = new Album { Id = Guid.NewGuid(), ReleaseDate = DateTime.Today }
                },
                new Song
                {
                    Id = Guid.NewGuid(),
                    SongId = Guid.NewGuid(),
                    Album = new Album { Id = Guid.NewGuid(), ReleaseDate = DateTime.Today }
                }
            };
                       
            
            _context.Songs.AddRange(songs);
            _context.SaveChanges();

            var results = _songRepository.Get().ToList();

            Assert.AreEqual(songs.Count, results.Count);
        }
    }
}
