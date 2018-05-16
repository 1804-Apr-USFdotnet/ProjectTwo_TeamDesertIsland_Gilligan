using System;
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
    }
}
