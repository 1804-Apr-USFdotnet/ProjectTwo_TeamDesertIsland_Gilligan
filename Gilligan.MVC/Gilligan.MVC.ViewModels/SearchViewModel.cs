using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gilligan.MVC.ViewModels
{
    class SearchViewModel
    {
        private enum SearchType { song, artist, genre}
        public string SearchString { get; set; }
    }
}
