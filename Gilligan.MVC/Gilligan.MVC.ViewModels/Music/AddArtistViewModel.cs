using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gilligan.MVC.ViewModels.Music
{
    public class AddArtistViewModel
    {
        public string Name { get; set; }
        public IEnumerable<Guid> GenreIds { get; set; }
    }
}
