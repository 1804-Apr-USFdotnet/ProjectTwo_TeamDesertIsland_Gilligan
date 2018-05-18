﻿using System.Collections.Generic;

namespace Gilligan.MVC.ViewModels.Music
{
    public class ArtistViewModel
    {
        public string Name { get; set; }
        public IEnumerable<SongViewModel> SongViewModels { get; set; }
    }
}