using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gilligan.MVC.ViewModels.Music
{
    class ArtistRatingViewModel
    {
        public IEnumerable<ArtistViewModel> TopDailyArtistViewModels { get; set; }
        public IEnumerable<ArtistViewModel> TopWeeklyRatedArtistViewModels { get; set; }
        public IEnumerable<ArtistViewModel> TopMonthlyRatedArtistViewModels { get; set; }
        public IEnumerable<ArtistViewModel> TopAllTimeRatedArtistViewModels { get; set; }
    }
}
