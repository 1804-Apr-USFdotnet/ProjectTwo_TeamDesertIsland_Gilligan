﻿using System;
using System.Collections.Generic;

namespace Gilligan.API.ViewModels
{
    public class ArtistViewModel
    {
        public Guid ArtistId { get; set; }
        public string Name { get; set; }
        public IEnumerable<SongViewModel> SongViewModels { get; set; }
        //public IEnumerable<GenreViewModel> GenreViewModels { get; set; }
    }
}
