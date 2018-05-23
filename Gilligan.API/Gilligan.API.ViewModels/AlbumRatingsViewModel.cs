using System.Collections.Generic;

namespace Gilligan.API.ViewModels
{
    public class AlbumRatingsViewModel
    {
        public IEnumerable<AlbumViewModel> TopDailyAlbumViewModels { get; set; }
        public IEnumerable<AlbumViewModel> TopWeeklyRatedAlbumViewModels { get; set; }
        public IEnumerable<AlbumViewModel> TopMonthlyRatedAlbumViewModels { get; set; }
        public IEnumerable<AlbumViewModel> TopAllTimeRatedAlbumViewModels { get; set; }
    }
}
