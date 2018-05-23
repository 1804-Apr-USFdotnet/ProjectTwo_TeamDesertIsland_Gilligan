using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using AutoMapper;
using Gilligan.API.DomainServices;
using Gilligan.API.Models;
using Gilligan.API.Repositories;
using Gilligan.API.Rest;
using Gilligan.API.Rest.Controllers;
using Gilligan.API.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gilligan.API.Tests.Integration.Rest
{
    [TestClass]
    public class InventoryControllerTests
    {
        private readonly GilliganTestContext _context;
        private readonly InventoryController _inventoryController;

        public InventoryControllerTests()
        {
            _context = new GilliganTestContext();
            var container = Bootstrapper.RegisterTypes();
            var mapper = container.Resolve<IMapper>();

            _inventoryController = new InventoryController(new InventoryService(new GenreRepository(_context), new ArtistRepository(_context), new AlbumRepository(_context), new SongRepository(_context), new UserRepository(_context)), mapper);
        }

        [TestInitialize]
        public void ClearTables()
        {
            _context.Albums.RemoveRange(_context.Albums);
            _context.Artists.RemoveRange(_context.Artists);
            _context.Genres.RemoveRange(_context.Genres);
            _context.Users.RemoveRange(_context.Users);
            _context.Songs.RemoveRange(_context.Songs);
            _context.SaveChanges();
        }

        [TestMethod]
        public void AddSongToUser_AddRemoveUserSongViewModel_AddsSongToUser()
        {
            var user = new User {Id = Guid.NewGuid(), UserId = Guid.NewGuid()};
            var song = new Song{Id = Guid.NewGuid(), SongId = Guid.NewGuid(), Album = new Album{Id = Guid.NewGuid()}};

            _context.Users.Add(user);
            _context.Songs.Add(song);
            _context.SaveChanges();

            var viewModel = new AddRemoveUserSongViewModel
            {
                SongId = song.SongId,
                UserId = user.UserId
            };

            _inventoryController.AddSongToUser(viewModel);

            var updatedUser = _context.Users.Find(user.Id);
            const int expected = 1;

            Assert.AreEqual(expected, updatedUser.UserSongs.Count);
        }

        [TestMethod]
        public void RemoveSongFromUser_AddRemoveUserSongViewModel_RemovesSongFromUser()
        {
            var song = new Song { Id = Guid.NewGuid(), SongId = Guid.NewGuid(), Album = new Album { Id = Guid.NewGuid() } };
            var user = new User { Id = Guid.NewGuid(), UserId = Guid.NewGuid(), UserSongs = new List<UserSong>{new UserSong{Id = Guid.NewGuid(), SongId = song.SongId}}};
            
            _context.Users.Add(user);
            _context.Songs.Add(song);
            _context.SaveChanges();

            var viewModel = new AddRemoveUserSongViewModel
            {
                SongId = song.SongId,
                UserId = user.UserId
            };

            _inventoryController.RemoveSongFromUser(viewModel);

            var updatedUser = _context.Users.Find(user.Id);
            const int expected = 0;

            Assert.AreEqual(expected, updatedUser.UserSongs.Count);
        }

        [TestMethod]
        public void AddSongToInventory_AddSongViewModel_AddsSongToDatabase()
        {
            var album = new Album
            {
                Id = Guid.NewGuid(),
                AlbumId = Guid.NewGuid()
            };

            var artist = new Artist
            {
                Id = Guid.NewGuid(),
                ArtistId = Guid.NewGuid()
            };

            var viewModel = new AddSongViewModel
            {
                AlbumId = album.AlbumId,
                Name = "Basic B",
                ArtistIds = new List<Guid> { artist.ArtistId}
            };

            _context.Albums.Add(album);
            _context.Artists.Add(artist);
            _context.SaveChanges();

            _inventoryController.AddSongToInventory(viewModel);

            var songs = _context.Songs.ToList();

            const int expected = 1;

            Assert.AreEqual(expected, songs.Count);
        }

        [TestMethod]
        public void AddAlbumToInventory_AddAlbumViewModel_AddsAlbumToDatabase()
        {
            var viewModel = new AddAlbumViewModel{Name = "Me"};

            _inventoryController.AddAlbumToInventory(viewModel);

            var albums = _context.Albums.ToList();

            const int expected = 1;

            Assert.AreEqual(expected, albums.Count);
        }

        [TestMethod]
        public void AddArtistToInventory_AddArtistViewModel_AddsArtistToDatabase()
        {
            var genre = new Genre{Id = Guid.NewGuid(), GenreId = Guid.NewGuid()};

            _context.Genres.Add(genre);
            _context.SaveChanges();

            var viewModel = new AddArtistViewModel{GenreIds = new List<Guid>{genre.GenreId}};

            _inventoryController.AddArtistToInventory(viewModel);

            const int expected = 1;

            var artists = _context.Artists.ToList();

            Assert.AreEqual(expected, artists.Count);
        }

        [TestMethod]
        public void AddGenreToInventory_AddGenreViewModel_AddsGenreToDatabase()
        {
            var genre = new Genre {Id = Guid.NewGuid(), GenreId = Guid.NewGuid()};

            var viewModel = new AddGenreViewModel{GenreId = genre.GenreId};

            _inventoryController.AddGenreToInventory(viewModel);

            var genres = _context.Genres.ToList();

            const int expected = 1;

            Assert.AreEqual(expected, genres.Count);
        }
    }
}
