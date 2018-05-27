using System;
using System.Collections.Generic;

namespace Gilligan.API.ViewModels
{
    public class SongViewModel
    {
        public Guid SongId { get; set; }
        public string Name { get; set; }
        public double AverageRating { get; set; }
        public bool IsAttached { get; set; }
        //public AlbumViewModel AlbumViewModel { get; set; }
        //public IEnumerable<ArtistViewModel> ArtistViewModel { get; set; }
    }
}
