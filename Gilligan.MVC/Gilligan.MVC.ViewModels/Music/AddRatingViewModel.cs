using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gilligan.MVC.ViewModels.Music
{
    class AddRatingViewModel
    {
        public DateTime? RatedOn { get; set; }
        public int Value { get; set; }
        public Guid UserId { get; set; }
        public Guid SongId { get; set; }
    }
}
