using System.Collections.Generic;
using Gilligan.MVC.ViewModels.Music;

namespace Gilligan.MVC.ViewModels.Search
{
    public class SearchGenreViewModel
    {
        public IEnumerable<SongViewModel> SongViewModels { get; set; }
    }
}
