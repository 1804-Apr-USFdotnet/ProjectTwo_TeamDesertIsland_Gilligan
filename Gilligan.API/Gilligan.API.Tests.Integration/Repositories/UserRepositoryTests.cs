using System;
using System.Collections.Generic;
using Gilligan.API.Models;
using Gilligan.API.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Gilligan.API.Tests.Integration.Repositories
{
    [TestClass]
    public class UserRepositoryTests
    {
        private readonly GilliganTestContext _context;
        private readonly UserRepository _userRepository;

        public UserRepositoryTests()
        {
            _context = new GilliganTestContext();
            _userRepository = new UserRepository(_context);
        }

        [TestInitialize]
        public void ClearTable()
        {
            _context.Users.RemoveRange(_context.Users);
            _context.Songs.RemoveRange(_context.Songs);
            _context.SaveChanges();
        }

        [TestMethod]
        public void Get_Guid_ReturnsCorrectUser()
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                DateOfBirth = DateTime.Now
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            var result = _userRepository.Get(user.UserId);

            Assert.AreEqual(user, result);
        }

        [TestMethod]
        public void DeleteUserSong_UserAndSong_RemoveUserSongFromUser()
        {
            var song = new Song
            {
                Id = Guid.NewGuid(),
                SongId = Guid.NewGuid()
            };

            var user = new User
            {
                Id = Guid.NewGuid(),
                UserId = Guid.NewGuid(),
                UserSongs = new List<UserSong>
                {
                    new UserSong
                    {
                        Id = Guid.NewGuid(), 
                        SongId = song.SongId
                    }
                }
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            _userRepository.DeleteUserSong(user, song);

            var updatedUser = _context.Users.Find(user.Id);

            const int expected = 0;

            Assert.AreEqual(expected, updatedUser.UserSongs.Count);
        }
    }
}
