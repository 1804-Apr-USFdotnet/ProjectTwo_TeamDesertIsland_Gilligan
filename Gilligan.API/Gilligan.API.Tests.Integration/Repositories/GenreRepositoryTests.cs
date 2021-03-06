﻿using System;
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
        public void Add_Genre_AddGenreToDatabase()
        {
            var genre = new Genre{Id = Guid.NewGuid()};

            _genreRepository.Add(genre);

            var genres = _context.Genres.ToList();

            Assert.IsTrue(genres.Contains(genre));
        }

        [TestMethod]
        public void Get_ListGenres_ReturnsCorrectGenres()
        {
            var first = new Genre{Id = Guid.NewGuid(), GenreId = Guid.NewGuid()};
            var second = new Genre { Id = Guid.NewGuid(), GenreId = Guid.NewGuid() };
            var third = new Genre { Id = Guid.NewGuid(), GenreId = Guid.NewGuid() };

            var list = new List<Genre>
            {
                first, second, third
            };

            _context.Genres.AddRange(list);
            _context.SaveChanges();

            var searchList = new List<Genre>
            {
                new Genre{GenreId = first.GenreId},
                new Genre{GenreId = second.GenreId},
                new Genre{GenreId = third.GenreId}
            };

            var results = _genreRepository.Get(searchList).ToList();

            Assert.AreEqual(list.Count, results.Count);
        }
    }
}
