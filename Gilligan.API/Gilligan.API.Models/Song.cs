using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Gilligan.API.Models
{
    public class Song
    {
        public Guid Id { get; set; }
        public Guid SongId { get; set; }
        public string Name { get; set; }
        public double AverageRating { get; set; }
        public bool IsAttached { get; set; }

        [Required]
        public virtual Album Album { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Artist> Artists { get; set; }
        
        public Song()
        {
            Ratings = new HashSet<Rating>();
            Artists = new HashSet<Artist>();
        }

        public void CalculateAverageRating()
        {
            if (Ratings.Count == 0)
            {
                AverageRating = 0;
            }
            else
            {
                AverageRating = Ratings.Select(x => x.Value).Sum() / Ratings.Count;
            }
        }
    }
}
