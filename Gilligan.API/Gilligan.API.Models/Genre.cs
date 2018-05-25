using System;
using System.Collections.Generic;

namespace Gilligan.API.Models
{
    public class Genre
    {
        public Guid Id { get; set; }
        public Guid GenreId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Artist> Artists { get; set; }

        public Genre()
        {
            Artists = new HashSet<Artist>();
        }
    }
}
