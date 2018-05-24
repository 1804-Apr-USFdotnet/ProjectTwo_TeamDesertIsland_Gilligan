using System;
using System.Collections.Generic;

namespace Gilligan.MVC.ViewModels.Music
{
    public class GenreViewModel
    {
        public Guid GenreId { get; set; }
        public string Name { get; set; }
        public IEnumerable<ArtistViewModel> ArtistViewModels { get; set; }
    }
}
