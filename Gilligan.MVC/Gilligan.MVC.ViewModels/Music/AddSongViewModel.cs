using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gilligan.MVC.ViewModels.Music
{
    public class AddSongViewModel
    {
        public string Name { get; set; }
        public Guid AlbumId { get; set; }
        public IEnumerable<Guid> ArtistIds { get; set; }
    }
}
