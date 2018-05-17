using System.Data.Entity;
using Gilligan.API.Models;

namespace Gilligan.API.Repositories
{
    public class GilliganTestContext : DbContext, IDbContext
    {
        public GilliganTestContext() : base("name=GilliganTestConnectionString")
        {

        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserSong> UserSongs { get; set; }
    }
}
