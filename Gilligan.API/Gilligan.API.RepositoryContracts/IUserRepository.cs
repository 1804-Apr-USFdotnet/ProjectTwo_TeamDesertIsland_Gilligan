using System;
using Gilligan.API.Models;

namespace Gilligan.API.RepositoryContracts
{
    public interface IUserRepository
    {
        User Get(Guid userId);
        void DeleteUserSong(UserSong userSong);
        void SaveChanges();
    }
}
