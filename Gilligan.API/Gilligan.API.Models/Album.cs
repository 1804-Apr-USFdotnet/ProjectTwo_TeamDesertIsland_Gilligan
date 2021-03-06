﻿using System;
using System.Collections.Generic;

namespace Gilligan.API.Models
{
    public class Album
    {
        public Guid Id { get; set; }
        public Guid AlbumId { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Song> Songs { get; set; }

        public Album()
        {
            Songs = new HashSet<Song>();
        }
    }
}
