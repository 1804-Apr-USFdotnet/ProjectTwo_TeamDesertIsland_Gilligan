using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gilligan.API.DomainServices;
using Moq;
using ApprovalTests;
using ApprovalTests.Reporters;
using System.Collections.Generic;
using Gilligan.API.Repositories;
using Gilligan.API.RepositoryContracts;
using Gilligan.API.Models;
using System;

namespace Gilligan.API.Tests.Unit.DomainServices
{
    [TestClass]
    public class RatingServiceTests
    {
        private readonly RatingService _ratingService;
        private readonly Mock<IRatingRepository> _mockRepository;

        public RatingServiceTests()
        {
            var ratings = new List<Rating>
            {
                new Rating {RatedOn = new DateTime(2017,03,14), Value = 4},
                new Rating {RatedOn = new DateTime(2016,07,24), Value = 2},
                new Rating {RatedOn = new DateTime(2018,01,10), Value = 2},
                new Rating {RatedOn = new DateTime(2015,09,11), Value = 0},
                new Rating {RatedOn = new DateTime(2017,07,07), Value = 0},
                new Rating {RatedOn = new DateTime(2018,02,18), Value = 4}
            };

            _mockRepository = new Mock<IRatingRepository>();
            _mockRepository.Setup(x => x.Add(It.IsAny<Rating>()));
            _mockRepository.Setup(x => x.Get()).Returns(ratings);

            _ratingService = new RatingService(_mockRepository.Object);
        }

        [TestMethod]
        public void Get_NoParameter_CallsRepositoryMethod()
        {
            var result = _ratingService.Get();

            _mockRepository.Verify(x => x.Get(), Times.AtLeastOnce);
        }

        [TestMethod]
        public void AddRating_GivenRating_CallsRepositoryMethod()
        {
            var rating = new Rating();

            _ratingService.AddRating(rating);

            _mockRepository.Verify(x => x.Add(It.IsAny<Rating>()), Times.AtLeastOnce);
        }

    }
}
