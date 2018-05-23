using System;
using System.Collections.Generic;

namespace Gilligan.API.ViewModels
{
    public class AddArtistViewModel
    {
        public string Name { get; set; }
        public IEnumerable<Guid> GenreIds { get; set; }
    }
}
