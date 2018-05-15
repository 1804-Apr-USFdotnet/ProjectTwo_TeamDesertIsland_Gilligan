using System;
using System.Collections.Generic;

namespace Gilligan.API.Models
{
    public class Song
    {
        public Guid Id { get; set; }
        public Guid SongId { get; set; }
        public string Name { get; set; }
        public double AverageRating { get; set; }
        public string SpotifyId { get; set; }

        public virtual Album Album { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Artist> Artists { get; set; }
        
        public Song()
        {
            Ratings = new HashSet<Rating>();
            Artists = new HashSet<Artist>();
        }
    }
}
