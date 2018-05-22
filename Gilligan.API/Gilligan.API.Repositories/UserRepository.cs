using System;
using System.Linq;
using Gilligan.API.Models;
using Gilligan.API.RepositoryContracts;

namespace Gilligan.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContext _context;

        public UserRepository(IDbContext context)
        {
            _context = context;
        }

        public User Get(Guid userId)
        {
            return _context.Users.First(x => x.UserId == userId);
        }

        public void DeleteUserSong(UserSong userSong)
        {
            var userToUpdate = _context.Users.First(x => x.UserId == userSong.User.UserId);

            var userSongToDelete =  userToUpdate.UserSongs.First(x => x.SongId == userSong.SongId);

            _context.UserSongs.Remove(userSongToDelete);
            _context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
