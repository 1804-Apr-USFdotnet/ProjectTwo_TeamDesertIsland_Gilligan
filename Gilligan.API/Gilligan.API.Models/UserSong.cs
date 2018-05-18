using System;
using System.ComponentModel.DataAnnotations;

namespace Gilligan.API.Models
{
    public class UserSong
    {
        public Guid Id { get; set; }
        public Guid UserSongId { get; set; }
        public Guid SongId { get; set; }

        [Required]
        public virtual User User { get; set; }
    }
}
