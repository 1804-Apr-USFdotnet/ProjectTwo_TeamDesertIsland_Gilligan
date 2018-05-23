using System;
using System.Collections.Generic;

namespace Gilligan.API.ViewModels
{
    public class AddSongViewModel
    {
        public string Name { get; set; }
        public Guid AlbumId { get; set; }
        public IEnumerable<Guid> ArtistIds { get; set; }
    }
}
