using System;
using System.Collections.Generic;

namespace Gilligan.API.ViewModels
{
    public class AlbumViewModel
    {
        public Guid AlbumId { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string Name { get; set; }
        public IEnumerable<SongViewModel> SongViewModels { get; set; }  
    }
}
