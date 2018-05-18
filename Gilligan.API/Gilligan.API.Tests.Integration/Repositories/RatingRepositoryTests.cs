using System;
using System.Collections.Generic;
using System.Linq;
using Gilligan.API.Models;
using Gilligan.API.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gilligan.API.Tests.Integration.Repositories
{
    [TestClass]
    public class RatingRepositoryTests
    {
        private readonly GilliganTestContext _context;
        private readonly RatingRepository _ratingRepository;

        public RatingRepositoryTests()
        {
            _context = new GilliganTestContext();
            _ratingRepository = new RatingRepository(_context);
        }

        [TestInitialize]
        public void ClearTable()
        {
            _context.Songs.RemoveRange(_context.Songs);
            _context.Users.RemoveRange(_context.Users);
            _context.SaveChanges();
        }

        [TestMethod]
        public void Add_Rating_AddsRatingToDatabase()
        {
            var rating = new Rating
            {
                Id = Guid.NewGuid(),
                RatedOn = DateTime.Today,
                Song = new Song { Id = Guid.NewGuid(), Album = new Album{Id = Guid.NewGuid(), ReleaseDate = DateTime.Today}},
                User = new User { Id = Guid.NewGuid(), DateOfBirth = DateTime.Today}
            };

            _ratingRepository.Add(rating);

            var ratings = _context.Ratings.ToList();

            Assert.IsTrue(ratings.Contains(rating));
        }

        [TestMethod]
        public void Get_Empty_ReturnsAllRatings()
        {
            var ratings = new List<Rating>
            {
                new Rating
                {
                    Id = Guid.NewGuid(),
                    RatedOn = DateTime.Today,
                    Song = new Song { Id = Guid.NewGuid(), Album = new Album{Id = Guid.NewGuid(), ReleaseDate = DateTime.Today}},
                    User = new User { Id = Guid.NewGuid(), DateOfBirth = DateTime.Today}
                },
                new Rating
                {
                    Id = Guid.NewGuid(),
                    RatedOn = DateTime.Today,
                    Song = new Song { Id = Guid.NewGuid(), Album = new Album{Id = Guid.NewGuid(), ReleaseDate = DateTime.Today}},
                    User = new User { Id = Guid.NewGuid(), DateOfBirth = DateTime.Today}
                }
            };

            _context.Ratings.AddRange(ratings);
            _context.SaveChanges();

            var results = _ratingRepository.Get().ToList();

            Assert.AreEqual(ratings.Count, results.Count);
        }
    }
}
