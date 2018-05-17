using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gilligan.MVC.ViewModels
{
    class SearchSongViewModel
    {
        public virtual IEnumerable<SongViewModel> SongViewModels { get; set; }
    }
}
