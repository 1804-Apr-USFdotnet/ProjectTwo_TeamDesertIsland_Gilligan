using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using Gilligan.API.RepositoryContracts;
using Gilligan.API.Models;
using System;
using Gilligan.API.DomainContracts;
using Gilligan.API.DomainServices;

namespace Gilligan.API.Tests.Unit.DomainServices
{
    [TestClass]
    public class RatingServiceTests
    {
        private readonly RatingService _ratingService;

        private readonly Mock<IRatingRepository> _mockRatingRepository;

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

            var mockSongRepository = new Mock<ISongRepository>();
            mockSongRepository.Setup(y => y.Get(It.IsAny<Guid>())).Returns(new Song());

            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(z => z.Get(It.IsAny<Guid>())).Returns(new User());

            _mockRatingRepository = new Mock<IRatingRepository>();
            _mockRatingRepository.Setup(x => x.Add(It.IsAny<Rating>()));
            _mockRatingRepository.Setup(x => x.Get()).Returns(ratings);

            var mockArtistRepository = new Mock<IArtistRepository>();
            var mockGenreRepository = new Mock<IGenreRepository>();
            var mockAlbumRepository = new Mock<IAlbumRepository>();
            var mockIventoryService = new Mock<IInventoryService>();
           
            _ratingService = new RatingService(mockSongRepository.Object, mockArtistRepository.Object,
                mockGenreRepository.Object, mockAlbumRepository.Object);
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
