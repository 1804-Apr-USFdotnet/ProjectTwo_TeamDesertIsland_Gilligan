using System;
using System.Collections.Generic;

namespace Gilligan.API.Models
{
    public class Album
    {
        public Guid Id { get; set; }
        public Guid AlbumId { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}
