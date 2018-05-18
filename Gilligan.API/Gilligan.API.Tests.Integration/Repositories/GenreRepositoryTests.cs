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
    }
}