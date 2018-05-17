using System.Collections.Generic;

namespace Gilligan.MVC.ViewModels
{
    public class SearchGenreViewModel
    {
        public IEnumerable<SongViewModel> SongViewModels { get; set; }
    }
}
