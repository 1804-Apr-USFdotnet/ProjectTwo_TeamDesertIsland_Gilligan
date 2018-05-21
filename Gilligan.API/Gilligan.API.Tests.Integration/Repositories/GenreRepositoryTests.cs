using System;
using System.Collections.Generic;
using System.Linq;
using Gilligan.API.Models;
using Gilligan.API.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gilligan.API.Tests.Integration.Repositories
{
    [TestClass]
    public class GenreRepositoryTests
    {
        private readonly GilliganTestContext _context;
        private readonly GenreRepository _genreRepository;

        public GenreRepositoryTests()
        {
            _context = new GilliganTestContext();
            _genreRepository = new GenreRepository(_context);
        }

        [TestInitialize]
        public void ClearTable()
        {
            _context.Genres.RemoveRange(_context.Genres);
            _context.SaveChanges();
        }

        [TestMethod]
        public void Get_Empty_ReturnsAllGenres()
        {
            var genres = new List<Genre>
            {
                new Genre{Id = Guid.NewGuid()},
                new Genre{Id = Guid.NewGuid()}
            };

            _context.Genres.AddRange(genres);
            _context.SaveChanges();

            var results = _genreRepository.Get().ToList();

            Assert.AreEqual(genres.Count, results.Count);
        }

        [TestMethod]
        public void Get_String_ReturnsCorrectGenres()
        {
            var genres = new List<Genre>
            {
                new Genre{Id = Guid.NewGuid(), Name = "Bob"},
                new Genre{Id = Guid.NewGuid(), Name = "NotBob"}
            };

            _context.Genres.AddRange(genres);
            _context.SaveChanges();

            var result = _genreRepository.Get("Bob");

            const int expected = 1;

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void Add_Genre_AddGenreToDatabase()
        {
            var genre = new Genre{Id = Guid.NewGuid()};

            _genreRepository.Add(genre);

            var genres = _context.Genres.ToList();

            Assert.IsTrue(genres.Contains(genre));
        }
    }
}
