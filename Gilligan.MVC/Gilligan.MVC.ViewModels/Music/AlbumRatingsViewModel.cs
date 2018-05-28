using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gilligan.MVC.ViewModels.Music
{
    public class AlbumRatingsViewModel
    {
        public IEnumerable<AlbumViewModel> TopDailyAlbumViewModels { get; set; }
        public IEnumerable<AlbumViewModel> TopWeeklyRatedAlbumViewModels { get; set; }
        public IEnumerable<AlbumViewModel> TopMonthlyRatedAlbumViewModels { get; set; }
        public IEnumerable<AlbumViewModel> TopAllTimeRatedAlbumViewModels { get; set; }
    }
}
