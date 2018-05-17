using System.Collections.Generic;

namespace Gilligan.MVC.ViewModels
{
    public class ArtistViewModel
    {
        public string Name { get; set; }
        public ICollection<SongViewModel> SongViewModels { get; set; }
    }
}
