using System.Collections.Generic;

namespace Gilligan.MVC.ViewModels
{
    public class SearchSongViewModel
    {
        public virtual IEnumerable<SongViewModel> SongViewModels { get; set; }
    }
}
