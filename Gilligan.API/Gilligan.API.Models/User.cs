using System;
using System.Collections.Generic;

namespace Gilligan.API.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int ZipCode { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<UserSong> UserSongs { get; set; }

        public User()
        {
            Ratings = new HashSet<Rating>();
            UserSongs = new HashSet<UserSong>();
        }
    }
}
