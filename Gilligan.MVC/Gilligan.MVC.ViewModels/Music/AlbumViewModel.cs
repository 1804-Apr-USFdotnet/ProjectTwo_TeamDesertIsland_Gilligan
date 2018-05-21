using System.Collections.Generic;

namespace Gilligan.MVC.ViewModels.Music
{
    public class AlbumViewModel
    {
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public IEnumerable<SongViewModel> SongViewModels { get; set; }
    }
}
