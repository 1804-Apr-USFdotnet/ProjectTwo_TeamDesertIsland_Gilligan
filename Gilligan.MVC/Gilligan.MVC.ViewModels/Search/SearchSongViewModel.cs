using System.Collections.Generic;
using Gilligan.MVC.ViewModels.Music;

namespace Gilligan.MVC.ViewModels.Search
{
    public class SearchSongViewModel
    {
        public virtual IEnumerable<SongViewModel> SongViewModels { get; set; }
    }
}
