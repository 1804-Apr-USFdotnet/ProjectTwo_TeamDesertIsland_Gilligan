using System;
using System.Collections.Generic;
using System.Linq;
using Gilligan.API.DomainServices;
using Gilligan.API.Models;
using Gilligan.API.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gilligan.API.Tests.Integration.DomainServices
{
    [TestClass]
    public class InventoryServiceTests
    {
        private readonly GilliganTestContext _context;
        private readonly InventoryService _inventoryService;

        public InventoryServiceTests()
        {
            _context = new GilliganTestContext();
            _inventoryService = new InventoryService(new GenreRepository(_context), new ArtistRepository(_context), new AlbumRepository(_context), new SongRepository(_context), new UserRepository(_context));
        }

        [TestInitialize]
        public void ClearTables()
        {
            _context.Albums.RemoveRange(_context.Albums);
            _context.Users.RemoveRange(_context.Users);
            _context.Songs.RemoveRange(_context.Songs);
            _context.SaveChanges();
        }

        [TestMethod]
        public void AddSongToUser_UserSong_AddsUserSongToDatabase()
        {
            var user = new User {Id = Guid.NewGuid(), UserId = Guid.NewGuid()};
            var song = new Song{Id = Guid.NewGuid(), SongId = Guid.NewGuid(), Album = new Album{Id = Guid.NewGuid()}};

            _context.Users.Add(user);
            _context.Songs.Add(song);
            _context.SaveChanges();

            var userSong = new UserSong
            {
                Id = Guid.NewGuid(),
                UserSongId = Guid.NewGuid(),
                SongId = song.SongId,
                User = new User{UserId = user.UserId }
            };

            _inventoryService.AddSongToUser(userSong);

            var result = _context.UserSongs.First();

            Assert.AreEqual(result.Id, userSong.Id);
        }

        [TestMethod]
        public void AddSongToUser_UserSong_SongUsageIsUpdatedToTrue()
        {
            var user = new User { Id = Guid.NewGuid(), UserId = Guid.NewGuid() };
            var song = new Song { Id = Guid.NewGuid(), SongId = Guid.NewGuid(), Album = new Album { Id = Guid.NewGuid() } };

            _context.Users.Add(user);
            _context.Songs.Add(song);
            _context.SaveChanges();

            var userSong = new UserSong
            {
                Id = Guid.NewGuid(),
                UserSongId = Guid.NewGuid(),
                SongId = song.SongId,
                User = new User { UserId = user.UserId }
            };

            _inventoryService.AddSongToUser(userSong);

            var result = _context.Songs.Find(song.Id);

            Assert.IsTrue(result.IsAttached);
        }

        [TestMethod]
        public void RemoveSongFromUser_UserSong_DeletesUserSongFromDatabase()
        {
            var song = new Song { Id = Guid.NewGuid(), SongId = Guid.NewGuid(), Album = new Album { Id = Guid.NewGuid() } };
            var user = new User { Id = Guid.NewGuid(), UserId = Guid.NewGuid(), UserSongs = new List<UserSong>{new UserSong
            {
                Id = Guid.NewGuid(),
                UserSongId = Guid.NewGuid(),
                SongId = song.SongId
            }}};

            _context.Songs.Add(song);
            _context.Users.Add(user);
            _context.SaveChanges();

            var userSong = new UserSong
            {
                Id = Guid.NewGuid(),
                UserSongId = Guid.NewGuid(),
                SongId = song.SongId,
                User = new User { UserId = user.UserId }
            };

            _inventoryService.RemoveSongFromUser(userSong);

            var results = _context.UserSongs.ToList();

            const int expected = 0;

            Assert.AreEqual(expected, results.Count);
        }

        [TestMethod]
        public void RemoveSongFromUser_UserSong_SongUsageIsUpdatedToFalse()
        {
            var song = new Song { Id = Guid.NewGuid(), SongId = Guid.NewGuid(), Album = new Album { Id = Guid.NewGuid() } };
            var user = new User
            {
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                UserSongs = new List<UserSong>{new UserSong
                {
                    Id = Guid.NewGuid(),
                    UserSongId = Guid.NewGuid(),
                    SongId = song.SongId
                }}
            };

            _context.Songs.Add(song);
            _context.Users.Add(user);
            _context.SaveChanges();

            var userSong = new UserSong
            {
                Id = Guid.NewGuid(),
                UserSongId = Guid.NewGuid(),
                SongId = song.SongId,
                User = new User { UserId = user.UserId }
            };

            _inventoryService.RemoveSongFromUser(userSong);

            var result = _context.Songs.Find(song.Id);

            Assert.IsFalse(result.IsAttached);
        }

        [TestMethod]
        public void AddSong_Song_AddsSongToDatabase()
        {
            var album = new Album{Id = Guid.NewGuid()};
            var firstArtist = new Artist{Id = Guid.NewGuid(), ArtistId = Guid.NewGuid()};
            var secondArtist = new Artist { Id = Guid.NewGuid(), ArtistId = Guid.NewGuid() };
            var thirdArtist = new Artist { Id = Guid.NewGuid(), ArtistId = Guid.NewGuid() };

            var artists = new List<Artist>
            {
                firstArtist, secondArtist, thirdArtist
            };

            _context.Artists.AddRange(artists);
            _context.Albums.Add(album);
            _context.SaveChanges();

            var song = new Song
            {
                Id = Guid.NewGuid(),
                Album = new Album { AlbumId = album.AlbumId},
                Artists = new List<Artist>
                {
                    new Artist{ArtistId = firstArtist.ArtistId},
                    new Artist{ArtistId = secondArtist.ArtistId},
                    new Artist{ArtistId = thirdArtist.ArtistId}
                }
            };

            _inventoryService.AddSong(song);

            var songs = _context.Songs.ToList();

            Assert.IsTrue(songs.Contains(song));
        }

        [TestMethod]
        public void AddAlbum_Album_AddsAlbumToDatabase()
        {
            var album = new Album
            {
                Id = Guid.NewGuid()
            };

            _inventoryService.AddAlbum(album);

            var albums = _context.Albums.ToList();

            Assert.IsTrue(albums.Contains(album));
        }

        [TestMethod]
        public void AddArtist_Artist_AddsArtistToDatabase()
        {
            var firstGenre = new Genre{Id = Guid.NewGuid(), GenreId = Guid.NewGuid()};
            var secondGenre = new Genre { Id = Guid.NewGuid(), GenreId = Guid.NewGuid() };

            var genres = new List<Genre>
            {
                firstGenre, secondGenre
            };

            _context.Genres.AddRange(genres);
            _context.SaveChanges();

            var artist = new Artist
            {
                Id = Guid.NewGuid(),
                ArtistId = Guid.NewGuid(),
                Genres = new List<Genre>
                {
                    new Genre{GenreId = firstGenre.GenreId},
                    new Genre{GenreId = secondGenre.GenreId}
                }
            };

            _inventoryService.AddArtist(artist);

            var artists = _context.Artists.ToList();

            Assert.IsTrue(artists.Contains(artist));
        }

        [TestMethod]
        public void AddGenre_Genre_AddsGenreToDatabase()
        {
            var genre = new Genre{Id = Guid.NewGuid()};

            _inventoryService.AddGenre(genre);

            var genres = _context.Genres.ToList();

            Assert.IsTrue(genres.Contains(genre));
        }
    }
}
