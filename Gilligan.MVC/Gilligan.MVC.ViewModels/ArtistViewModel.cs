using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gilligan.MVC.ViewModels
{
    class ArtistViewModel
    {
        public string Name { get; set; }
        public ICollection<SongViewModel> SongViewModels { get; set; }
    }
}
