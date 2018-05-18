using Microsoft.VisualStudio.TestTools.UnitTesting;
using Gilligan.API.DomainServices;
using Moq;
using System.Collections.Generic;
using Gilligan.API.RepositoryContracts;
using Gilligan.API.Models;
using System;

namespace Gilligan.API.Tests.Unit.DomainServices
{
    [TestClass]
    public class RatingServiceTests
    {
        private readonly SongService _ratingService;

        private readonly Mock<IRatingRepository> _mockRatingRepository;
        private readonly Mock<ISongRepository> _mockSongRepository;
        private readonly Mock<IUserRepository> _mockUserRepository;

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

            _mockSongRepository = new Mock<ISongRepository>();
            _mockSongRepository.Setup(y => y.Get(It.IsAny<Guid>())).Returns(new Song());

            _mockUserRepository = new Mock<IUserRepository>();
            _mockUserRepository.Setup(z => z.Get(It.IsAny<Guid>())).Returns(new User());

            _mockRatingRepository = new Mock<IRatingRepository>();
            _mockRatingRepository.Setup(x => x.Add(It.IsAny<Rating>()));
            _mockRatingRepository.Setup(x => x.Get()).Returns(ratings);
           
            _ratingService = new SongService(_mockRatingRepository.Object, _mockSongRepository.Object, _mockUserRepository.Object);
        }

        [TestMethod]
        public void Get_NoParameter_CallsRepositoryMethod()
        {
            var result = _ratingService.Get();

            _mockRatingRepository.Verify(x => x.Get(), Times.AtLeastOnce);
        }

        [TestMethod]
        public void AddRating_GivenRating_CallsRepositoryMethod()
        {
            var rating = new Rating
            {
                Song = new Song(),
                User = new User()
            };
            
            _ratingService.AddRating(rating);

            _mockRatingRepository.Verify(x => x.Add(It.IsAny<Rating>()), Times.AtLeastOnce);
        }

    }
}
