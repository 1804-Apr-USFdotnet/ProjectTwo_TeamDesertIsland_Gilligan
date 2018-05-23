using System;
using System.Collections.Generic;
using Gilligan.API.DomainServices;
using Gilligan.API.Models;
using Gilligan.API.RepositoryContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Gilligan.API.Tests.Unit.DomainServices
{
    [TestClass]
    public class InventoryServiceTests
    {
        private readonly InventoryService _inventoryService;
        private readonly Mock<ISongRepository> _songRepository;
        private readonly Mock<IArtistRepository> _artistRepository;
        private readonly Mock<IAlbumRepository> _albumRepository;
        private readonly Mock<IGenreRepository> _genreRepository;
        private readonly Mock<IUserRepository> _userRepository;

        public InventoryServiceTests()
        {
            _songRepository = new Mock<ISongRepository>();
            _songRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(new Song());
            _songRepository.Setup(x => x.SaveChanges());
            _songRepository.Setup(x => x.Add(It.IsAny<Song>()));

            _artistRepository = new Mock<IArtistRepository>();
            _artistRepository.Setup(x => x.Add(It.IsAny<Artist>()));
            _artistRepository.Setup(x => x.Get(It.IsAny<IEnumerable<Artist>>())).Returns(new List<Artist>());

            _albumRepository = new Mock<IAlbumRepository>();
            _albumRepository.Setup(x => x.Add(It.IsAny<Album>()));
            _albumRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(new Album());

            _genreRepository = new Mock<IGenreRepository>();
            _genreRepository.Setup(x => x.Add(It.IsAny<Genre>()));

            _userRepository = new Mock<IUserRepository>();
            _userRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(new User{UserSongs = new List<UserSong>()});
            _userRepository.Setup(x => x.SaveChanges());

            _inventoryService = new InventoryService(_genreRepository.Object, _artistRepository.Object, _albumRepository.Object, _songRepository.Object, _userRepository.Object);
        }

        [TestMethod]
        public void AddSongToUser_UserSong_CallsUserRepoGet()
        {
            var userSong = new UserSong
            {
                SongId = Guid.NewGuid(),
                User = new User { UserId = Guid.NewGuid()}
            };

            _inventoryService.AddSongToUser(userSong);

            _userRepository.Verify(x => x.Get(It.IsAny<Guid>()), Times.AtLeastOnce);
        }

        [TestMethod]
        public void AddSongToUser_UserSong_CallSongRepoGet()
        {
            var userSong = new UserSong
            {
                SongId = Guid.NewGuid(),
                User = new User { UserId = Guid.NewGuid() }
            };

            _inventoryService.AddSongToUser(userSong);

            _songRepository.Verify(x => x.Get(It.IsAny<Guid>()), Times.AtLeastOnce);
        }

        [TestMethod]
        public void AddSongToUser_UserSong_CallsUserRepoSave()
        {
            var userSong = new UserSong
            {
                SongId = Guid.NewGuid(),
                User = new User { UserId = Guid.NewGuid() }
            };

            _inventoryService.AddSongToUser(userSong);

            _userRepository.Verify(x => x.SaveChanges(), Times.AtLeastOnce);
        }

        [TestMethod]
        public void AddSongToUser_UserSong_CallsSongRepoSave()
        {
            var userSong = new UserSong
            {
                SongId = Guid.NewGuid(),
                User = new User { UserId = Guid.NewGuid() }
            };

            _inventoryService.AddSongToUser(userSong);

            _songRepository.Verify(x => x.SaveChanges(), Times.AtLeastOnce);
        }

        [TestMethod]
        public void RemoveSongFromUser_UserSong_CallsUserRepoDeleteUserSong()
        {
            var userSong = new UserSong
            {
                SongId = Guid.NewGuid(),
                User = new User { UserId = Guid.NewGuid() }
            };

            _inventoryService.RemoveSongFromUser(userSong);

            _userRepository.Verify(x => x.DeleteUserSong(It.IsAny<UserSong>()), Times.AtLeastOnce);
        }

        [TestMethod]
        public void RemoveSongFromUser_UserSong_CallsSongRepoGet()
        {
            var userSong = new UserSong
            {
                SongId = Guid.NewGuid(),
                User = new User { UserId = Guid.NewGuid() }
            };

            _inventoryService.RemoveSongFromUser(userSong);

            _songRepository.Verify(x => x.Get(It.IsAny<Guid>()), Times.AtLeastOnce);
        }

        [TestMethod]
        public void RemoveSongFromUser_UserSong_CallsSongRepoSave()
        {
            var userSong = new UserSong
            {
                SongId = Guid.NewGuid(),
                User = new User { UserId = Guid.NewGuid() }
            };

            _inventoryService.RemoveSongFromUser(userSong);

            _songRepository.Verify(x => x.SaveChanges(), Times.AtLeastOnce);
        }

        [TestMethod]
        public void AddSong_Song_CallsSongRepoAdd()
        {
            var song = new Song{Artists = new List<Artist>(), Album = new Album()};

            _inventoryService.AddSong(song);

            _songRepository.Verify(x => x.Add(It.IsAny<Song>()), Times.AtLeastOnce);
        }

        [TestMethod]
        public void AddAlbum_Album_CallsAlbumRepoAdd()
        {
            var album = new Album();

            _inventoryService.AddAlbum(album);

            _albumRepository.Verify(x => x.Add(It.IsAny<Album>()), Times.AtLeastOnce);
        }

        [TestMethod]
        public void AddArtist_Artist_CallsArtistRepoAdd()
        {
            var artist = new Artist();

            _inventoryService.AddArtist(artist);

            _artistRepository.Verify(x => x.Add(It.IsAny<Artist>()), Times.AtLeastOnce);
        }

        [TestMethod]
        public void AddGenre_Genre_CallsGenreRepoAdd()
        {
            var genre = new Genre();

            _inventoryService.AddGenre(genre);

            _genreRepository.Verify(x => x.Add(It.IsAny<Genre>()), Times.AtLeastOnce);
        }
    }
}
