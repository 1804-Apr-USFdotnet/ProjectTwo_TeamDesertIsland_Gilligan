using System.Collections.Generic;

namespace Gilligan.MVC.ViewModels.Music
{
    public class GenreViewModel
    {
        public string Name { get; set; }
        public IEnumerable<SongViewModel> SongViewModels { get; set; }
    }
}
