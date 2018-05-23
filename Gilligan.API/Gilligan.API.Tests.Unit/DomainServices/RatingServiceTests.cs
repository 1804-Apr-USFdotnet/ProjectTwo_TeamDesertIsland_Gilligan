using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Gilligan.API.RepositoryContracts;
using Gilligan.API.Models;
using System;
using System.Collections.Generic;
using Gilligan.API.DomainServices;

namespace Gilligan.API.Tests.Unit.DomainServices
{
    [TestClass]
    public class RatingServiceTests
    {
        private readonly RatingService _ratingService;
        private readonly Mock<ISongRepository> _songRepository;
        private readonly Mock<IArtistRepository> _artistRepository;
        private readonly Mock<IAlbumRepository> _albumRepository;
        private readonly Mock<IGenreRepository> _genreRepository;
        private readonly Mock<IUserRepository> _userRepository;

        public RatingServiceTests()
        {
            _songRepository = new Mock<ISongRepository>();
            _songRepository.Setup(y => y.Get(It.IsAny<Guid>())).Returns(new Song());
            _songRepository.Setup(x => x.Get()).Returns(new List<Song>());
            _songRepository.Setup(x => x.SaveChanges());

            _userRepository = new Mock<IUserRepository>();
            _userRepository.Setup(z => z.Get(It.IsAny<Guid>())).Returns(new User());

            _artistRepository = new Mock<IArtistRepository>();
            _artistRepository.Setup(x => x.Get()).Returns(new List<Artist>());

            _genreRepository = new Mock<IGenreRepository>();
            _genreRepository.Setup(x => x.Get()).Returns(new List<Genre>());

            _albumRepository = new Mock<IAlbumRepository>();
            _albumRepository.Setup(x => x.Get()).Returns(new List<Album>());
            
            _ratingService = new RatingService(_songRepository.Object, _artistRepository.Object,
                _genreRepository.Object, _albumRepository.Object, _userRepository.Object);
        }

        [TestMethod]
        public void AddRating_Rating_CallsSongRepoGet()
        {
            var rating = new Rating
            {
                Song = new Song{SongId = Guid.NewGuid()},
                User = new User { UserId = Guid.NewGuid()}
            };
            
            _ratingService.AddRating(rating);

            _songRepository.Verify(x => x.Get(It.IsAny<Guid>()), Times.AtLeastOnce);
        }

        [TestMethod]
        public void AddRating_Rating_CallsUserRepoGet()
        {
            var rating = new Rating
            {
                Song = new Song { SongId = Guid.NewGuid() },
                User = new User { UserId = Guid.NewGuid() }
            };

            _ratingService.AddRating(rating);

            _userRepository.Verify(x => x.Get(It.IsAny<Guid>()), Times.AtLeastOnce);
        }

        [TestMethod]
        public void AddRating_Rating_CallsSongRepoSaveChanges()
        {
            var rating = new Rating
            {
                Song = new Song { SongId = Guid.NewGuid() },
                User = new User { UserId = Guid.NewGuid() }
            };

            _ratingService.AddRating(rating);

            _songRepository.Verify(x => x.SaveChanges(), Times.AtLeastOnce);
        }

        [TestMethod]
        public void AlbumRating_IntTakeAmount_CallsAlbumRepoGet()
        {
            _ratingService.AlbumRatings(new int());

            _albumRepository.Verify(x => x. Get(), Times.AtLeastOnce);
        }

        [TestMethod]
        public void SongRatings_IntTakeAmount_CallsAlbumRepoGet()
        {
            _ratingService.SongRatings(new int());

            _songRepository.Verify(x => x.Get(), Times.AtLeastOnce);
        }

        [TestMethod]
        public void ArtistRatings_IntTakeAmount_CallsArtistRepoGet()
        {
            _ratingService.ArtistRatings(new int());

            _artistRepository.Verify(x => x.Get(), Times.AtLeastOnce);
        }

        [TestMethod]
        public void GenreRatings_IntTakeAmount_CallsGenreRepoGet()
        {
            _ratingService.GenreRatings(new int());

            _genreRepository.Verify(x => x.Get(), Times.AtLeastOnce);
        }
    }
}
