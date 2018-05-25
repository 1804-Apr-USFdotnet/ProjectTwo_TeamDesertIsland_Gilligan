using System.Data.Entity;
using Gilligan.API.Models;

namespace Gilligan.API.Repositories
{
    public interface IDbContext
    {
        int SaveChanges();
        
        DbSet<Album> Albums { get; set; }
        DbSet<Artist> Artists { get; set; }
        DbSet<Genre> Genres { get; set; }
        DbSet<Rating> Ratings { get; set; }
        DbSet<Song> Songs { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<UserSong> UserSongs { get; set; }
    }
}
