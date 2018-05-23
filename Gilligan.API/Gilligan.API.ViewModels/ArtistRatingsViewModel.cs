using System.Collections.Generic;

namespace Gilligan.API.ViewModels
{
    public class ArtistRatingsViewModel
    {
        public IEnumerable<ArtistViewModel> TopDailyArtistViewModels { get; set; }
        public IEnumerable<ArtistViewModel> TopWeeklyRatedArtistViewModels { get; set; }
        public IEnumerable<ArtistViewModel> TopMonthlyRatedArtistViewModels { get; set; }
        public IEnumerable<ArtistViewModel> TopAllTimeRatedArtistViewModels { get; set; }
    }
}
