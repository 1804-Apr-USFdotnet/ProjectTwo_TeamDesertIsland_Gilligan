using System;
using System.Collections.Generic;
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
    }
}
