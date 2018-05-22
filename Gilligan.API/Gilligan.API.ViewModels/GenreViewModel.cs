using System;
using System.Collections.Generic;

namespace Gilligan.API.ViewModels
{
    public class GenreViewModel
    {
        public Guid GenreId { get; set; }
        public string Name { get; set; }
        public IEnumerable<ArtistViewModel> ArtistViewModels { get; set; }
    }
}
