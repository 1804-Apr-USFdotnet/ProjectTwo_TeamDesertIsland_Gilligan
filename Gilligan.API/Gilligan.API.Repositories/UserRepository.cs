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

        public void DeleteUserSong(User user, Song song)
        {
            var userToUpdate = _context.Users.First(x => x.UserId == user.UserId);

            var userSongToDelete =  userToUpdate.UserSongs.First(x => x.SongId == song.SongId);

            _context.UserSongs.Remove(userSongToDelete);
            _context.SaveChanges();
        }
    }
}
