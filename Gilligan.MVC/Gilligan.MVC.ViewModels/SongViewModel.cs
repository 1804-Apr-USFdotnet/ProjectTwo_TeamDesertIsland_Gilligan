using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gilligan.MVC.ViewModels
{
    class SongViewModel
    {
        public Guid SongId { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public double Rating { get; set; }
    }
}
