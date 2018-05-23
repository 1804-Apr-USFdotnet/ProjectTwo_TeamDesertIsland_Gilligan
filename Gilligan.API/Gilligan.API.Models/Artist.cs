using System;
using System.Collections.Generic;

namespace Gilligan.API.Models
{
    public class Artist
    {
        public Guid Id { get; set; }
        public Guid ArtistId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }

        public Artist()
        {
            Genres = new HashSet<Genre>();
            Songs = new HashSet<Song>();
        }
    }
}
