using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gilligan.MVC.ViewModels.Music
{
    class SongRatingsViewModel
    {
        public IEnumerable<SongViewModel> TopDailyRatedSongViewModels { get; set; }
        public IEnumerable<SongViewModel> TopWeeklyRatedSongViewModels { get; set; }
        public IEnumerable<SongViewModel> TopMonthlyRatedSongViewModels { get; set; }
        public IEnumerable<SongViewModel> TopAllTimeRatedSongViewModels { get; set; }
    }
}
